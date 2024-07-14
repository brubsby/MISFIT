using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace MISFIT
{
    public partial class frmGIMPSresultsUpload : Form
    {
        public frmGIMPSresultsUpload()
        {
            InitializeComponent();
        }



      
        private int counter = 0; //force a q check on startup.
        public Globals globals;
        private bool NeedToCloseForm = false;
        //private string LogFileName = "GIOMLOG_" + Guid.NewGuid().ToString().Substring(0, 15) + ".txt";
        private string LogFileName = Globals.CreateFileName("GIOM", Globals.FILE_EXT_TXT);
        public DateTime TimeStarted = DateTime.Now;
        public bool EmailSent = false;
        
        public enum StringCheckItem
        {
            LoginOK,
            UploadedResultsOK,
            ResultWasNotNeeded,
            Crediting,
     
        }


        public string ResultsFileToSubmit = string.Empty;

        

        private void frmWebIO_Load(object sender, EventArgs e)
        {

            lblUploadCheck.Visible = true;
            progressBar1.Visible = true;
            lblWorkStatus.Text = "Standby for RESULTS FILE UPLOAD";
            timer7.Enabled = true;
            Logit("Stand by for queue check...");
            progressBar1.Maximum = Globals.MaxCounterTimeforGIOM;
            counter = Globals.MaxCounterTimeforGIOM - 5;
            Application.DoEvents();
            globals.LastGIOMUploadDetectedResultsNotNeeded = false;

            
        }

        private void Logit(string info)
        {
            try
            {
                if (txtLogWindow.TextLength + 500 > txtLogWindow.MaxLength)
                {
                    txtLogWindow.Text = DateTime.Now.ToString() + " cleared log window";
                }
                string toWrite = DateTime.Now.ToString() + ":" + info + Environment.NewLine;
                txtLogWindow.AppendText(toWrite);
                File.AppendAllText(Globals.DIR_WEB_LOGGING + "\\" + this.LogFileName, toWrite);


                Application.DoEvents();
            }
            catch
            {

            }

        }

        private bool CheckForString(StringCheckItem item, string stringToCheck)
        {
            bool foundString = false;

            switch ((int)item)
            {
                case 0:
                    {
                        if (stringToCheck.Contains(globals.cfg.settingGIMPSUserID.ToUpper() + "<BR>LOGGED IN"))
                            foundString = true;
                        break;
                    }
                case 1:
                    {
                        if (stringToCheck.Contains(globals.cfg.settingGIMPSUserID.ToUpper() + "<BR>LOGGED IN") && stringToCheck.Contains("DID NOT UNDERSTAND 0 LINES"))
                            foundString = true;

                        break;
                    }
                case 2:
                    {
                        if (stringToCheck.Contains("WAS NOT NEEDED") || stringToCheck.Contains("ERROR CODE: 40"))
                       // if (stringToCheck.Contains("ERROR CODE: 40"))
                            foundString = true;
                        break;
                    }

                case 3:
                    {

                        if (stringToCheck.Contains("PROCESSING_VALIDATION:CREDITING"))
                            foundString = true;
                        break;
                    }
               
                default:
                    {
                        foundString = false;
                        break;
                    }

            }

            return foundString;
        }

        
        private void MoveUploadedFileToCompletedDirectory(string FullFileName)
        {
            try
            {
                FileInfo fi = new FileInfo(FullFileName);
                //Logit("moving file to " + Globals.GIOMSentDir);
                fi.MoveTo(Globals.DIR_GIOM_SENT + "\\" + fi.Name);
            }
            catch (Exception E)
            {
                throw new Exception("Error moving file to " + Globals.DIR_GIOM_SENT + " " + E.Message);
            }
        }



        private void UploadFile(string fileName)
        {
            WebIO myWebIO = new WebIO();
            Gimps.LoginGimps(globals.cfg.settingGIMPSUserID, globals.cfg.settingGIMPSPassword, myWebIO);
            string results = Gimps.ReportWork(fileName, myWebIO);
            Globals.LogWebIO("GIMPSRESULTSUPLOAD", results, Globals.FILE_EXT_TXT);
            if (!CheckForString(StringCheckItem.UploadedResultsOK, results))
                throw new Exception("GIMPS response was unexpected! Check WEB_LOGS for details."); 
                    
            if(CheckForString(StringCheckItem.ResultWasNotNeeded, results))
                    globals.LastGIOMUploadDetectedResultsNotNeeded=true;
        }

        private void SignalOKToCloseForm(int delay)
        {
            NeedToCloseForm = true;
            lblWorkStatus.Text = "Stand by... closing";
            Application.DoEvents();
            for (int i = 0; i <= delay * 100; i++)
            {
               Globals.Sleep(10);
                Application.DoEvents();

            }
        }





        private void checkForResultsToUpload()
        {
            timer7.Enabled = false;
           
            try
            {
                Logit("Checking " + Globals.DIR_GIOM_STAGED + " for files to upload");
                string[] files = Directory.GetFiles(Globals.DIR_GIOM_STAGED, "*.txt");
               
               

                if (files.Length > 0)
                {
                    Logit("Found " + files.Length.ToString() + " file(s)");
                    List<string> filesSorted = new List<string>();
                    filesSorted.AddRange(files);
                    filesSorted.Sort();
                    

                    foreach (string file in filesSorted)
                    {
                           Logit("Begin upload process for " + file);

                            this.Cursor = Cursors.WaitCursor;
                            UploadFile(file);
                            this.Cursor = Cursors.Default;
                            Logit("Uploaded results OK!");
                            Logit("Moving file " + file + " to " + Globals.DIR_GIOM_SENT);
                            MoveUploadedFileToCompletedDirectory(file);
                    }

                    Logit("All files processed. bye!");
                    SignalOKToCloseForm(5);


                }
                else
                {
                    Logit("No files found....nothing to do... bye!");
                    SignalOKToCloseForm(5);


                }

            }
            catch (Exception E)
            {
                Logit("Error! " + E.Message + "\r\nWill try the upload again in about 30 minutes...");//form will stay open for retry processing if an error occurred.
                lblWorkStatus.Text = "Errors detected. See text";
                btnRetry.Visible = true;
            }

            this.Cursor = Cursors.Default;
            timer7.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (NeedToCloseForm)
                {
                    this.timer7.Enabled = false;
                    this.Close();
                }
                else
                {

                    counter++;


                    if (counter < progressBar1.Maximum) //required to prevent overrun if we preventing upload due to isGimpsPeaktime
                        progressBar1.Value = counter;

                    Debug.WriteLine("Window start time is " + this.TimeStarted.ToString());

                    if (TimeStarted.AddMinutes(65) < DateTime.Now && !EmailSent && globals.cfg.isEmailConfigured() && globals.cfg.settingSendEmailWhenGIOMPanelRemainsOpen)
                    {
                        EmailSent = true;
                        Logit("Sending Email due to GIOM being opened greater than 65 minutes");
                        try
                        {
                            globals.GlobalSendEmail(globals.cfg.settingEmailSubjectGIOMPanelRemainsOpen, "CONTENT OF GIOM IS AS FOLLOWS:\r\n\r\n" + this.txtLogWindow.Text);
                        }
                        catch (Exception E)
                        {
                            Logit("Failed to send email:" + E.Message);

                        }

                    }

                    progressBar1.Update();
                    Application.DoEvents();



                    if (counter >= Globals.MaxCounterTimeforGIOM)
                    {
                        counter = 0;
                        checkForResultsToUpload();
                    }
                }
            }
            catch(Exception EE)
            {
                Globals.simpleMessageBox("GIOM timer1 failure:" + EE.Message);

            }

        }

        private void frmWebIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("closing-disabling timer 7");
            timer7.Enabled = false;
        }

        private void frmWebIO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("closed-disabling timer 7");
            timer7.Enabled = false;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            counter = Globals.MaxCounterTimeforGIOM;
        }
    }
}
