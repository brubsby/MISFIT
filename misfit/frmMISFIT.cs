using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net;

namespace MISFIT
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.form_startup_height = this.Height;
        }

        public Globals globals;
        int timer1AutoLogPurge = 0;
        int timer1UpdateStatsCounter = 0;
        int timer1AutoWorkFetch = 0;
        //int timer1AutoWorkFetch = 3580;
        int timer1StallTestCounter = 0;
        bool EmailSentDueToLowWork = false;
        bool EmailSentDueToStalledProcess = false;
        bool PoppedDialogDueToLowWork = false;
        frmGIMPSresultsUpload frmGIMPSuploadResults = new frmGIMPSresultsUpload();
        frmSafeErrorDialog frmSafeDialog = new frmSafeErrorDialog();
        frmRemoteControl frmRemoteControl = new frmRemoteControl();

        
        Productivity productivity = null;
        int form_startup_height = 0;
        bool initialStartupCycle = true;

        DateTime SuspendAutomationUntil = DateTime.Now.AddSeconds(-1);  //default in the past
        DateTime LastUpdateGridStats = DateTime.Now.AddSeconds(-1);  //default in the past

        bool StallDetectionIsSuspended = false;


        private Queue ScheduleQueue = new Queue();
        private string LastSceduledEventExecuted = string.Empty;
        private DateTime LastScheduledEventExecutedTime = DateTime.Now.AddDays(-1);
        private double GHZDaysWorkToDo = 0;
        private string ScheduleName = Globals.PHRASE_DEFAULT_SCHEDULE;
        List<string> ScheduleFromFile = null;


        public enum PathTypes
        {
            Local,
            Remote,
            Any
        }

        


        public void PurgeFilesByAge(string path, int MaxDaysOld)
        {
            DateTime now = DateTime.Now;
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {

                if (File.GetLastWriteTime(file).AddDays(MaxDaysOld) < now)
                {
                    File.Delete(file);
                    Debug.WriteLine("deleting " + file + " " + File.GetLastWriteTime(file).ToString());
                }
            }
        }


        public void PurgeOldLogFiles()
        {
            string path = string.Empty;
            List<Exception> exceptions = new List<Exception>();
            Debug.WriteLine("In PurgeOldLogFiles");

            try
            {
                path = Globals.DIR_GIOM_SENT;
                PurgeFilesByAge(path, globals.cfg.settingPurgeLogsDaysOld);
                Application.DoEvents();
            }
            catch (Exception E)
            {
                exceptions.Add(E);
            }

            try
            {
                path = Globals.DIR_MISFIT_BACKUPS;
                PurgeFilesByAge(path, globals.cfg.settingPurgeLogsDaysOld);
                Application.DoEvents();
            }
            catch (Exception E)
            {
                exceptions.Add(E);
            }
            try
            {
                path = Globals.DIR_WEB_LOGGING;
                PurgeFilesByAge(path, globals.cfg.settingPurgeLogsDaysOld);
                Application.DoEvents();
            }
            catch (Exception E)
            {
                exceptions.Add(E);
            }

            if (exceptions.Count > 0)
            {
                foreach (Exception E in exceptions)
                {
                    PopSafeErrorForm("Error purging logs: " + E.Message);
                }

            }

        }







        public void UpdateGridStats()
        {

            if (globals.cfg.settingFactoringDirectories.Count == 0)
            {
                Globals.simpleMessageBox("No work directories specified!\r\nUse Configuration Editor to correct!");
                return;
            }

            
            int TotalWorkToDo = 0;
            int TotalFactorsFound = 0;
            int TotalFactorsProcessed = 0;
            string[] bits;
            int rowP = 0;
            long ResultsBytes = 0;
            double ghzDaysCredit = 0;
            double ghzDayToDo = 0;
            bool UIDdetected = false;
            string debugSection = string.Empty;
            Hashtable hashT = new Hashtable();
            LastUpdateGridStats = DateTime.Now;
            timer1UpdateStatsCounter = 0;//reset the auto update stats timer since here we are.
            //
            //this.Cursor = Cursors.WaitCursor;
            try
            {
                Debug.WriteLine("Updating GridStats @ " + DateTime.Now.ToString());
                this.Enabled = false;
                debugSection = "Applying file locks to work files";
                //o//FileLock.MultiLockByDirectoryList(globals.cfg.settingFactoringDirectories, Globals.FILE_WORK_TODO);
                debugSection = "Applying file locks to results files";
                //o//FileLock.MultiLockByDirectoryList(globals.cfg.settingFactoringDirectories, Globals.FILE_RESULTS);
                bits = new string[lstDirectories.Items.Count];
                int i = -1;
                foreach (string path in lstDirectories.Items)
                {
                    debugSection = "Loading Work from " + path;
                    string[] WorkLines = File.ReadAllLines(path + "\\" + Globals.FILE_WORK_TODO);
                    debugSection = "Loading Results from " + path;
                    string[] ResultsLine = File.ReadAllLines(path + "\\" + Globals.FILE_RESULTS);
                    FileInfo finfo = new FileInfo(path + "\\" + Globals.FILE_RESULTS);
                    ResultsBytes += finfo.Length;
                    int FactorsFound = 0;
                    int WorkToDo = 0;
                    int FactorsProcessed = 0;
                    i++; //keep track what path we looking at
                    debugSection = "Analyzing WorkToDo.txt rows";
                    foreach (string eachLine in WorkLines)
                    {
                        string tempstring = eachLine.Trim();
                        if (tempstring.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                        {
                            WorkToDo++;
                            TotalWorkToDo++;
                            //Factor=C65A40DA76ABDF52F90D98AF7D7C8C48,67205989,70,71
                            string[] splitter = tempstring.Split(',');
                            ghzDayToDo += Globals.CalcGHDZ(Convert.ToInt32(splitter[1]), Convert.ToInt32(splitter[2]), Convert.ToInt32(splitter[3]));
                            if (bits[i] == null)//catch the first working row from the file and see what bit range it working on
                            {
                                if (globals.cfg.settingShowWorkingFactorInPhases)
                                    bits[i] = splitter[2] + "|" + (Convert.ToInt32(splitter[2]) + 1).ToString() + "|" + splitter[3].Substring(0, 2) + " " + splitter[1];
                                else
                                    bits[i] = splitter[2] + "|" + splitter[3] + " " + splitter[1];
                            }
                            try
                            {
                                if (globals.cfg.settingDuplicateAssignmentsDetectionIncludeBitLevel)
                                    hashT.Add(splitter[1] + splitter[2] + splitter[3], string.Empty);
                                else
                                    hashT.Add(splitter[1], string.Empty);
                            }
                            catch (System.ArgumentException)
                            {
                                PopSafeErrorForm(splitter[1] + "," + splitter[2] + "," + splitter[3] + " found in " + path + "  is a duplicate.");
                            }
                        }
                    }


                    debugSection = "Analyzing Results.txt rows";
                    foreach (string eachLine in ResultsLine)
                    {
                        string tempstring = eachLine.Trim();
                        int[] FactorParsedValues;
                        if (tempstring.ToUpper().Contains(Globals.PHRASE_UID))
                        {
                            UIDdetected = true;
                        }

                        //  //Debug.WriteLine("in Results.txt eval Loop, looking at:" + tempstring);
                        if (tempstring.Contains(Globals.PHRASE_FACTOR_FOUND))
                        {
                            FactorsFound++;
                            TotalFactorsProcessed++;
                            FactorsProcessed++;
                            FactorParsedValues = Globals.ParseOutFactorInfoFromAResultsRow(eachLine);
                            ghzDaysCredit += Globals.CalcGHDZ(FactorParsedValues[0], FactorParsedValues[1], FactorParsedValues[2]);
                        }
                        else if (tempstring.Contains(Globals.PHRASE_FACTOR_NOT_FOUND))
                        {
                            FactorsProcessed++;
                            TotalFactorsProcessed++;
                            FactorParsedValues = Globals.ParseOutFactorInfoFromAResultsRow(eachLine);
                            ghzDaysCredit += Globals.CalcGHDZ(FactorParsedValues[0], FactorParsedValues[1], FactorParsedValues[2]);
                        }
                    }

                    if (UIDdetected)
                    {
                        PopSafeErrorForm(Globals.PHRASE_UID + " detected in results. UNSUPPORTED FEATURE");
                    }
                    debugSection = "Updating Grid Row for this data loop";
                    dgv1[0, rowP].Value = path.Substring(path.LastIndexOf('\\'));
                    dgv1[1, rowP].Value = WorkToDo;
                    dgv1[2, rowP].Value = FactorsProcessed;
                    dgv1[3, rowP].Value = FactorsFound;
                    dgv1[4, rowP].Value = bits[i];
                    rowP++;
                    TotalFactorsFound += FactorsFound;
                }
                //update the totals row.
                int maxRow = dgv1.RowCount - 1;
                dgv1[1, maxRow].Value = TotalWorkToDo;
                dgv1[2, maxRow].Value = TotalFactorsProcessed;
                dgv1[3, maxRow].Value = TotalFactorsFound;
                dgv1.ClearSelection();
                debugSection = "Updating stats labels";
                this.GHZDaysWorkToDo = ghzDayToDo;//set the form level variable.
                lblFactorsToDo.Text = "ExpRows:" + TotalWorkToDo.ToString();
                lblFactorsDone.Text = "ExpsDone:" + TotalFactorsProcessed.ToString();
                lblFactorsFound.Text = "FactorsFound:" + TotalFactorsFound.ToString();
                lblGhzDaysCredit.Text = "GHzDsDone:" + ghzDaysCredit.ToString("N3");  //N3 means use number to 3 decimal places
                lblGhzDaysToDo.Text = "GHzDsToDo:" + ghzDayToDo.ToString("N3");
                lblResultsKbytes.Text = "ResultBytes:" + ResultsBytes;
                lblStagedGhzDays.Text = "StgdGHzDs:" + Globals.CalcGhzDaysFromWorkToDoFile(Globals.FILE_MISFIT_WORK_TODO).ToString("N3");
                lblStagedWork.Text = "StgdRows:" + Globals.GetCountOfValidRowsFromFile(Globals.FILE_MISFIT_WORK_TODO, Globals.PHRASE_WORKTODO_EXPONENT_ROW, true).ToString();
                productivity.CurrentWorkToDo = ghzDayToDo;
                lblLastUpdate.Text = DateTime.Now.ToString();
                
                debugSection = "Determining remaining work for alerting";
                if (ghzDayToDo < globals.cfg.settingNotifyWhenGHZdaysToDoDropsBelow && !initialStartupCycle)//dont't send email on inital startup. 
                {
                    lblGhzDaysToDo.BackColor = Color.Red;
                    lblGhzDaysToDo.ForeColor = Color.Yellow;

                    if (!PoppedDialogDueToLowWork)
                    {
                        PopSafeErrorForm("Remaining GHZdaysToDo is below threshold!");
                        PoppedDialogDueToLowWork = true;
                    }

                    if (globals.cfg.settingSendEmailWhenLowGHZdaysIsDetected && !EmailSentDueToLowWork && globals.cfg.isEmailConfigured())
                    {
                        debugSection = "Sending low GHZdaysToDo email";
                        try
                        {
                            globals.GlobalSendEmail(globals.cfg.settingEmailSubjectLowGHZDsToDo, "Currently remaining GHZdaysToDo is " + ghzDayToDo.ToString("N3") + " which is below the threshold of " + globals.cfg.settingNotifyWhenGHZdaysToDoDropsBelow.ToString());
                        }
                        catch (Exception E)
                        {
                            PopSafeErrorForm("Error low GHZdaysToDo email:" + E.Message);
                        }
                        EmailSentDueToLowWork = true;
                    }

                }
                else
                {
                    EmailSentDueToLowWork = false;
                    PoppedDialogDueToLowWork = false; //still may be showing the dialog but the condition is resolved. Dialog takes care of itself.
                    lblGhzDaysToDo.BackColor = SystemColors.Control;
                    lblGhzDaysToDo.ForeColor = Color.Maroon;
                }
                initialStartupCycle = false;

            }
            catch (Exception E)
            {

                PopSafeErrorForm("UpdateGridStats Error! " + debugSection + " " + E.Message);

            }
            finally
            {   
                    //o//FileLock.MultiUnlock();
                    Debug.WriteLine("GridStatus completion with a moment of sleep.");
                    Application.DoEvents();
                    Globals.Sleep(100);
                    this.Cursor = Cursors.Default;
                    Debug.WriteLine("final line of code in updategridstats");
                    this.Enabled = true;
                
            }

            
        }




        private void PopSafeErrorForm(string message)
        {
            message = DateTime.Now.ToString() + " " + message + "\r\n";
            if (!frmSafeDialog.IsHandleCreated)
            {
                frmSafeDialog = new frmSafeErrorDialog();
                frmSafeDialog.globals = this.globals;
                frmSafeDialog.Show();

            }

            if (frmSafeDialog.txtErrorText.Text.Length + 1000 > frmSafeDialog.txtErrorText.MaxLength)
            {
                frmSafeDialog.txtErrorText.Clear();
            }
            frmSafeDialog.txtErrorText.AppendText(message);

        }







        private void btnUpdateGridStats_Click(object sender, EventArgs e)
        {
            UpdateGridStats();
        }



        

        private int FetchMISFITversion(Boolean prerelease = false)
        {
            const string marker = "MISFITR-";
            int startMarker = 0;


            string data = WebIO.FetchReleaseVersions();
            Debug.WriteLine(data);
            startMarker = data.IndexOf(marker);
            if (startMarker > 0)
            {
                string temp = data.Substring(startMarker + marker.Length, 7);
                Debug.WriteLine("Online version number=" + temp);
                return int.Parse(temp);
            }
            else
            {
                throw new Exception("No version number found at " + Globals.URI_MISFIT_LIST_RELEASES_API);
            }


        }













        private void AddWork()
        {
            try
            {
                if (lstDirectories.Items.Count > 0)
                {
                    frmAddWork frm = new frmAddWork();

                    frm.globals = this.globals;
                    DialogResult res;

                    res = frm.ShowDialog();

                    if (frm.DataWasSaved) //only update grid if changes were made
                    {
                        UpdateGridStats();
                    }


                }
                else
                {

                    Globals.simpleMessageBox("No locations defined");
                }
            }
            catch (Exception E)
            {

                Globals.simpleMessageBox(E.Message);
            }



        }


       





        private bool ExportResultsList_Wrapper(bool HoldBackResults, bool ExportToGIOM, bool ShowExportInFile, bool WaitForGIOM, bool LaunchExportURL)
        {
            //if results are retruned we'll return a TRUE value
            bool haveResults = false;
            List<string> results = ExportResultsList(HoldBackResults);
            if (results.Count > 0)
            {
                haveResults = true;
                string FileName = Globals.CreateFileName(Globals.FILE_PREFIX_RESULTS_EXPORTED, Globals.FILE_EXT_TXT);
                File.WriteAllLines(Globals.DIR_MISFIT_BACKUPS + "\\" + FileName, results);
                SetProductivityUIValues();

                if (ShowExportInFile)
                    Process.Start(Globals.DIR_MISFIT_BACKUPS + "\\" + FileName);
                
                if (LaunchExportURL)
                    Process.Start(globals.cfg.settingExportURL);
                
                if (ExportToGIOM)
                {
                    File.WriteAllLines(Globals.DIR_GIOM_STAGED + "\\" + FileName, results);

                    if (WaitForGIOM)   //used especially for WRAP up processing.
                    {

                        LaunchGimpsIOManager(true);
                    }
                    else
                    {
                        LaunchGimpsIOManager(false);
                    }

                }

                UpdateGridStats();
            }else
            {
                if (Directory.GetFiles(Globals.DIR_GIOM_STAGED).Length > 0 && ExportToGIOM)  //are there any exports just sitting there waiting to get uploaded?
                {
                    haveResults = true;
                    if (WaitForGIOM)   //used especially for WRAP up processing.
                    {

                        LaunchGimpsIOManager(true);
                    }
                    else
                    {
                        LaunchGimpsIOManager(false);
                    }
                }
            
            
            }
            return haveResults;
        }
       
       

        private List<string> ExportResultsList(bool HoldBackPartialResults)
        {
            //low level routine to get the results that will be further processed as export
            List<string> FinalResultsToExport = new List<string>();
            List<string> FinalResultsHeldBack = new List<string>();
            
            foreach (string FactoringDirectory in globals.cfg.settingFactoringDirectories)
            {                
                if (HoldBackPartialResults)
                {
                   List<string> ResultsToExport = new List<string>();
                   List<string> ResultsToHoldBack = new List<string>();
                   string ActiveExponentInWorkToDo = string.Empty;
                   ActiveExponentInWorkToDo = string.Empty;
                   List<string> WorkToDoLines = Globals.SanitizeListFromFile(FactoringDirectory + "\\" + Globals.FILE_WORK_TODO, Globals.PHRASE_WORKTODO_EXPONENT_ROW,Globals.SanitizeModes.STARTS_WITH);

                    foreach (string line in WorkToDoLines)//look throught the workToDo for the first valid exponent line
                    {
                        string[] splitter = line.Split(',');  // be careful here
                            if (splitter.Length == 4)
                            {
                               int exponent=0;
                               if (int.TryParse(splitter[1], out exponent))
                               {
                                   if (exponent > 100000) //at this point we are pretty sure we have a good exponent to work with
                                   {
                                       ActiveExponentInWorkToDo = "M" + splitter[1];
                                       break;// we are done here as we have the first exponent in the file
                                   }

                               }
                            }                             
                    }

                    if (ActiveExponentInWorkToDo.Length > 0) //ok, we have a valid exponent line. Now see if the results have the same exponent
                    {
                        foreach (string line in File.ReadLines(FactoringDirectory + "\\" + Globals.FILE_RESULTS))
                        {
                            if (line.Contains(ActiveExponentInWorkToDo))  //does the result line have the same exponent?  
                            {
                                ResultsToHoldBack.Add(line);
                            }
                            else
                            {
                                ResultsToExport.Add(line);
                            }
                        }
                    }
                    else  //there was no exponent in workToDo  (maybe it was empty when we exported)
                    {
                        ResultsToExport.AddRange(File.ReadLines(FactoringDirectory + "\\" + Globals.FILE_RESULTS));
                    }

                    if (ResultsToExport.Count > 0 )  // this is the key... If we have results that need exporting then we have work to to.
                    {
                        FinalResultsToExport.AddRange(ResultsToExport);
                        Globals.backupFile(FactoringDirectory + "\\" + Globals.FILE_RESULTS, Globals.FILE_PREFIX_RESULTS_EXPORTED);
                        FinalResultsHeldBack.AddRange(ResultsToHoldBack); //if there are no results here we'll just have an empty list;
                        File.WriteAllLines(FactoringDirectory + "\\" + Globals.FILE_RESULTS, ResultsToHoldBack);  //if the holdback is empty then we just write an empty string into the file... perf
                        
                    }
                    
                   
                    
                }
                else // we are not going to holdback results so just load the whole file
                {
                    FinalResultsToExport.AddRange(File.ReadLines(FactoringDirectory + "\\" + Globals.FILE_RESULTS));
                    if (FinalResultsToExport.Count > 0)
                    {
                        Globals.backupFile(FactoringDirectory + "\\" + Globals.FILE_RESULTS, Globals.FILE_PREFIX_RESULTS_EXPORTED);
                        File.WriteAllText(FactoringDirectory + "\\" + Globals.FILE_RESULTS, string.Empty); //clear out the results file
                    }
                }
                

            }// we have completed looking in all factoring directories

            //Debug.WriteLine("The final result list is ");
            //Debug.WriteLine(string.Join(Environment.NewLine, FinalResultsToExport.ToArray()));

            if (FinalResultsHeldBack.Count > 0)
                File.WriteAllLines(Globals.CreateFileName(Globals.DIR_MISFIT_BACKUPS + "\\" + Globals.FILE_PREFIX_RESULTS_HELDBACK, Globals.FILE_EXT_TXT), FinalResultsHeldBack);
           
            
            return Globals.SanitizeList(FinalResultsToExport, Globals.PHRASE_FACTOR, Globals.SanitizeModes.CONTAINS);

        }



       

       


       




        private void BalanceWorkViaAutomation()
        {
            if (globals.cfg.settingAutoBalanceDifferenceTrigger > 0)
            {
                try
                {
                    if (BalanceWorkCore(globals.cfg.settingFactoringDirectories, GetWorkToDoCountsFromGrid(dgv1), globals.cfg.settingAutoBalanceDifferenceTrigger, false))
                    {
                        UpdateGridStats();//only re-update the stats if rebalance was done.
                    }
                }
                catch (Exception E)
                {
                    PopSafeErrorForm("Error during work balance " + E.Message);
                }
            }
        }


        private void FetchWorkViaExternalCommand()
        {
            string result = string.Empty;
            if (globals.cfg.settingWorkFetchExternalCommand.Length > 0)
            {
                ProcessStartInfo PSI = new ProcessStartInfo();
                PSI.RedirectStandardOutput = false;
                PSI.RedirectStandardError = true;
                PSI.UseShellExecute = false;
                PSI.FileName = globals.cfg.settingWorkFetchExternalCommand;
                PSI.Arguments = globals.cfg.settingWorkFetchExternalCommandArguments;

                Process P = new Process();
                P.StartInfo = PSI;
                try
                {

                    P.Start();
                    // Do not wait for the child process to exit before
                    // reading to the end of its redirected error stream.

                    // Read the error stream first and then wait.
                    string error = P.StandardError.ReadToEnd();

                    P.WaitForExit();
                    result = P.ExitCode.ToString();
                    if (globals.cfg.settingEmailPreAssignRunResult && globals.cfg.isEmailConfigured())
                        globals.GlobalSendEmail(globals.cfg.settingEmailSubjectExtenralFetchResults, "MISFIT ran " + P.StartInfo.FileName + " result= " + result);
                }
                catch (Exception E)
                {
                    Globals.simpleMessageBox("Error fetching working work with External command:" + E.Message);

                }
                
            }

        }




        private void AssignWorkViaAutomation()
        {
            if (globals.cfg.settingAssignWorkWhenGHZdaysToDoDropsBelow > 0 )
            {
                if (Convert.ToInt32(this.GHZDaysWorkToDo) < globals.cfg.settingAssignWorkWhenGHZdaysToDoDropsBelow)
                {
                    try
                    {

                        MergeWork(false, globals.cfg.settingMaxGhDzPerAutoAssignEvent);
                    }
                    catch (Exception E)
                    {

                        PopSafeErrorForm("Error during AssignWorkViaAutomation\r\n" + E.Message);


                    }
                }

            }

        }



        private void ProcessTimedGridStatsUpdate()
        {

            timer1UpdateStatsCounter++;
            //Debug.WriteLine("update GridStats counter is " + timer1UpdateStatsCounter.ToString());
            if (timer1UpdateStatsCounter >= globals.cfg.settingUpdateStatsInterval * 55)  //interval is 1000ms so multiply by 60 to get minutes
            {
                UpdateGridStats();
                AssignWorkViaAutomation();
                BalanceWorkViaAutomation();
            }
        }

        private FileInfo GetNewestCheckPointWrapper(string PathBeingChecked)
        {

            List<FileInfo> fiList = new List<FileInfo>();
            FileInfo fi0 = GetNewestCheckPointFile(PathBeingChecked, "M*.ckp", "M_FAUX(README).ckp");
            FileInfo fi2 = GetNewestCheckPointFile(PathBeingChecked, "Results*.txt", "Results_FAUX(README).txt");
            fiList.Add(fi0);
            fiList.Add(fi2);
            FileInfo fiFinal = fiList[0];//get this initialzed

            foreach (FileInfo FileToCompare in fiList)
            {
                if (FileToCompare.LastWriteTime > fiFinal.LastWriteTime)
                    fiFinal = FileToCompare;
            }

            return fiFinal;
        }


        private FileInfo GetNewestCheckPointFile(string PathToLookIn, string FileMask, string FauxFileName)
        {
           
            string FauxFileNameFullPath = PathToLookIn + "\\" + FauxFileName;

            FileInfo fiFinal = null;


            string[] files = Directory.GetFiles(PathToLookIn, FileMask);


            if (files.Length == 0)
            {
                File.WriteAllText(FauxFileNameFullPath, "Placeholder file created when NO actual CKP files were found to be active. It is used to track aging of inactivity in this directory. Do you have a misconfigured instance preventing MFAKTx from working in this directory or have MFAKTx checkpointing turned off? This faux file will be auto-deleted when a real .CKP file finally arrives in this directory.");
                files = Directory.GetFiles(PathToLookIn, FileMask);//re-populate the files array.
            }



            foreach (string file in files)
            {

                if (fiFinal == null)
                {
                    fiFinal = new FileInfo(file);
                }
                else if (File.GetLastWriteTime(file) > fiFinal.LastWriteTime)
                {
                    fiFinal = new FileInfo(file);
                }

            }

            if (fiFinal.Name != FauxFileName && File.Exists(FauxFileNameFullPath))
            {
                File.Delete(FauxFileNameFullPath);  // clear out our fake CKP file since a real .ckp file exists.
            }

            return fiFinal;
        }
        public void TestForStalledProcesses(bool SendEmail)
        {
            StringBuilder StallInfo = new StringBuilder();
            
            for (int x = 0; x < globals.cfg.settingFactoringDirectories.Count; x++)
            {
               FileInfo F=GetNewestCheckPointWrapper(globals.cfg.settingFactoringDirectories[x].ToString());
               Debug.WriteLine ("Testing " + F.FullName + " as the oldest file. " + F.LastWriteTime.ToString());
             if (F.LastWriteTime.AddMinutes(globals.cfg.settingMinsOldBeforeProcessStallAlarm) < DateTime.Now)
               {
                   Debug.WriteLine(F.FullName + " is old");
                   dgv1[0, x].Style.BackColor = Color.Red;
                   string filestuff = F.FullName + " is stalled since " + F.LastWriteTime;
                       
                   PopSafeErrorForm(filestuff);
                   StallInfo.AppendLine(filestuff);                  
                   
               }
               else
               {
                    Debug.WriteLine(F.FullName + " is NOT old");
                    dgv1[0, x].Style.BackColor = Color.Empty;
                  
               }

            }
            if (StallInfo.Length > 0)  //some global actions
            {
                lblStall.Visible = true;
                
                File.WriteAllText(Globals.CreateFileName(Globals.DIR_MISFIT_BACKUPS + "\\" + Globals.FILE_PREFIX_STALLED_PROCESS,Globals.FILE_EXT_TXT),StallInfo.ToString());
                if (globals.cfg.settingStalledProcessSendEmailAlert && !EmailSentDueToStalledProcess && SendEmail)
                {
                    EmailSentDueToStalledProcess = true;
                    globals.GlobalSendEmail(globals.cfg.settingEmailSubjectStalledProcess, StallInfo.ToString());
                }
            }
            else
            {
                EmailSentDueToStalledProcess = false;//clear the flag so an email can be sent the next time a stall is detected.
                lblStall.Visible = false;

            }
        }


        public void ProcessStallDetection()
        {


           
                       
            
           if (globals.cfg.settingMinsOldBeforeProcessStallAlarm == 0 || StallDetectionIsSuspended) 
            {
                
                lblStalledProcessDetectionStatus.Visible = true;
                return;
            }
            try
            {
                lblStalledProcessDetectionStatus.Visible = false;
                timer1StallTestCounter++;
                //Debug.WriteLine("processStallDetectionCounter " + timer1StallTestCounter.ToString());

                //checking the SuspendAutomationTill against the current time allows for a grace period after automation resumes
               if (timer1StallTestCounter >= 276 && SuspendAutomationUntil.AddMinutes(30) < DateTime.Now)  //~5 mins between tests, but allow a grace period after Automation Resumes
                {
                    Debug.WriteLine("About to test for stalled process....");
                    timer1StallTestCounter = 0;
                    TestForStalledProcesses(true);
                }
            }
            catch (Exception E)
            {
                timer1StallTestCounter = 0;
                PopSafeErrorForm("Error during stall detection:" + E.Message);
            }


        }


      
        private void timer1_Tick(object sender, EventArgs e)
        {

            // Debug.WriteLine("Timer 1 is ticking ");

            if (globals.cfg.settingUpdateStatsInterval == 0)
            {
                //Debug.WriteLine("Update stats interval is disabled... No automation will be processed");
                lblAutomationSuspended.Text = "Automation is turned OFF!";
                lblAutomationSuspended.Visible = true;
                return;
            }


            if (globals.cfg.settingEnableSchedules)
                lblSchedulerDisabled.Visible = false;
            else
                lblSchedulerDisabled.Visible = true;

            if (DateTime.Now < SuspendAutomationUntil)
            {
                lblAutomationSuspended.Text = "Automation Suspended -> " + SuspendAutomationUntil.ToString("MM/dd/yyyy h:mm tt");
                lblAutomationSuspended.Visible = true;
                return;

            }
            else
            {
                lblAutomationSuspended.Visible = false;
            }

          

           


            timer1.Enabled = false;  //suspend timer to ensure no double calls occur if any process takes a longer than timer interval.
            try
            {
                ProcessTimedGridStatsUpdate();

                ProcessStallDetection();
               
                    ProcessScheduledEvents();
                    ProcessAutoWorkFetch();
                    ProcessAutoLogPurge();

                    if (globals.LastGIOMUploadDetectedResultsNotNeeded)
                    {
                        PopSafeErrorForm("GIMPS reported 'results not needed' during upload. Check WEB_LOGS for details.");
                        globals.LastGIOMUploadDetectedResultsNotNeeded = false;

                    }

            }
            catch (Exception E)
            {

                PopSafeErrorForm("Error in Timer1\r\n" + E.Message);

            }
            timer1.Enabled = true;



        }

        public bool isMFAKTxRunning()
        {
           //return true if any process int he list is running
            foreach (string pname in globals.cfg.settingStopProcessList)
            {
                if (Globals.GetCountProcessRunningByName(pname) > 0)
                    return true;
            }
            return false;
        }

        public bool ProcessLaunch()
        {
            bool launched = false;
            //caller must wrap call to processLaunch in Try/Catch
            if (!isMFAKTxRunning())
            {
                for (int i = 0; i <= globals.cfg.settingStartProcessList.Count - 1; i++)
                {

                    string pname = globals.cfg.settingStartProcessList[i].ToString();

                    string workingDir = string.Empty;
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.FileName = pname;
                    if (globals.cfg.settingSetProcessWorkingDirectory)
                    {
                        if (pname.Contains("\\"))
                        {
                            workingDir = pname.Substring(0, pname.LastIndexOf('\\'));
                            //Debug.WriteLine(workingDir);
                            pInfo.WorkingDirectory = workingDir;
                        }


                    }
                    //Debug.WriteLine(pInfo.WorkingDirectory);
                    System.Diagnostics.Process.Start(pInfo);
                    launched = true;
                    StallDetectionIsSuspended = false;
                    if (i < globals.cfg.settingStartProcessList.Count - 1) //don't sleep after LAST process is launched
                        Globals.Sleep(globals.cfg.settingStartProcessDelay * 1000);
                }
            }
            return launched;
        }
        private void BatchStart()
        {
            DialogResult dres = DialogResult.Yes;

            string itemToStart = string.Empty;

            //if (globals.ConfigStartProcessList.Count == 0)
            if (globals.cfg.settingStartProcessList.Count == 0)
            {
                Globals.simpleMessageBox("Nothing configured!");
                return;
            }


            //if (globals.cfg.settingShowConfirmationDialogs)
            if (globals.cfg.settingShowConfirmationDialogs)
            {
                string temp = string.Empty;
                //foreach (string items in globals.ConfigStartProcessList)
                foreach (string items in globals.cfg.settingStartProcessList)
                {
                    temp += items + "\r\n";
                }


                dres = MsgBox.Show("Start Process? \r\n" + temp, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dres != DialogResult.Yes)
                    return;
            }



            try
            {
                if (!ProcessLaunch())
                    throw new Exception("Process Launch Failed");
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }


        }








        private void SendCTRL()
        {

            // if (globals.ConfigStopProcessList.Count == 0)
            if (globals.cfg.settingStopProcessList.Count == 0)
            {
                Globals.simpleMessageBox("MFAKTx Stop Process List is not configured!");
                return;
            }

            if (!isMFAKTxRunning())
            {
                Globals.simpleMessageBox("MFAKTx is not running!");
                return;
            }

            string p = string.Empty;
            const string signalApp = Globals.APP_CTRLC_SIGNAL;

            DialogResult dres = DialogResult.Yes;

            if (globals.cfg.settingShowConfirmationDialogs)
            //if (globals.cfg.settingShowConfirmationDialogs)
            {

                string temp = string.Empty;
                //foreach (string items in globals.ConfigStopProcessList)
                foreach (string items in globals.cfg.settingStopProcessList)
                {
                    temp += items + "\r\n";
                }
                dres = MsgBox.Show("Send CTRL-C to \r\n" + temp, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }



            if (dres == DialogResult.Yes)
            {


                try
                {
                    if (!File.Exists(signalApp))
                        throw new Exception(signalApp + " NOT FOUND!!");

                    if (!ProcessStop())
                        Globals.simpleMessageBox("Process CTRL-SIGNAL failed");



                }
                catch (Exception E)
                {

                    Globals.simpleMessageBox(E.Message + "\r\n" + p);

                }
            }






        }



        private void LaunchCustomURL()
        {
            try
            {
                // ProcessStartInfo Psi = new ProcessStartInfo(globals.ConfigLaunchURL);
                ProcessStartInfo Psi = new ProcessStartInfo(globals.cfg.settingLaunchURL);
                Psi.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(Psi);
            }
            catch (Exception E)
            {

                Globals.simpleMessageBox("Error Launching URL\r\n" + E.Message);
            }

        }




        public void MergeWork(bool UseModalDialogs, int MaxGhDzPerAutoAssignEvent)
        {


            double DrainedGhzDays = 0;
            string ConfiguredWorkToDoFile = string.Empty;
            // load the staged work file into a queue
            // deque in a loop where each item taken off the queue is appended to an array of strings where each array is the string to be appended to each real file.
            // when queue is empty write out all files
            Queue workQueue = new Queue();

            if (globals.cfg.settingUseWorkToDoAdd)
                ConfiguredWorkToDoFile = Globals.FILE_WORK_TODO_ADD;
            else
                ConfiguredWorkToDoFile = Globals.FILE_WORK_TODO;
                    
            
            
            if ((globals.cfg.settingShowConfirmationDialogs && UseModalDialogs) || (globals.cfg.settingWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz > 0 && UseModalDialogs))
            {
                DialogResult res = MsgBox.Show("Assign out configured GhDz work staged in " + Globals.FILE_MISFIT_WORK_TODO + " TO " + ConfiguredWorkToDoFile + " files?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }


            //
            try
            {
                
                if (File.Exists(Globals.FILE_MISFIT_WORK_TODO))
                {
                    if (globals.cfg.settingUseWorkToDoAdd)
                    {
                        List<string> existingAddFiles = GetLisOfWorkToDoAddFiles(PathTypes.Any);
                        if (existingAddFiles.Count > 0)
                        {
                            string errorMessage = "Work cannot be assigned due to unprocessed " + Globals.FILE_WORK_TODO_ADD + " files!\r\n" + Globals.ListStringToString(existingAddFiles);

                            if (UseModalDialogs)
                                Globals.simpleMessageBox(errorMessage);
                            else
                                PopSafeErrorForm(errorMessage);

                            return;
                        }
                    }
                    
                    
                    
                    //o//FileLock.MultiLockByDirectoryList(globals.cfg.settingFactoringDirectories, Globals.FILE_WORK_TODO);

                    
                    List<string> StagedWork = Globals.FileReadAllLinesIntoList(Globals.FILE_MISFIT_WORK_TODO);
                    foreach (string line in StagedWork)
                    {
                        string s = line.Trim();
                        s = s.Trim();
                        //Debug.WriteLine(s);
                        if (s.Length > 0 && s.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                        {
                            workQueue.Enqueue(s);

                        }

                    }




                    //create an array of string builders: one for each file to write to
                    StringBuilder[] sbz = new StringBuilder[lstDirectories.Items.Count];
                    for (int k = 0; k <= sbz.Length - 1; k++)
                    {
                        sbz[k] = new StringBuilder();
                    }

                    int counter = 0;
                    do
                    {
                        string DequedData = (workQueue.Dequeue().ToString());
                        string[] splitter = DequedData.Split(',');
                        DrainedGhzDays += Globals.CalcGHDZ(Convert.ToInt32(splitter[1]), Convert.ToInt32(splitter[2]), Convert.ToInt32(splitter[3]));
                        Debug.WriteLine("ghzdz to be assigned out " + DrainedGhzDays.ToString());
                        sbz[counter].Append(DequedData + "\r\n");  //write one line for each file round robin

                        counter++;
                        if (counter >= sbz.Length)//roll over to back to the first worker to assign work to 
                            counter = 0;

                    } while (workQueue.Count > 0 && DrainedGhzDays <= MaxGhDzPerAutoAssignEvent);


                    for (int k = 0; k <= sbz.Length - 1; k++)  //write out the new balanced work.
                    {
                        string error = string.Empty;
                        Globals.backupFile(lstDirectories.Items[k] + "\\" + Globals.FILE_WORK_TODO, "ASSIGN_WORK"); //back up this file no matter what.
                        File.AppendAllText(lstDirectories.Items[k] + "\\" + ConfiguredWorkToDoFile, "\r\n" + sbz[k].ToString());

                    }

                    //rewrite the MISFITWWrkToDo with any left over rows

                    List<string> LeftOvers = new List<string>();
                    while (workQueue.Count > 0)
                    {
                        LeftOvers.Add(workQueue.Dequeue().ToString());  //write one line for each file round robin

                    }
                    if (LeftOvers.Count > 0)
                    {

                        Globals.FileReplace_ListToFile(Globals.FILE_MISFIT_WORK_TODO, LeftOvers);

                    }
                    else
                    {
                        File.Delete(Globals.FILE_MISFIT_WORK_TODO);//get rid of a zero byte file.
                    }

                    //o//FileLock.MultiUnlock();
                    UpdateGridStats();
                    if (globals.cfg.settingShowConfirmationDialogs && UseModalDialogs)
                        Globals.simpleMessageBox("Work assigned OK!.");

                }
                else
                {
                    string error = Globals.FILE_MISFIT_WORK_TODO + " has no entries! Use Add Work first.";
                    if (UseModalDialogs)
                        Globals.simpleMessageBox(error);

                }
            }
            catch (Exception E)
            {
                if (UseModalDialogs)
                    Globals.simpleMessageBox(E.Message);
                else
                    PopSafeErrorForm(E.Message);
            }
            finally
            {

                //o//FileLock.MultiUnlock();
            }

        }



        


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Globals.simpleMessageBox("MFAKTx Internet Service Function Integration Tool (MISFIT)\r\nConcept and original coding by SWL551\r\nThis fork by TBUSBY\r\nAdditional contributions by\r\nJMLX\r\nNORMANRKN\r\nKLADNER\r\nCHALSALL\r\nKRACKER\r\nM.WIEDMANN\r\nFLASHJH\r\nDUBSLOW\r\nBDOT\r\nComments to the MISFIT subforum at\r\nmersenneforum.org/forumdisplay.php?f=103\r\nor\r\ngithub.com/brubsby/MISFIT/issues");
        }



        private void startBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatchStart();
        }

        private void sendCTRLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCTRL();
        }



        private void updateStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateGridStats();
        }

        private void addWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWork();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void balanceWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BalanceWorkWithUI(true);
        }

       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.Yes;
            if (globals.cfg.settingShowConfirmationDialogs)
                res = MsgBox.Show("Exit " + Globals.VERSION_MISFIT_STRING, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateGridStats();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddWork();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {

            BalanceWorkWithUI(false);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                bool LaunchExportUrl=false;
                DialogResult res = DialogResult.Yes;
                if (globals.cfg.settingShowConfirmationDialogs)
                    res = MsgBox.Show("Export results?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                 {
                    if(globals.cfg.settingExportURL.Length > 5)
                        LaunchExportUrl=true;
                    
                    if( !ExportResultsList_Wrapper(globals.cfg.settingHoldBackPartialResults, globals.cfg.isExportToGIMPSEnabled(), globals.cfg.settingShowExportInExternalViewer, false,LaunchExportUrl ))
                                Globals.simpleMessageBox("Nothing to Export!");
                    
                        
                 }

            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
                       
        }

        private void launchURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchCustomURL();
        }

        private void btnLaunchURL_Click(object sender, EventArgs e)
        {
            LaunchCustomURL();
        }

        private void btnMergeWork_Click(object sender, EventArgs e)
        {

            // MergeWork(true, Globals.DEFAULT_MAX_WORK_TO_ASSIGN);
            MergeWork(true, globals.cfg.settingMaxGhDzPerAutoAssignEvent);
        }

        private void mergeWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeWork(true, Globals.DEFAULT_MAX_WORK_TO_ASSIGN);
        }



        private List<int> GetWorkToDoCountsFromGrid(DataGridView grid)
        {
            List<int> counts = new List<int>();


            for (int dgrow = 0; dgrow <= grid.Rows.Count - 2; dgrow++) //look at all the values in the workTo column and find the worker with the highest and the worker with the lowest
            {
                //be sure we not looking at the last row in the grid which is the "totals row"
                counts.Add(Convert.ToInt32(dgv1["ToDo", dgrow].Value));

            }

            return counts;
        }



        private bool WorkNeedsBalancing(List<int> WorkToDoCounts, int differenceTrigger)
        {
            bool NeedsBalance = false;
            int lowestValue = int.MaxValue;
            int highestValue = 0;

            for (int i = 0; i < WorkToDoCounts.Count; i++) //look at all the values in the workTo column and find the worker with the highest and the worker with the lowest
            {
                Debug.WriteLine("Looking at " + WorkToDoCounts[i].ToString());
                int currentValue = WorkToDoCounts[i];
                if (currentValue > highestValue)
                    highestValue = currentValue;
                if (currentValue < lowestValue)
                    lowestValue = currentValue;
            }
            int difference = highestValue - lowestValue;
            if (difference >= differenceTrigger)
            {

                NeedsBalance = true;
            }
            else
            {
                NeedsBalance = false;

            }



            return NeedsBalance;
        }


        private bool BalanceWorkCore(ArrayList DirsToBalance, List<int> WorkToDoCounts, int differenceTrigger, bool ForceBalance)
        {

            

            if (!ForceBalance && !WorkNeedsBalancing(WorkToDoCounts, differenceTrigger))
                return false;



            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "exponent";

            column.ReadOnly = false;
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "fileIndex";
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "inFileRowIndex";
            column.Unique = false;
            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "content";
            column.Unique = false;
            table.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["exponent"];
            table.PrimaryKey = PrimaryKeyColumns;
            int outInt = 0;
            int inFileRowIndexer = -1;

            string FullExponentRange = string.Empty;
            //
            DateTime[] LastFileModTimes = new DateTime[DirsToBalance.Count];

            //o//FileLock.MultiLockByDirectoryList(DirsToBalance, Globals.FILE_WORK_TODO);//lock all worktodofiles


            for (int j = 0; j <= DirsToBalance.Count - 1; j++)
            {
                LastFileModTimes[j] = File.GetLastWriteTime(DirsToBalance[j].ToString() + "\\" + Globals.FILE_WORK_TODO);
                string[] filecontents = File.ReadAllLines(DirsToBalance[j].ToString() + "\\" + Globals.FILE_WORK_TODO);
                inFileRowIndexer = 0;
                foreach (string factorRow in filecontents)
                {

                    string f = factorRow.Trim();
                    string[] splitter = f.Split(',');
                    if (splitter.Length == 4 && f.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                    {
                        if (int.TryParse(splitter[1], out outInt))
                        {
                            DataRow r = table.NewRow();

                            if (globals.cfg.settingDuplicateAssignmentsDetectionIncludeBitLevel)
                                FullExponentRange = outInt.ToString() + splitter[2] + splitter[3];
                            else
                                FullExponentRange = outInt.ToString();





                            Debug.WriteLine("full exponent range is " + FullExponentRange);
                            r["exponent"] = FullExponentRange;
                            r["fileIndex"] = j;
                            r["inFileRowIndex"] = inFileRowIndexer;
                            r["content"] = f;
                            inFileRowIndexer++;
                            try
                            {
                                table.Rows.Add(r);
                            }
                            catch (ConstraintException x)
                            {
                                Debug.WriteLine("Duplicate Exponent " + FullExponentRange.ToString() + x.Message);
                                PopSafeErrorForm("Balancer tossed duplicate exponent:" + splitter[1] + "," + splitter[2] + "," + splitter[3]);
                            }
                            catch (Exception E)
                            {
                                PopSafeErrorForm("Error adding row to table: " + E.Message);
                            }


                        }
                        else
                        {
                            PopSafeErrorForm("Balancer tossed invalid exponent: " + splitter[1]);
                        }
                    }
                    else
                    {
                        if (factorRow.Length > 0)  //don't show error for blank rows.
                            PopSafeErrorForm("Balancer tossed invalid structure " + factorRow);
                    }//else it a junk row!

                }

            }

            //foreach (DataRow dr in table.Rows)
            //{
            //    Debug.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString());
            //}


            StringBuilder[] sbz = new StringBuilder[DirsToBalance.Count];
            for (int k = 0; k <= sbz.Length - 1; k++)
            {
                sbz[k] = new StringBuilder();  //init the string builders

                DataRow[] foundRow0 = table.Select("fileIndex=" + k.ToString() + " and inFileRowIndex=0");
                if (foundRow0.Length > 0)//load up the string builder with the first row for the specified file
                    sbz[k].AppendLine(foundRow0[0]["content"].ToString());
            }


            DataRow[] foundAllRows = table.Select("inFileRowIndex > 0", "inFileRowIndex"); //now get all the rows that were NOT the top row and round robin them out
            int sbzIndexer = 0;
            for (int i = 0; i <= foundAllRows.Length - 1; i++)
            {
                Debug.WriteLine(foundAllRows[i]["content"].ToString());
                sbz[sbzIndexer].AppendLine(foundAllRows[i]["content"].ToString());
                sbzIndexer++;
                if (sbzIndexer == sbz.Length)
                    sbzIndexer = 0;

            }
            for (int k = 0; k <= sbz.Length - 1; k++)  //write out the new balanced work.
            {
                string error = string.Empty;

                if (File.GetLastWriteTime(DirsToBalance[k] + "\\" + Globals.FILE_WORK_TODO) != LastFileModTimes[k])
                    PopSafeErrorForm(DirsToBalance[k] + "\\" + Globals.FILE_WORK_TODO + " changed while BALANCE was underway!");

                Globals.backupFile(DirsToBalance[k] + "\\" + Globals.FILE_WORK_TODO, "BALANCE_WORK");//backup each file before we overwrite it.
                File.WriteAllText(DirsToBalance[k] + "\\" + Globals.FILE_WORK_TODO, sbz[k].ToString());
            }

            //o//FileLock.MultiUnlock();
            Debug.WriteLine("bye");
            return true;

        }




        private void BalanceWorkWithUI(bool forceBalance)
        {
            bool results = false;
            string message = string.Empty;
            DialogResult res = DialogResult.Yes;

            if (GetLisOfWorkToDoAddFiles(PathTypes.Any).Count > 0)
            {
                Globals.simpleMessageBox(Globals.FILE_WORK_TODO_ADD + " files exist so work cannot be balanced at this time!");
                return;
            }
            //always inform the user and get consent
            res = MsgBox.Show("This feature will balance the count of rows in all " + Globals.FILE_WORK_TODO + " files.\r\nAny duplicates assignments found will be removed.\r\nContinue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {


                try
                {
                    //UpdateGridStats();
                    results = BalanceWorkCore(globals.cfg.settingFactoringDirectories, GetWorkToDoCountsFromGrid(dgv1), Globals.MIN_WORK_BALANCE_DIFFERENCE_TRIGGER, forceBalance);
                    if (results)
                    {
                        UpdateGridStats();
                        message = "Balance/Scrub Complete";
                    }
                                        
                        Globals.simpleMessageBox(message);

                }
                catch (Exception E)
                {
                    Globals.simpleMessageBox(E.Message);
                }

            }
        }


        public List<string> AppendPhraseToListItems(List<string> listToModify, string phraseToAppend)
        {
            List<string> RebuiltList = new List<string>();
            foreach (string item in listToModify)
            {
                RebuiltList.Add(item + phraseToAppend);
            }

            return RebuiltList;

        }


        public void CheckForDuplicatesGlobally(bool assessBitLevel)
        {
            Hashtable hashT = new Hashtable();
            //int counter = 0;
            StringBuilder sbz = new StringBuilder();
            List<string> TempList = new List<string>();
            List<string> Assignments = new List<string>();
            bool duplicatesFound = false;
            try
            {
                TempList = Globals.FileReadAllLinesIntoList(Globals.FILE_MISFIT_WORK_TODO);
                Assignments = AppendPhraseToListItems(TempList, "," + Globals.FILE_MISFIT_WORK_TODO);
                foreach (string path in globals.cfg.settingFactoringDirectories)
                {

                    TempList = Globals.FileReadAllLinesIntoList(path + "\\" + Globals.FILE_WORK_TODO);
                    Assignments.AddRange(AppendPhraseToListItems(TempList, "," + path + "\\" + Globals.FILE_WORK_TODO));

                }

                Assignments.Sort();

                foreach (string assignment in Assignments)
                {
                    string a = assignment.Trim();
                    string determination = string.Empty;
                    if (assignment.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                    {

                        Debug.WriteLine(a);

                        try
                        {
                            string[] splitter = a.Split(',');
                            if (assessBitLevel)
                                hashT.Add(splitter[1] + splitter[2] + splitter[3], string.Empty);
                            else
                                hashT.Add(splitter[1], string.Empty);

                        }
                        catch (System.ArgumentException)
                        {
                            // duplicates += workingPath + "--->" + workingLine + "\r\n";
                            determination = ",<---- D U P L I C A T E";
                            duplicatesFound = true;
                        }

                        sbz.AppendLine(a.Substring(a.IndexOf(',') + 1) + determination); //drop the Factor= phrase


                    }

                }

                if (duplicatesFound)
                {
                    File.WriteAllText(Globals.FILE_DUPLICATE_WORK_REPORT, sbz.ToString());
                    Globals.Sleep(512);
                    Process.Start(Globals.FILE_DUPLICATE_WORK_REPORT);
                }
                else
                {
                    Globals.simpleMessageBox("No duplicates found in active worker(s) and staged work. (Yeah!)");
                }

            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }




        }


        public void CheckForDuplicates()
        {
            Hashtable hashT = new Hashtable();
            int counter = 0;
            string workingPath = string.Empty;
            string workingLine = string.Empty;
            string duplicates = string.Empty;
            try
            {
                foreach (string path in lstDirectories.Items)
                {
                    workingPath = path;
                    string[] lines = File.ReadAllLines(path + "\\" + Globals.FILE_WORK_TODO);

                    foreach (string line in lines)
                    {
                        workingLine = line.Trim();
                        if (workingLine.Length > 0)
                        {
                            try
                            {
                                string[] splitter = workingLine.Split(',');
                                //hashT.Add(splitter[1], counter);  //just the exponent
                                hashT.Add(splitter[1] + splitter[2] + splitter[3], string.Empty);
                            }
                            catch (System.ArgumentException)
                            {
                                duplicates += workingPath + "--->" + workingLine + "\r\n";
                            }
                        }
                    }

                    counter++;

                }


                if (File.Exists(Globals.FILE_MASTER_EXPORT_CSV))
                {
                    string[] lines = File.ReadAllLines(Globals.FILE_MASTER_EXPORT_CSV);
                    foreach (string line in lines)
                    {
                        workingLine = line.Trim();
                        if (workingLine.Length > 0)
                        {
                            try
                            {
                                string[] splitter = workingLine.Split(',');
                                hashT.Add(splitter[1], counter);  //just the exponent
                            }
                            catch (System.ArgumentException)
                            {
                                duplicates += Globals.FILE_MASTER_EXPORT_CSV + "--->" + workingLine + "\r\n";
                            }
                        }
                    }

                    counter++;
                }



                if (duplicates != string.Empty)
                {
                    string m = " ************DUPLICATE DETECTION REPORT ************\r\n\r\nREPORT SHOWS WHERE DUPLICATE EXPONENTS ARE LOCATED\r\n\r\n";
                    m += duplicates;
                    //Globals.simpleMessageBox("The following duplicates were detected\r\n" + duplicates);
                    File.WriteAllText("DuplicateReport.txt", m);
                    Process.Start("DuplicateReport.txt");
                }
                else
                {
                    Globals.simpleMessageBox("No Duplicates Found!");
                }

            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }




        }
        private void checkForWorkDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForDuplicatesGlobally(globals.cfg.settingDuplicateAssignmentsDetectionIncludeBitLevel);
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Globals.simpleMessageBox(dgv1[e.ColumnIndex,e.RowIndex].Value.ToString());
        }

        
       
        private void mersenneUncreditedStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.mersenne.ca/");
        }

        private void gIMPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.mersenne.org/");
        }

        private void theGPU272ProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.gpu72.com/");
        }

        private void mersenneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://mersenneforum.org/index.php");
        }

        private void mersenneMISFITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.mersenneforum.org/forumdisplay.php?f=103");
        }

        private void issueReportMISFITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://github.com/brubsby/MISFIT/issues");
        }




        private void editPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://notepad-plus-plus.org/");
        }


        private void LaunchLink(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }


        private void lstDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstDirectories_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (lstDirectories.SelectedItem != null)
            //    {
            //        frmFileViewer frm = new frmFileViewer();
            //        frm.globals = this.globals;
            //        frm.FileViewDirectory = lstDirectories.SelectedItem.ToString();
            //        frm.Show();
            //    }
            //}
            //catch
            //{
            //}


            if (lstDirectories.SelectedItem != null )
            {
                try
                {
                    Process.Start(lstDirectories.SelectedItem.ToString());
                }
                catch(Exception E)
                {
                    Globals.simpleMessageBox("Error processing path:" + E.Message);
                }
                
            }

        }

        private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("msinfo32.exe");
        }

        private void ReloadWorkToDo()
        {
            bool hadFailure = false;
            foreach (string directory in globals.cfg.settingFactoringDirectories)
            {

                if (!isRemotePath(directory) && File.Exists(directory + "\\" + Globals.FILE_WORK_TODO_SUSPENDED))
                {
                    FileInfo fi = new FileInfo(directory + "\\" + Globals.FILE_WORK_TODO);
                    if (fi.Length > 0)
                    {
                        Globals.simpleMessageBox("Resume from WRAP-UP detected non-zero byte file:\r\n" + fi.FullName + "\r\nYou must manually clean this up before using MISFIT!\r\nBYE!" );
                        hadFailure = true;
                    }
                    else
                    {
                        Globals.SplitFileContentBetweenFiles(directory, Globals.FILE_WORK_TODO_SUSPENDED, Globals.FILE_WORK_TODO, 0);
                    }

                }

            }

            if (hadFailure)
                Application.Exit();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine("Timer2");
            //this is basically the extended Form startup routine. Doing things here allows the form to fully load first, then display any dialogs.
            timer2.Enabled = false;
            Application.DoEvents();
            this.Refresh();
            try
            {
              
                LoadConfigsAtStartup();
                Application.DoEvents();
                if (Directory.Exists(Globals.DIR_MISFIT_BACKUPS)) // ok if dir missing at this time. Later the missing directory is worthy of exception
                    SetProductivityUIValues();
                
                StallDetectionIsSuspended = globals.cfg.settingStartWithStallDetectionSuspended;
                timer1.Enabled = true;
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error during timer2 init " + E.Message);

            }



            if (Globals.VERSION_MISFIT_STRING.Contains("BETA"))
                Globals.simpleMessageBox("BETA VERSION.... DO NOT USE LONG TERM!");

        }

        private void SetProductivityUIValues()
        {
            productivity.FetchProductivityFromDisk();

            if (globals.cfg.settingProductivityShowAverages)
            {
                notifyIcon2.Text = "MISFIT:" + productivity.GetReportBriefAverages;
                lblProductivity1.Text = "GHzDs1d:" + productivity.GetLast1DayValue.ToString("N2");
                lblProductivity7.Text = "GHzDs7a:" + productivity.GetLast7DayAverage.ToString("N2");
                lblProductivity30.Text = "GHzDs30a:" + productivity.GetLast30DayAverage.ToString("N2");
            }
            else
            {
                notifyIcon2.Text = "MISFIT:" + productivity.GetReportBriefTotals;
                lblProductivity1.Text = "GHzDs1d:" + productivity.GetLast1DayValue.ToString("N2");
                lblProductivity7.Text = "GHzDs7d:" + productivity.GetLast7DayValue.ToString("N2");
                lblProductivity30.Text = "GHzDs30d:" + productivity.GetLast30DayValue.ToString("N2");
            }



        }

       

        private void configurationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadConfigForm();
        }

        public void LoadConfigForm()
        {
            timer1.Enabled = false;  //suspend all automation when in the configuraiton editor.
            try
            {
                frmConfig frm = new frmConfig();
                frm.globals = this.globals;
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK && File.Exists(Globals.FILE_MASTER_CONFIG))  //if user did not save any config then skip loading values
                {

                    ApplyConfigs();
                    UpdateGridStats();
                    SetProductivityUIValues();

                }


                timer1.Enabled = true;
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }

        private void InitDataGrid()
        {
            dgv1.Rows.Clear();
            dgv1.Rows.Add(globals.cfg.settingFactoringDirectories.Count);
            dgv1.Rows.Add("Totals", 0, 0, 0, "N/A");
            dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            DataGridViewRow r = new DataGridViewRow();
            r = dgv1.Rows[dgv1.Rows.Count - 1];
            r.DefaultCellStyle.BackColor = Color.Black;
            r.DefaultCellStyle.ForeColor = Color.Yellow;

            int rowcount = dgv1.Rows.Count;
            int maxRowsBeforeScrollBars = 15;


            if (rowcount > maxRowsBeforeScrollBars)
                rowcount = maxRowsBeforeScrollBars;

            dgv1.Height = dgv1.Rows[0].Height * rowcount + 25;

            if (rowcount < maxRowsBeforeScrollBars)
                dgv1.ScrollBars = ScrollBars.None;
            else
                dgv1.ScrollBars = ScrollBars.Vertical;


            Debug.WriteLine(dgv1.Bottom.ToString());
            Debug.WriteLine(panel1.Top.ToString());


            if (this.WindowState == FormWindowState.Normal)
            {
                if (dgv1.Bottom >= panel1.Top)
                {
                    Debug.WriteLine("increasing height");
                    //this.Height = this.Height + Convert.ToInt32(this.Height * .08);
                    this.Height = this.Height + Convert.ToInt32((dgv1.Bottom - panel1.Top) + 10);
                }
            }
            else
                Debug.WriteLine("i am not normal");


        }



        private void ApplyConfigs()
        {
            string section = string.Empty;
            try
            {
                section = "SetUIMode";
                lstDirectories.Items.Clear();
                this.Height = this.form_startup_height;  //put it back to original size if the grid has reduces size due to a reduction on entries.
                section = "LstDirectories";
                foreach (string item in globals.cfg.settingFactoringDirectories)
                {
                    lstDirectories.Items.Add(item);
                }


                if (GetPathCountsByType(globals.cfg.settingFactoringDirectories, PathTypes.Remote) > 0)
                    remoteControlToolStripMenuItem.Visible = true;
                else
                    remoteControlToolStripMenuItem.Visible = false;

                section = "initDataGrid";
                InitDataGrid();
                lblStall.Visible = false;

                section = "ScheduleQueue";
                if (ScheduleName != Globals.PHRASE_DEFAULT_SCHEDULE)
                {
                    Globals.simpleMessageBox("Default Schedule has been loaded");

                    ScheduleName = Globals.PHRASE_DEFAULT_SCHEDULE;
                }
                ScheduleQueue = new Queue(globals.cfg.settingProcessScheduleList);



               
                    section = "Displaying Upload scheme and Pbar";
                    if (globals.cfg.SchedulerHasEventsOfType("UPLOAD_RESULTS") && globals.cfg.settingEnableSchedules)
                    {
                        lblNextAutoUpload.Text = "Automatic results uploading is scheduled.";
                        lblNextAutoUpload.ForeColor = Color.BlueViolet;

                    }
                    else
                    {
                        lblNextAutoUpload.Text = "Automatic results uploading disabled.";
                        lblNextAutoUpload.ForeColor = Color.Red;

                    }
                
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error applying configurations for section [" + section + "] -->" + E.Message);
            }





        }

        

        private void LoadConfigsAtStartup()
        {

            try
            {
                if (globals.cfg.LoadConfigurationFromFile(Globals.FILE_MASTER_CONFIG))
                {

                    if (!Globals.AreMisfitDirectoriesIntact())
                    {
                        Globals.CreateMisfitDirectories();
                        Globals.simpleMessageBox("MISFIT detected missing directories!\r\nThey have been recreated.");

                    }
                    ApplyConfigs();
                    ReloadWorkToDo();
                    UpdateGridStats();

                }
                else
                {

                    LoadConfigForm();

                }
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error Loading Configuration: Please fix or delete " + Globals.FILE_MASTER_CONFIG  + "\r\n" + E.Message);
                Application.Exit();
            }


        }


        private void showBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Globals.DIR_MISFIT_BACKUPS);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }
        }


        private void ShowStagedWork()
        {
            try
            {

                LaunchEditorForm(Globals.FILE_MISFIT_WORK_TODO, false);


            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
        }

        private void showStagedWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStagedWork();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.LaunchHelp();
        }





        private bool ProcessStop()
        {
            //call must wrap this call in try/catch
            bool SentStopSignalOK = false;
            int counter = 0;
            foreach (string pname in globals.cfg.settingStopProcessList)
            {
                Process[] processList = Process.GetProcessesByName(pname);

                if (processList.Length > 0)
                {
                    foreach (Process P in processList)
                    {
                        ProcessStartInfo Pinfo = new ProcessStartInfo(Globals.APP_CTRLC_SIGNAL, P.Id.ToString() + " 0");
                        Pinfo.WindowStyle = ProcessWindowStyle.Minimized;
                        Process.Start(Pinfo);
                        counter++;
                       Globals.Sleep(20);

                    }
                }

            }
            if (counter > 0)
            {
                SentStopSignalOK = true;
                StallDetectionIsSuspended = true;
            }
            else
            {
                SentStopSignalOK = false;
            }
            return SentStopSignalOK;
        }



        private void Form1_Load(object sender, EventArgs e)
        {



            globals = new Globals();
            this.Text = Globals.VERSION_MISFIT_STRING;
            Process P1 = Process.GetCurrentProcess();
            if (Globals.GetCountProcessRunningByName(P1.ProcessName) > 1)
            {
                MessageBox.Show(P1.ProcessName + " is already running!\r\nBYE");
                Application.Exit();
            }
            globals.MISFITStartupTime = DateTime.Now;
            lblStartupTime.Text = "Started:" + globals.MISFITStartupTime.ToString();

            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;  //cannot be done using the form designer tools
            }
            productivity = new Productivity(Globals.DIR_MISFIT_BACKUPS, Globals.FILE_PREFIX_RESULTS_EXPORTED + "*"); Application.DoEvents();
            timer2.Enabled = true;
            this.DesktopLocation = new Point(100, 100);
        }


        private void ProcessScheduledEvents()
        {

            try
            {
                if (!globals.cfg.settingEnableSchedules)
                    return;

                //this process runs on each tick of timer1. The decision to do something is based on dates not timer counts.
                DateTime dt = DateTime.Now;
                //Debug.WriteLine(ScheduleQueue.Peek().ToString());
                if (ScheduleQueue.Count > 0)
                {
                    TimeSpan timeDiff = DateTime.Now - LastScheduledEventExecutedTime;

                    if (timeDiff.TotalSeconds > 62)   //n
                        LastSceduledEventExecuted = string.Empty;  // clean out the marker so that someone running just one event can cycle through it.
                    
                    string item = ScheduleQueue.Dequeue().ToString().ToUpper();
                    ScheduleQueue.Enqueue(item);
                    string[] split_schedule_line = item.Split(',');
                    string sday = split_schedule_line[0];
                    string stime = split_schedule_line[1];
                    string scommand = split_schedule_line[2];
                    string[] split_timecomponent = stime.Split(':');
                    string shour = split_timecomponent[0];
                    string smin = split_timecomponent[1];
                    int schedDayOfWeek = -1;
                    int schedHour = -1;
                    int schedMin = int.Parse(split_timecomponent[1]);
                 


                    if (sday == Globals.SCHEDULE_WILDCARD)
                        schedDayOfWeek = (int)dt.DayOfWeek;  //today
                    else
                        schedDayOfWeek = int.Parse(sday);  //stated day

                    if (shour == Globals.SCHEDULE_WILDCARD)
                        schedHour = (int)dt.Hour;  //this hour
                    else
                        schedHour = int.Parse(shour); //stated hour



                    //debug.Write("Will compare now to schedule of  " + schedDayOfWeek.ToString() + " " + schedHour + " " + schedMin + " " + scommand);

                    
                   if ((int)dt.DayOfWeek == schedDayOfWeek && (int)dt.Hour == schedHour && (int)dt.Minute == schedMin)
                   //if(scommand.Length > 0)
                    {
                        if (item != LastSceduledEventExecuted)
                        {
                            Debug.WriteLine("TIME TO FIRE EVENT:" + scommand); ;
                            if (scommand == "START")
                            {
                                try
                                {
                                    Debug.WriteLine("Firing event " + scommand);
                                    ProcessLaunch();
                                    LastSceduledEventExecuted = item;
                                    LastScheduledEventExecutedTime = DateTime.Now;
                                    StallDetectionIsSuspended = false;
                                 }
                                catch (Exception E)
                                {
                                    //Debug.WriteLine("Exeption in " + scommand);
                                    throw E;
                                }
                            }
                            else if (scommand == "STOP")
                            {
                                try
                                {
                                    Debug.WriteLine("Firing event " + scommand);
                                    ProcessStop();
                                    LastSceduledEventExecuted = item;
                                    LastScheduledEventExecutedTime = DateTime.Now;
                                    StallDetectionIsSuspended = true;
                                }
                                catch (Exception E)
                                {
                                    //Debug.WriteLine("Exeption in " + scommand);
                                    throw E;
                                }
                            }

                            else if (scommand == "UPLOAD_RESULTS")
                            {
                                try
                                {
                                    Debug.WriteLine("Firing event " + scommand);
                                    ExportResultsList_Wrapper(globals.cfg.settingHoldBackPartialResults, true, false, false,false);
                                    LastScheduledEventExecutedTime = DateTime.Now;
                                    LastSceduledEventExecuted = item;
                                }
                                catch (Exception E)
                                {
                                    //Debug.WriteLine("Exeption in " + scommand);
                                    throw E;
                                }
                            }

                            else if (scommand.StartsWith("LOAD_SCHEDULE|"))
                            {
                                try
                                {
                                    string[] load_splitter=scommand.Split('|');
                                    Debug.WriteLine("Firing event " + scommand);
                                    LoadScheduleFromFile(load_splitter[1], false);
                                    LastScheduledEventExecutedTime = DateTime.Now;
                                    LastSceduledEventExecuted = item;
                                }
                                catch (Exception E)
                                {
                                    //Debug.WriteLine("Exeption in " + scommand);
                                    throw E;
                                }
                            }
                            else if (scommand.StartsWith("LOAD_DEFAULT_SCHEDULE"))
                            {
                                try
                                {
                                    ImplementScheduleDefault(false);
                                    LastScheduledEventExecutedTime = DateTime.Now;
                                    LastSceduledEventExecuted = item;
                                }
                                catch (Exception E)
                                {
                                    //Debug.WriteLine("Exeption in " + scommand);
                                    throw E;
                                }
                            }
                            
                        
                            else
                            {
                                throw new Exception("Schedule contains invalid command -> " + scommand);

                            }



                        }
                        else
                        {
                            Debug.WriteLine(scommand + "   was already fired....at " + LastScheduledEventExecutedTime.ToString());

                        }
                    }
                    else
                    {
                      Debug.WriteLine("not time FOR " + item);
                    }

                }
            }

            catch (Exception E)
            {
                //Globals.simpleMessageBox("Error with Task Scheduling " + E.Message);
                globals.cfg.settingEnableSchedules = false;
                PopSafeErrorForm("Error with Task Scheduling! " + E.Message + "\r\n\r\nScheduler is now OFF. Fix schedule definitions and re-enable scheduler.");
                Globals.Sleep(256);

            }

        }


        private void processControlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private void lstGimpsOverall_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void dgv1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void LaunchEditorForm(string fileName, bool isReadOnly)
        {
            if (File.Exists(fileName))
            {
                frmTextEditor frm = new frmTextEditor();
                frm.FileIsReadOnly = isReadOnly;
                DateTime lastFileModDate = File.GetLastWriteTime(fileName);

                frm.FileToEdit = fileName;
                frm.globals = this.globals;
               if(!isReadOnly)
                   //FileLock.LockAdd(fileName);
                frm.ShowDialog();
               if (!isReadOnly)
                  //FileLock.LockRemove(fileName);
               
                if (lastFileModDate != File.GetLastWriteTime(fileName))  //if the file changed update stats
                    UpdateGridStats();
            }
            else
            {
                Globals.simpleMessageBox(fileName + " was not found!");
            }

        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("dblClicked--");

            try
            {

                if (e.RowIndex >= 0 & e.RowIndex < dgv1.RowCount - 1)
                {
                    if ((e.ColumnIndex == 1 || e.ColumnIndex == 2))
                    {
                        //Globals.simpleMessageBox(dgv1[e.ColumnIndex, e.RowIndex].Value.ToString());

                        string fname = lstDirectories.Items[e.RowIndex].ToString() + "\\";
                        bool fileRO = true;

                        switch (e.ColumnIndex)
                        {
                            case 1:
                                fname += Globals.FILE_WORK_TODO;
                                fileRO = false;
                                break;
                            case 2:
                                fname += Globals.FILE_RESULTS;
                                fileRO = true;
                                break;
                        }


                       
                            LaunchEditorForm(fname, fileRO);
                    }
                    else if (e.ColumnIndex == 4 && dgv1[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        string exxp = string.Empty;

                        if (globals.cfg.settingShowWorkingFactorInPhases)
                            exxp = dgv1[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(9);
                        else
                            exxp = dgv1[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(6);

                        if (exxp.Length > 0)
                        {
                            Process.Start(Globals.URI_GIMPS_EXPONENT_HISTORY + "exp_lo=" + exxp + "&exp_hi=" + exxp + "&full=1");
                           Globals.Sleep(1500);
                            Process.Start(Globals.URI_GIMPSca_EXPONENT_HISTORY + exxp);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }

        }

       



        private void LaunchGimpsIOManager(bool ShowAsDialog)
        {
            try
            {
                if (!frmGIMPSuploadResults.IsHandleCreated && globals.cfg.isGIMPScredentialsConfigured())
                {
                    frmGIMPSuploadResults = new frmGIMPSresultsUpload();
                    frmGIMPSuploadResults.globals = this.globals;
                    if (ShowAsDialog)
                        frmGIMPSuploadResults.ShowDialog();
                    else
                        frmGIMPSuploadResults.Show();
                }
            }
            catch (Exception E)
            {
                PopSafeErrorForm("Error loading GIOM\r\n" + E.Message);

            }
        }




        

        private bool MISFITNeedsWork()
        {
            double calc = 0;
            calc = Globals.CalcGhzDaysFromWorkToDoFile(Globals.FILE_MISFIT_WORK_TODO);
            Debug.WriteLine("MisfitNeedsWorkCalcDays " + (int)calc);
            if (calc < globals.cfg.settingWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz)
                return true;
            else
                return false;


        }


      

        private void ProcessAutoLogPurge()
        {
            if (globals.cfg.settingPurgeLogsDaysOld == 0)
                return;

            timer1AutoLogPurge++;
            //Debug.WriteLine("ProcessAutoLogPurge" + timer1AutoLogPurge);
            if (timer1AutoLogPurge >= 21655)//just over 6 hours
            // if (timer1AutoLogPurge >= 300)
            {
                timer1AutoLogPurge = 0;
                PurgeOldLogFiles();

            }

        }

        private void ProcessAutoWorkFetch()
        {
            if (globals.cfg.settingWorkFetchMode == (int)Config.AutoWorkFetchModes.DISABLED)
                return;


            try
            {
                timer1AutoWorkFetch++;
                //Debug.WriteLine("ProcessAutoFetchTimer " + timer1AutoWorkFetch);
                // if (timer1AutoWorkFetch >= globals.cfg.settingWorkFetchMISFITWorkToDoHoursBetweenChecks * 3400 )

                if (timer1AutoWorkFetch == 3600) //3600 seconds  (one hour)

                {
                    timer1AutoWorkFetch = 0;


                    if (MISFITNeedsWork())
                    {

                        
                        this.Cursor = Cursors.WaitCursor;
                        Application.DoEvents();

                        try
                        {
                            UpdateGridStats(); //ensure we emailing the most up-to-date stats
                            LogGlobalWorkStats("PRE-WORK-FETCH", globals.cfg.settingEmailGlobalWorkStatsBeforeWorkFetch && globals.cfg.isEmailConfigured());
                        }
                        catch (Exception EE)
                        {
                            PopSafeErrorForm("Error processing Global Work Stats! " + EE.Message);

                        }



                        List<string> AssignmentList = new List<string>();

                        switch (globals.cfg.settingWorkFetchMode)
                        {

                            case (int)Config.AutoWorkFetchModes.GIMPS:
                                AssignmentList = globals.FetchGimps();
                                Globals.ChangeTOBitLevel(AssignmentList, globals.cfg.settingWorkFetchBitLevelTo);
                                break;

                            case (int)Config.AutoWorkFetchModes.GPU72:
                                AssignmentList = globals.FetchGpu72();
                                break;

                            case (int)Config.AutoWorkFetchModes.EXTERNAL_COMMAND:
                                FetchWorkViaExternalCommand();//won't have a factors list to process inside this method

                                break;

                        }



                        if (AssignmentList.Count > 0)
                        {

                            if (globals.cfg.settingWorkFetchReplaceIdentifierWithDate)
                                Globals.ReplaceFactorLinePlaceHolderWithDate(AssignmentList);

                            AssignmentList.Insert(0, "\r\n");
                            Globals.FileAppend_ListToFile(Globals.FILE_MISFIT_WORK_TODO, AssignmentList);

                        }


                        UpdateGridStats();

                    }

                }
            }
            catch (Exception E)
            {
                timer1AutoWorkFetch = 0;  //if someone reduces the upload interval after we've passed that count we'll end up here.
                PopSafeErrorForm("Error during ProcessAutoFetch:" + E.Message);

            }
            finally
            {
                this.Cursor = Cursors.Default;
                
                Application.DoEvents();
            }
        }





        private void LogGlobalWorkStats(string preamble, bool sendEmail)
        {

            Debug.WriteLine("Writing Work Stats Log");
            string subject = globals.cfg.settingEmailSubjectStats;
            StringBuilder sbz = new StringBuilder();
            try
            {
                sbz.AppendLine(subject + " " + preamble);
                sbz.AppendLine("****** REMAINING WORK INFORMATION ******");
                sbz.AppendLine(lblGhzDaysToDo.Text);
                sbz.AppendLine(lblFactorsToDo.Text);
                sbz.AppendLine(lblStagedWork.Text);
                sbz.AppendLine(lblStagedGhzDays.Text);

                sbz.AppendLine("****** COMPLETED WORK INFORMATION ******");
                sbz.AppendLine(lblGhzDaysCredit.Text);
                sbz.AppendLine(lblFactorsDone.Text);
                sbz.AppendLine(lblFactorsFound.Text);
                sbz.AppendLine(lblResultsKbytes.Text);


                sbz.AppendLine("****** PRODUCTIVITY ******");
                sbz.AppendLine(productivity.GetReportVerbose);




                Globals.LogWebIO("GLOBAL_WORK_REPORT", sbz.ToString(), Globals.FILE_EXT_TXT);
                if (sendEmail)
                    globals.GlobalSendEmail(subject, sbz.ToString());
            }
            catch (Exception E)
            {
                PopSafeErrorForm("Error in LogGlobalWorkStats " + E.Message);
            }

        }

       

       


        

        public void MinimizeToSysTray()
        {

            try
            {
                if (globals.cfg.settingMinimizeToSysTray)
                {
                    if (FormWindowState.Minimized == this.WindowState)
                    {
                        notifyIcon2.Visible = true;
                        notifyIcon2.ShowBalloonTip(10);
                        this.Hide();
                    }
                    else if (FormWindowState.Normal == this.WindowState)
                    {
                        notifyIcon2.Visible = false;
                    }
                }
            }
            catch
            {
                //do nothing
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            
            MinimizeToSysTray();


        }

       

        private void notifyIcon2_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void SuspendAutomationForMinutes(int minutes)
        {

            if (globals.cfg.settingUpdateStatsInterval > 0)
            {
                SuspendAutomationUntil = DateTime.Now.AddMinutes(minutes);
                
            }
            else
            {

                Globals.simpleMessageBox("Automation is already OFF!");
            }

        }

        private void minsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(10);
        }

        private void minsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(30);
        }

        private void minsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(60);
        }

        private void untilMISFITIsRestartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(120);
        }

        private void minsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(5);
        }

        private void UnsuspendAutomation()
        {
            if (SuspendAutomationUntil > DateTime.Now && globals.cfg.settingUpdateStatsInterval > 0)
            {
                SuspendAutomationUntil = DateTime.Now.AddSeconds(-1);
            }
            else
            {
                Globals.simpleMessageBox("Automation is not currently suspended or is turned OFF!");
            }
        }





        private void resumeAutomationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UnsuspendAutomation();
        }

        
        private void forceAStalledProcessTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                TestForStalledProcesses(false);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error:" + E.Message);
            }

            
        }


        private bool isRemotePath(string Path)
        {
            if (Path.StartsWith(@"\\"))  //a unc!
                return true;
            return false;
        }

        private int GetPathCountsByType(ArrayList Directories, PathTypes PathType)
        {

            int countLocal = 0;
            int countRemote = 0;
            int returnCount = 0;

            foreach (string dir in Directories)
            {
                if (isRemotePath(dir))
                    countRemote++;
                else
                    countLocal++;
            }           
            
            switch (PathType)
            {
                case PathTypes.Local:
                    returnCount = countLocal;
                    break;
                   
                case PathTypes.Remote:
                    returnCount = countRemote;
                    break;                       
           }
            return returnCount;
        }



        public void LaunchRemoteControl()
        {

            if (GetPathCountsByType(globals.cfg.settingFactoringDirectories, PathTypes.Remote) > 0)
            {
                if (!frmRemoteControl.IsHandleCreated)
                {
                    frmRemoteControl = new frmRemoteControl();
                    frmRemoteControl.globals = this.globals;
                    frmRemoteControl.Show();
                }
            }
            else
            {

                Globals.simpleMessageBox("No remote paths found in the list of MFAKTx Locations!");
            }
        }

        private void remoteControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchRemoteControl();
        }




        public void ReportOnFileContent(List<string> FilesToReportOn, string ReportFileName)
        {
            StringBuilder sbz = new StringBuilder();
            try
            {
                foreach (string file in FilesToReportOn)
                {
                   if(File.Exists(file))
                   { 
                    //FileLock.LockAdd(file);
                    sbz.Append("File:" + file + " @@ " +  File.GetCreationTime(file).ToString() +  "\r\n");
                    sbz.Append(File.ReadAllText(file) + "\r\n****************************************************************************\r\n");
                    //FileLock.LockRemove(file);
                  }
                }

                if (sbz.Length > 0)
                {
                    sbz.Insert(0, "Report created " + DateTime.Now.ToString() +"\r\n\r\n");
                    File.WriteAllText(ReportFileName, sbz.ToString());
                    Globals.Sleep(200);
                    Process.Start(ReportFileName);
                }
            }

            catch (Exception E)
            {

                Globals.simpleMessageBox("ReportOnFileContent:" + E.Message);
            }




        }

        private void viewAllWorkToDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> Files = new List<string>();
            try{
            foreach (string dir in globals.cfg.settingFactoringDirectories)
            {
                Files.Add(dir + "\\" + Globals.FILE_WORK_TODO);
            }

            Files.Add(Environment.CurrentDirectory + "\\" + Globals.FILE_MISFIT_WORK_TODO);
            ReportOnFileContent(Files,"_WorkReport.txt");
            }
              
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
        }

        private void viewAllResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> Files = new List<string>();
            try{
            foreach (string dir in globals.cfg.settingFactoringDirectories)
            {
                Files.Add(dir + "\\" + Globals.FILE_RESULTS);
            }
            ReportOnFileContent(Files, "_ResultsReport.txt");
             }
              
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
        }


        private void viewGIOMLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Globals.DIR_WEB_LOGGING);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }
        }

       

        private void applySystemwideLocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Show("Apply file-locks systemwide?\r\n(only useful for testing file-lock management)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            try
            {
                foreach (string dir in globals.cfg.settingFactoringDirectories)
                {
                    //FileLock.LockAdd(dir + "\\" + Globals.FILE_WORK_TODO);
                    //FileLock.LockAdd(dir + "\\" + Globals.FILE_RESULTS);
                    //FileLock.LockAdd(dir + "\\" + Globals.FILE_WORK_TODO_SUSPENDED);
                }
                //FileLock.LockAdd(Globals.FILE_MISFIT_WORK_TODO);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }

        private void removeLingeringLocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Show("Remove file-locks systemwide?\r\n(useful if there are orphaned lock files causing issues)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            try
            {
                foreach (string dir in globals.cfg.settingFactoringDirectories)
                {
                    //FileLock.LockRemove(dir + "\\" + Globals.FILE_WORK_TODO);
                    //FileLock.LockRemove(dir + "\\" + Globals.FILE_RESULTS);
                    //FileLock.LockRemove(dir + "\\" + Globals.FILE_WORK_TODO_SUSPENDED);
                }

                //FileLock.LockRemove(Globals.FILE_MISFIT_WORK_TODO);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }

       


        private ArrayList GenerateDirectoryListFromSelectedIntances(DataGridView grid, out List<int> WorkToDoCounts)
        {
            ArrayList selectedDirs = new ArrayList();
            WorkToDoCounts = new List<int>();
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                if (grid[0, i].Selected)
                {
                    Debug.WriteLine(globals.cfg.settingFactoringDirectories[i].ToString());
                    selectedDirs.Add(globals.cfg.settingFactoringDirectories[i].ToString());
                    WorkToDoCounts.Add(Convert.ToInt32(grid[1, i].Value));  //get the value from the worktoDo column
                }

            }

            if (selectedDirs.Count < 2)  //got to have at least two to process!
                selectedDirs.Clear();

            return selectedDirs;
        }



        private void dgv1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Button.ToString());


            if (e.Button == MouseButtons.Right )
            {
                //ArrayList ToBalance = new ArrayList();                            
                try
                {
                    List<int> WorkCount;
                    ArrayList ToBalance = GenerateDirectoryListFromSelectedIntances(dgv1, out WorkCount);
                    string message = string.Empty;

                    if (ToBalance.Count != 0)
                    {
                        string x = string.Empty;
                        foreach (string dir in ToBalance)
                        {
                            x += dir + "\r\n";
                        }
                        DialogResult res = MsgBox.Show("Balance work between instances\r\n" + x, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {

                            bool results = BalanceWorkCore(ToBalance, WorkCount, Globals.MIN_WORK_BALANCE_DIFFERENCE_TRIGGER, false);
                            if (results)
                            {
                                UpdateGridStats();
                                message = "Work balanced OK";
                            }
                            else
                            {
                                message = "Work balance was not required";
                            }

                            if (globals.cfg.settingShowConfirmationDialogs || !results)
                                Globals.simpleMessageBox(message);


                        }
                    }
                }
                catch (Exception E)
                {

                    Globals.simpleMessageBox(E.Message);
                }



            }

        }

        private void howToBalanceSpecificInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.simpleMessageBox("To balance work between specific instances: First select the desired instances in the grid and then right click.");
        }




        private void openMyDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignWorkViaAutomation();
        }



        private void lblWorkToDo_DoubleClick(object sender, EventArgs e)
        {
            ShowStagedWork();
        }

        private void lblStall_Click(object sender, EventArgs e)
        {

        }



        private void passwordSafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://telegram.org/");
        }

        private void DiskCryptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.veracrypt.fr/en/Home.html");
        }

        private void teamViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.teamviewer.com");
        }

        private void winRarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.win-rar.com");
        }


        private void xnViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("https://www.xnview.com/en/xnview/");
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            MISFITNeedsWork();
        }

        

        

        private void button1_Click_6(object sender, EventArgs e)
        {
            PurgeOldLogFiles();
        }

        private void button1_Click_7(object sender, EventArgs e)
        {
            PurgeOldLogFiles();
        }

        private void button1_Click_8(object sender, EventArgs e)
        {
            CheckForDuplicatesGlobally(true);
        }

        private void lblStartupTime_Click(object sender, EventArgs e)
        {

        }

        private void whyStageDrainAssignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.simpleMessageBox("Staging work in an inactive file (MISFITworkToDo.txt) allows work to be setup/manipulated/fondled/returned/etc thereby reducing the risk of corrupting live WorkToDo.txt files. When live WorkToDo.txt files need more assignments work is drained from this file in a FIFO manner.");
        }



        private void showProductivityToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                //productivity.FetchProductivityFromDisk();
                SetProductivityUIValues();
                Globals.simpleMessageBox(productivity.GetReportVerbose);


            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }


        }

        private void suspendAutomationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unsuspendStalledProcessDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StallDetectionIsSuspended)
                Globals.simpleMessageBox("Stall Detection is not currently suspended");
            else

                if (isMFAKTxRunning())
                {
                    StallDetectionIsSuspended = false;

                }
                else
                {
                    DialogResult res = DialogResult.Yes;

                    res = MsgBox.Show("MFAKTx is not running. Resume anyway?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                        StallDetectionIsSuspended = false;

                }


        }





        private void checkNewerversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.simpleMessageBox("Automatic version checking not yet fixed, your current version is " + Globals.VERSION_MISFIT_STRING + ", opening URL to MISFIT releases page");
            LaunchLink(Globals.URI_MISFIT_DOWLOADS_PAGE);
            // TODO: actually use github releases api to figure out if user needs a new version
            /*try
            {
                this.Cursor = Cursors.WaitCursor;
                int OnlineVersion = FetchMISFITversion();
                if (OnlineVersion > Globals.VERSION_MISFIT_INT)
                {
                    Globals.simpleMessageBox("Online has a newer version. (" + OnlineVersion.ToString() + ")");
                    LaunchLink(Globals.URI_MISFIT_DOWLOADS_PAGE);
                }
                else if (OnlineVersion < Globals.VERSION_MISFIT_INT)
                {
                    Globals.simpleMessageBox("You have a newer version. (" +Globals.VERSION_MISFIT_INT.ToString()+ ")");

                }
                else
                {
                    Globals.simpleMessageBox("You have the latest version.");
                }

            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error:\r\n" + E.Message);

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }*/
        }

        private void wrapUpProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WrapUpProcessing();

        }



        public List<string> GetLisOfWorkToDoAddFiles(PathTypes pathtype)
        {
            List<string> foundList = new List<string>();
            foreach (string path in lstDirectories.Items)
            {
                string addFile = path + "\\" + Globals.FILE_WORK_TODO_ADD;
                if (File.Exists(addFile))
                {
                   switch (pathtype)
                   {
                       case PathTypes.Local:
                           if(!isRemotePath(addFile))
                               foundList.Add(addFile);
                               break;

                       case PathTypes.Remote:
                          if (isRemotePath(addFile))
                              foundList.Add(addFile);
                              break;

                       case PathTypes.Any:
                           foundList.Add(addFile);
                           break;
                   }
                }
            }
            return foundList;
        }



        public void WrapUpProcessing()
        {
           
            

            try
            {
                if (!isMFAKTxRunning())
                {
                    Globals.simpleMessageBox("MFAKTx is not running!");
                    return;
                }
                if (GetPathCountsByType(globals.cfg.settingFactoringDirectories, PathTypes.Local) == 0)
                {
                    Globals.simpleMessageBox("Wrap-Up not available when no local paths are configured!");
                    return;
                }

                if (GetLisOfWorkToDoAddFiles(PathTypes.Local).Count > 0)
                {
                    Globals.simpleMessageBox("Local " + Globals.FILE_WORK_TODO_ADD + " files exist so you cannot Wrap-up processing at this time!");
                    return;
                }

                frmWrapUp frm = new frmWrapUp();
                DialogResult res = new DialogResult();
                res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    res = MsgBox.Show("Are you sure you want to wrap-up processing?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        if (!isMFAKTxRunning())
                            throw new Exception("MFAKTx is not running!");
                        SuspendAutomationUntil = DateTime.Now.AddDays(100);
                        this.Enabled = false;

                        foreach (string directory in globals.cfg.settingFactoringDirectories)
                        {
                            if(!isRemotePath(directory))
                             Globals.SplitFileContentBetweenFiles(directory, Globals.FILE_WORK_TODO, Globals.FILE_WORK_TODO_SUSPENDED, frm.RowsToLeaveInEachWorkToDo);
                        }
                        globals.cfg.settingNotifyWhenGHZdaysToDoDropsBelow = 0; //turn this feature off because it will always drop near zero
                        lblWrappingUp.Visible = true;
                        UpdateGridStats();
                        this.Enabled = false; //no more ui updates or changes allowed now.

                        while (isMFAKTxRunning())
                        {
                            Application.DoEvents();
                            Globals.Sleep(500);
                            Application.DoEvents();
                            
                        }
                        Globals.Sleep(2000);
                        if (globals.cfg.isGIMPScredentialsConfigured() && frm.UploadResults)
                        {
                            ExportResultsList_Wrapper(globals.cfg.settingHoldBackPartialResults, true, false,true,false);
                        }

                        if (frm.ExecuteWrapUpBatch)
                            Process.Start(Globals.FILE_WRAPUP_BATCH);


                        if (globals.cfg.isEmailConfigured() && frm.SendEmail)
                        {
                            StringBuilder BadNews = new StringBuilder();
                            foreach (string directory in globals.cfg.settingFactoringDirectories)
                            {
                                if (!isRemotePath(directory) && File.Exists(directory + "\\" + Globals.FILE_WORK_TODO))
                                {
                                    FileInfo fi = new FileInfo(directory + "\\" + Globals.FILE_WORK_TODO);
                                    if (fi.Length > 0)
                                    {
                                        BadNews.AppendLine("WARNING:" + fi.FullName + " is not empty!");

                                    }

                                }
                            }
                            
                            
                            globals.GlobalSendEmail("MISFIT has wrapped-up processing.", "All instances of MFAKTx have exited and MISFIT is quitting.\r\n\r\n" + BadNews.ToString());
                        }

                        Globals.Sleep(2000);//be sure the process batch file launches before MISFIT terminates.
                        Application.Exit();

                    }

                }
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error trying to wrap up processing!\r\n" + E.Message);
            }
           

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                TestForStalledProcesses(false);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error:" + E.Message);
            }
        }



        private void ResumeStallDetection()
        {
            if (!StallDetectionIsSuspended)
                Globals.simpleMessageBox("Stall Detection is not currently suspended");
            else

                if (isMFAKTxRunning())
                {
                    StallDetectionIsSuspended = false;

                }
                else
                {
                    DialogResult res = DialogResult.Yes;

                    res = MsgBox.Show("MFAKTx is not running. Resume anyway?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                        StallDetectionIsSuspended = false;

                }
        }

        private void resumeStallDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResumeStallDetection();

        }

        private void suspendStallDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StallDetectionIsSuspended)
                Globals.simpleMessageBox("Stall Detection is already suspended");
            else
                StallDetectionIsSuspended = true;
        }

        private void button1_Click_9(object sender, EventArgs e)
        {
            MessageBox.Show(Globals.CreateFileName(Globals.DIR_MISFIT_BACKUPS + "\\" + Globals.FILE_PREFIX_RESULTS_EXPORTED, "txt"));

             
        }

       

        private void leaderboardAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LaunchLink(Globals.URI_GIMPS_STATS_TOP_ALL);
        }

        private void tFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink(Globals.URI_GIMPS_STATS_TOP_TF);
        }

        private void dCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink(Globals.URI_GIMPS_STATS_TOP_LLDC);
        }


        private void ImplementScheduleDefault(bool showDialogs)
        {
            if (ScheduleName!=Globals.PHRASE_DEFAULT_SCHEDULE)
            {
                DialogResult res = DialogResult.Yes;
                if(showDialogs)
                {
                    res = MsgBox.Show("Unload Custom Schedule?\r\n" + ScheduleName, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (res == DialogResult.Yes)
                { 
                ScheduleQueue = new Queue(globals.cfg.settingProcessScheduleList);
                ScheduleName = Globals.PHRASE_DEFAULT_SCHEDULE;
                ScheduleFromFile = null;
                if (showDialogs)
                {
                    Globals.simpleMessageBox("Default Schedule Loaded OK!");
                    AskSchedulerEnablementQuestion();
                    //showCurrentSchedule();
                }
            }
            }
            else
            {
                throw new Exception("Current Schedule is already the default. Nothing to unload!");

            }
        }

        private void AskSchedulerEnablementQuestion()
        {
            if (!globals.cfg.settingEnableSchedules)
            {
                DialogResult res = DialogResult.Yes;

                res = MsgBox.Show("The scheduler is disabled do you want to enable it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    globals.cfg.settingEnableSchedules = true;
            }
        }

       
        
        
        
        private void LoadScheduleFromFile(string ScheduleFilePath, bool showDialogs)
        {
            const string Prefix="Scheduler:";
           // ScheduleFromFile = new List<string>();
            ScheduleFromFile = Globals.SanitizeListFromFile(ScheduleFilePath,Prefix,Globals.SanitizeModes.STARTS_WITH);
            //Sched.Sort();
            if(ScheduleFromFile.Count > 0)
            {
                if (ScheduleFromFile.Count > 60)
                     throw new Exception("Event Scheduling is limited to 60 events!");

                Debug.WriteLine("********** CHANGING SCHEDULE *********");
                ScheduleQueue = new Queue();
                foreach (string item in ScheduleFromFile)
                {
                    ScheduleQueue.Enqueue(item.Substring(Prefix.Length));
                }

               
                
                ScheduleName = ScheduleFilePath;

                if (showDialogs)
                {
                    Globals.simpleMessageBox("File based Schedule Loaded OK!\r\n\r\n" + ScheduleFilePath);
                    AskSchedulerEnablementQuestion();
                 
                }

            }
            else
            {
                    throw new Exception(ScheduleFilePath + " does not contain any " + Prefix + " data!");
            }
                    
        }


        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "MISFIT Schedule files (*.msf)|*.msf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            try
            {
                timer1.Enabled = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    LoadScheduleFromFile(openFileDialog1.FileName, true);

                }
            }
            catch (Exception E)            {
                Globals.simpleMessageBox(E.Message);
            }finally
            {
                timer1.Enabled = true;

            }

         }

        private void unloadScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                
                ImplementScheduleDefault(true);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }

        }

        private void showCurrentSchedule()
        {
            List<string> L = null;
            if (ScheduleName == Globals.PHRASE_DEFAULT_SCHEDULE)  //point to the correct schedule
                L = globals.cfg.settingProcessScheduleList;
            else
                L = ScheduleFromFile;

            Globals.simpleMessageBox("CURRENT SCHEDULE DETAILS\r\n\r\nScheduler Enabled=" + globals.cfg.settingEnableSchedules.ToString() + "\r\n\r\nUsing Schedule: " + ScheduleName + "\r\n\r\n" + string.Join(Environment.NewLine, L.ToArray()));
        }

    

        private void showCurrentScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {


            showCurrentSchedule();
        }

        private void schedulerOverrideToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mfaktCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("http://mersenneforum.org/mfaktc/");
        }

        private void mISFITToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LaunchLink(Globals.URI_MISFIT_DOWLOADS_PAGE);
        }

        private void mfaktOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchLink("http://mersenneforum.org/mfakto/");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(240);
        }

        private void minsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(480);
        }

        private void updateStatsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateGridStats();
        }

       
        private void customDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (globals.cfg.settingUpdateStatsInterval > 0)
            {
                frmSuspendAutomation frm = new frmSuspendAutomation();

                frm.CurrentlySuspendedTill = SuspendAutomationUntil;
                DialogResult res;

                res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    SuspendAutomationUntil = frm.CurrentlySuspendedTill;

                }
            }
            else
            {

                Globals.simpleMessageBox("Automation is already OFF!");
            }
            
            
            

        }

        private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Globals.simpleMessageBox("Suspending automation is used to keep MISFIT from performing any actions. A good example is you are manually changing files and you don't want MISFIT to interfere for a period of time.  Another idea is to have your scheduler set to always start MFAKTx every hour at say *,*:30  If you stop MFAKTx and then suspend automation for 4 hours MISFIT will sit quietly until the suspension period is over and resume processing shedules, so at the next *,*:30 MFAKTx will get started. (It won't start another instance if it is already running.)");
        }

        private void hoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuspendAutomationForMinutes(360);
        }

        private void viewRecentUploadedResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> Files = new List<string>();
            try
            {
                string[] sentFiles = Directory.GetFiles(Globals.DIR_GIOM_SENT, Globals.FILE_PREFIX_RESULTS_EXPORTED + "*");
                foreach (string f in sentFiles)
                {
                    Files.Add(f);
                }
                //for this particular report lets sort the list so the files are in cronological order...(the file names use timestamps in them making the sort meaningful)
                Files.Sort();
                Files.Reverse(); //make the list descending
                ReportOnFileContent(Files, "_ResultsUploadedReport.txt");
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
        }

        private void dgv1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

