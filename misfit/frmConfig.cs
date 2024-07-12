using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using Microsoft.Win32;


namespace MISFIT
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            Gpu72LLTFoptions.Add(0, "What makes sense");
            Gpu72LLTFoptions.Add(1, "Lowest TF level");
            Gpu72LLTFoptions.Add(2, "Highest TF level");
            Gpu72LLTFoptions.Add(3, "Lowest exponent");
            Gpu72LLTFoptions.Add(4, "Oldest exponent");
            Gpu72LLTFoptions.Add(9, "Let GPU72 decide");


            Gpu72DCTFoptions.Add(0, "What makes sense");
            Gpu72DCTFoptions.Add(1, "Lowest TF level");
            Gpu72DCTFoptions.Add(2, "Highest TF level");
            Gpu72DCTFoptions.Add(3, "Lowest exponent");
            Gpu72DCTFoptions.Add(4, "Oldest exponent");
            Gpu72DCTFoptions.Add(5, "No P-1 done");
            Gpu72DCTFoptions.Add(9, "Let GPU72 decide");
        }
        public Globals globals;
        private Hashtable LocationHashTable = new Hashtable();
        private Hashtable StartProcessHashTable = new Hashtable();
        private Hashtable StopProcessHashTable = new Hashtable();
        private Hashtable ScheduleHashTable = new Hashtable();
        private int AutoFetchMode = 0;
        private Dictionary<int, string> Gpu72LLTFoptions = new Dictionary<int, string>();
        private Dictionary<int, string> Gpu72DCTFoptions = new Dictionary<int, string>();




        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.btnCancel.Select();




            try
            {
                txtPstopInfo.Text = "Specify the name of a process running in memory that you want stopped. The process name is a friendly name for the process, such as MFAKTO or MFAKTC, which does not include the .exe extension or the path. All processes with the same name will be stopped when executed. Use taskmanager to find a process name, but don't include the .EXE when configuring.  Processes will be stopped by sending CTRL-C signal to their console. To accomplish this MISFIT calls the external program named SendCtrlCode.exe which then sends the CTRL-C signal.";
                txtCryptoInfo.Text = @"Encryption of passwords is done using the Rijndael (AES) cipher with 256 bit key length, and 128 bit block size. The internal key and SALT that MISFIT uses to encrypt/decrypt your passwords is derived from unique items belonging to the PC and the logged-in user, then made suitable for use in encryption using the PBKDF1 algorithm. If any of these items change after encryption the decryption of your passwords will fail. This means you cannot move your config file between users or computers and expect decryption to work.
Even with encryption you may want to create an email account dedicated to MISFIT. 
";

                try
                {

                    try
                    {
                        chkUseWorkToDoAdd.Checked = globals.cfg.settingUseWorkToDoAdd;
                    }
                    catch
                    {
                    }

                    try
                    {
                        chkHoldBackUnfinishedExponents.Checked = globals.cfg.settingHoldBackPartialResults;
                    }
                    catch
                    {

                    }

                    try
                    {
                        chkEmailWhenGIOMPanelRemainsOpen.Checked = globals.cfg.settingSendEmailWhenGIOMPanelRemainsOpen;
                    }
                    catch
                    {


                    }



                    try
                    {
                        txtEmailSubjectGIOMPanelOpen.Text = globals.cfg.settingEmailSubjectGIOMPanelRemainsOpen;
                    }
                    catch
                    {

                    }


                    try
                    {
                        chkEmailWhenAlertPanelRemainsOpen.Checked = globals.cfg.settingSendEmailWhenAlertPanelRemainsOpen;
                    }
                    catch
                    {


                    }



                    try
                    {
                        txtEmailSubjectAlertPanelOpen.Text = globals.cfg.settingEmailSubjectAlertPanelRemainsOpen;
                    }
                    catch
                    {

                    }


                    try
                    {
                        chkStartWithStallDetectionSuspended.Checked = globals.cfg.settingStartWithStallDetectionSuspended;
                    }
                    catch
                    {


                    }

                    try
                    {
                        txtEmailSubjectExtenralFetchResults.Text = globals.cfg.settingEmailSubjectExtenralFetchResults;
                    }
                    catch
                    {

                    }


                    try
                    {
                        txtEmailSubjectLowGHZDsToDo.Text = globals.cfg.settingEmailSubjectLowGHZDsToDo;
                    }
                    catch
                    {

                    }

                    try
                    {
                        txtEmailSubjectStalledProcess.Text = globals.cfg.settingEmailSubjectStalledProcess;
                    }
                    catch
                    {

                    }


                    try
                    {
                        txtEmailSubjectStats.Text = globals.cfg.settingEmailSubjectStats;
                    }
                    catch
                    {

                    }



                    try
                    {
                        chkShowProductivityAsAverages.Checked = globals.cfg.settingProductivityShowAverages;
                    }
                    catch
                    {

                    }


                    try
                    {
                        chkIncludeBitLevelOnDupDetection.Checked = globals.cfg.settingDuplicateAssignmentsDetectionIncludeBitLevel;
                    }
                    catch
                    {

                    }


                    try
                    {
                        nudPurgeLogsDaysOld.Value = globals.cfg.settingPurgeLogsDaysOld;
                    }
                    catch
                    {

                    }


                    try
                    {
                        chkEmailStatsBeforeWorkFetch.Checked = globals.cfg.settingEmailGlobalWorkStatsBeforeWorkFetch;
                    }
                    catch
                    {

                    }


                    try
                    {
                        nudMISFITworkToDoCheckInterval.Value = globals.cfg.settingWorkFetchMISFITWorkToDoHoursBetweenChecks;
                    }
                    catch
                    {

                    }




                    try
                    {
                        nudGPU72GzDzDaysToFetch.Value = globals.cfg.settingWorkFetchGPU72UseGHZdays;
                    }
                    catch
                    {

                    }


                    try
                    {
                        txtGPU72Low.Text = globals.cfg.settingWorkFetchGPU72ExponentLow.ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        chkGPU72FallBack.Checked = globals.cfg.settingWorkFetchGPU72FallBack;
                    }
                    catch
                    {

                    }


                    try
                    {
                        txtGPU72High.Text = globals.cfg.settingWorkFetchGPU72ExponentHigh.ToString();
                    }
                    catch
                    {

                    }









                    switch (globals.cfg.settingWorkFetchMode)
                    {
                        case (int)Config.AutoWorkFetchModes.DISABLED:
                            radioWorkFetchDisabled.Checked = true;
                            break;

                        case (int)Config.AutoWorkFetchModes.GIMPS:
                            radioWorkFetchGIMPS.Checked = true;
                            break;

                        case (int)Config.AutoWorkFetchModes.GPU72:
                            radioWorkFetchGPU72.Checked = true;
                            break;
                        case (int)Config.AutoWorkFetchModes.EXTERNAL_COMMAND:
                            radioWorkFetchExternal.Checked = true;
                            break;
                        default:
                            radioWorkFetchDisabled.Checked = true;
                            break;


                    }

                    try
                    {
                        cmbGpu72TestType.SelectedIndex = globals.cfg.settingWorkFetchGPU72WorkType;//must come before Preferred work.
                    }
                    catch
                    {

                    }

                    try
                    {
                        cmbFetchGPU72PreferredWork.SelectedValue = globals.cfg.settingWorkFetchGPU72Preference;
                    }
                    catch
                    {

                    }


                }
                catch
                {

                }

                try
                {
                    txtGPU72UserID.Text = globals.cfg.settingGPU72UserID;
                }
                catch
                {

                }

                try
                {
                    txtGPU72Password.Text = globals.cfg.settingGPU72Password;
                }
                catch
                {

                }



                try
                {
                    nudWorkFetchGhDzThreshold.Value = globals.cfg.settingWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz;

                }
                catch
                {

                }

                try
                {
                    nudGIMPSFetchCount.Value = globals.cfg.settingWorkFetchAssignmentsToFetch;
                }
                catch
                {

                }

                try
                {
                    nudWorkBitLevel.Value = globals.cfg.settingWorkFetchBitLevelTo;
                }
                catch
                {
                }

                try
                {
                    chkGIMPSReplaceGUIDs.Checked = globals.cfg.settingWorkFetchReplaceIdentifierWithDate;
                }
                catch
                {

                }

                try
                {
                    chkEmailPreAssignRunResult.Checked = globals.cfg.settingEmailPreAssignRunResult;
                }
                catch
                {
                }


                try
                {
                    txtPreDrainCommand.Text = globals.cfg.settingWorkFetchExternalCommand;
                }
                catch
                {

                }


                try
                {
                    txtPreDrainCommandArguments.Text = globals.cfg.settingWorkFetchExternalCommandArguments;
                }
                catch
                {

                }

                try
                {
                    nudMaxGzDzToAssignDuringDrain.Value = globals.cfg.settingMaxGhDzPerAutoAssignEvent;

                }
                catch
                {

                }




                try
                {
                    nudDrainMISFITWorkWhenBelow.Value = globals.cfg.settingAssignWorkWhenGHZdaysToDoDropsBelow;
                }
                catch
                {
                }




                try
                {
                    chkShowWorkingFactorInPhases.Checked = globals.cfg.settingShowWorkingFactorInPhases;
                }
                catch
                {

                }



                try
                {
                    nudNotifyWhenGHZdaysDropsBelow.Value = globals.cfg.settingNotifyWhenGHZdaysToDoDropsBelow;
                }
                catch
                {

                }


                try
                {
                    chkEmailOnLowWork.Checked = globals.cfg.settingSendEmailWhenLowGHZdaysIsDetected;
                }
                catch
                {

                }


                

                try
                {
                    chkMinimizeToSysTray.Checked = globals.cfg.settingMinimizeToSysTray;
                }
                catch
                {
                }

                try
                {
                    chkEmailOnStalledProcessDetection.Checked = globals.cfg.settingStalledProcessSendEmailAlert;
                }
                catch
                {
                }

                try
                {
                    nudStalledResultsMaxMinutes.Value = globals.cfg.settingMinsOldBeforeProcessStallAlarm;
                }
                catch
                {
                }



                try
                {
                    txtSMTPServer.Text = globals.cfg.settingSMTPServer;
                }
                catch
                {
                }

                try
                {
                    txtSMTPaccountID.Text = globals.cfg.settingSMTPUserID;
                }
                catch
                {
                }

                try
                {
                    txtSMTPfrom.Text = globals.cfg.settingSMTPFromAddress;
                }
                catch
                {
                }

                try
                {
                    txtSMTPpassword.Text = globals.cfg.settingSMTPPassword;
                }
                catch
                {
                }

                try
                {
                    txtSMTPport.Text = globals.cfg.settingSMTPPort.ToString();
                }
                catch
                {
                }


                try
                {
                    txtSMTPRecipients.Text = globals.cfg.settingSMTPRecipients;
                }
                catch
                {
                }

                try
                {
                    chkSMTPAuthRequired.Checked = globals.cfg.settingSMTPRequiresAuthentication;
                }
                catch
                {
                }

                try
                {
                    chkSMTPUseTLS.Checked = globals.cfg.settingSMTPUseTLS;
                }
                catch
                {
                }



                try
                {
                    txtGimpsUserID.Text = globals.cfg.settingGIMPSUserID;
                }
                catch
                {
                }


                try
                {
                    txtGIMPSPassword.Text = globals.cfg.settingGIMPSPassword;

                }
                catch
                {
                }


                try
                {
                    nudBalanceWorkDifference.Value = globals.cfg.settingAutoBalanceDifferenceTrigger;
                }
                catch
                {
                }

               



               

                try
                {
                    chkSchedulesEnabled.Checked = globals.cfg.settingEnableSchedules;
                }
                catch
                {
                }


                try
                {
                    nudUpdateInterval.Value = globals.cfg.settingUpdateStatsInterval;
                }
                catch
                {
                }
                try
                {
                    nudProcessStartDelay.Value = globals.cfg.settingStartProcessDelay;
                }
                catch
                {
                }
                try
                {
                    chkSetWorkingDir.Checked = globals.cfg.settingSetProcessWorkingDirectory;
                }
                catch
                {
                }
                try
                {
                    chkShowResultsInExternalViewer.Checked = globals.cfg.settingShowExportInExternalViewer;
                }
                catch
                {
                }
                try
                {
                    chkShowConfDialogs.Checked = globals.cfg.settingShowConfirmationDialogs;
                }
                catch
                {
                }
                try
                {
                    txtExportResultsURL.Text = globals.cfg.settingExportURL;
                }
                catch
                {
                }
                try
                {
                    txtLaunchURL.Text = globals.cfg.settingLaunchURL;
                }
                catch
                {
                }

                try
                {
                    foreach (string x in globals.cfg.settingFactoringDirectories)
                    {
                        this.AddToListBox(LocationHashTable, lstMFinstances, x);

                    }
                }
                catch
                {
                }

                try
                {
                    foreach (string x in globals.cfg.settingStartProcessList)
                    {
                        this.AddToListBox(StartProcessHashTable, lstStartUpProcesses, x);

                    }
                }
                catch
                {
                }


                try
                {
                    foreach (string x in globals.cfg.settingStopProcessList)
                    {
                        this.AddToListBox(StopProcessHashTable, lstStopProcessName, x);

                    }
                }
                catch
                {
                }

                try
                {
                    //string min = globals.RandomNumber.Next(0, 59).ToString();

                    //List<string> myList = new List<string> { "*,00:" + min + ",UPLOAD_RESULTS", "*,04:" + min + ",UPLOAD_RESULTS", "*,08:" + min + ",UPLOAD_RESULTS", "*,12:" + min + ",UPLOAD_RESULTS", "*,16:" + min + ",UPLOAD_RESULTS", "*,20:" + min + ",UPLOAD_RESULTS" };
                    //if(globals.cfg.settingProcessScheduleList.Count > 0)
                    //{
                    //    myList = globals.cfg.settingProcessScheduleList;
                    //}

                    //lstSchedules.Items.AddRange(myList.ToArray());

                    lstSchedules.Items.AddRange(globals.cfg.settingProcessScheduleList.ToArray());
                    
                }
                catch
                {
                }
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

            //setnudGIMPSFetchCountCondition();

        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select where to find " + Globals.FILE_WORK_TODO + " and " + Globals.FILE_RESULTS;
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            string browseTo = Environment.CurrentDirectory;
            if (lstMFinstances.Items.Count > 0)
            {
                if (Directory.Exists(lstMFinstances.Items[lstMFinstances.Items.Count - 1].ToString()))
                {
                    browseTo = lstMFinstances.Items[lstMFinstances.Items.Count - 1].ToString();
                }
            }

            folderBrowserDialog1.SelectedPath = browseTo;

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {


                AddToListBox(this.LocationHashTable, lstMFinstances, folderBrowserDialog1.SelectedPath);



            }

        }

        private void btnRemoveLocation_Click(object sender, EventArgs e)
        {
            RemoveFromListBox(LocationHashTable, lstMFinstances);
        }



        private void AddToListBox(Hashtable hashT, ListBox lstBox, string ItemToAdd)
        {

            try
            {

                hashT.Add(ItemToAdd, 0);
                lstBox.Items.Add(ItemToAdd);
            }

            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }

        }






        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private bool hasGpu72Credentials()
        {
            if (txtGPU72UserID.TextLength > 0 && txtGPU72Password.TextLength > 0)
                return true;
            else
                return false;
        }


        private bool hasGIMPSCredentials()
        {
            if (txtGimpsUserID.TextLength > 0 && txtGIMPSPassword.TextLength > 0)
                return true;
            else
                return false;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddStopProcessName_Click(object sender, EventArgs e)
        {
            if (txtStopProcessName.Text.Length > 0)
            {

                AddToListBox(StopProcessHashTable, lstStopProcessName, txtStopProcessName.Text.ToLower().Trim());
                txtStopProcessName.Clear();
            }
            else
            {

                Globals.simpleMessageBox("Nothing specified");
            }

        }

        private void btnAddStartupProcesses_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "exe files (*.exe)|*.exe|bat files (*.bat)|*.bat|cmd files (*.cmd)|*.cmd|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddToListBox(StartProcessHashTable, lstStartUpProcesses, openFileDialog1.FileName);

            }
        }



        private void RemoveFromListBox(Hashtable hTable, ListBox lstBox)
        {

            if (lstBox.SelectedIndex >= 0)
            {
                DialogResult res = MsgBox.Show("Remove " + lstBox.SelectedItem, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {

                    hTable.Remove(lstBox.SelectedItem);
                    lstBox.Items.RemoveAt(lstBox.SelectedIndex);
                }
                else
                {
                    lstBox.ClearSelected();

                }
            }
            else
            {
                Globals.simpleMessageBox("Nothing selected to remove");
            }
        }

        private void btnRemoveStartupProcess_Click(object sender, EventArgs e)
        {


            RemoveFromListBox(StartProcessHashTable, lstStartUpProcesses);



        }

        private void btnRemoveStopProcessName_Click(object sender, EventArgs e)
        {
            RemoveFromListBox(StopProcessHashTable, lstStopProcessName);

        }




      


       
        private void bntSave_Click(object sender, EventArgs e)
        {
            DialogResult dres = DialogResult.Yes;
            if (globals.cfg.settingShowConfirmationDialogs)
                dres = MsgBox.Show("Save Settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres != DialogResult.Yes)
                return;

            int num = 0;

            try
            {


                if (lstMFinstances.Items.Count == 0)
                {
                    Globals.simpleMessageBox("At least one MFAKTx instance location must be specified!");
                    return;
                }

               if (!hasGIMPSCredentials())
                {
                    Globals.simpleMessageBox("GIMPS credentials must be configured!");
                    return;

                }

                

                if (radioWorkFetchGPU72.Checked && !hasGpu72Credentials())
                {
                    Globals.simpleMessageBox("Work fetching from GPU72 is enabled with unspecified GPU72 credentials!");
                    return;
                }

                if (!int.TryParse(txtGPU72Low.Text, out num) || !int.TryParse(txtGPU72High.Text, out num))
                {
                    Globals.simpleMessageBox("GPU72 Low and High values must be numeric!");
                    return;
                }


                if (int.Parse(txtGPU72Low.Text) >= int.Parse(txtGPU72High.Text))
                {
                    Globals.simpleMessageBox("GPU72 Low cannot be >= GPU72 High!");
                    return;
                }

                if (radioWorkFetchGPU72.Checked && cmbFetchGPU72PreferredWork.Text == string.Empty)
                {
                    Globals.simpleMessageBox("GPU72 requires both Type and Preference be selected!");
                    return;
                }

                
                if (lstSchedules.Items.Count > 60)
                {
                    Globals.simpleMessageBox("Event Scheduling is limited to 60 events!");
                    return;
                }

                if (chkSchedulesEnabled.Checked && lstSchedules.Items.Count == 0)
                {
                    Globals.simpleMessageBox("Cannot have event scheduling enabled with NO scheduled events!");
                    return;
                }

                if ((int)nudBalanceWorkDifference.Value > 0 && (int)nudBalanceWorkDifference.Value < Config.MinAutoBalance)
                {

                    Globals.simpleMessageBox("Warning: Work balance cannot be below " + Config.MinAutoBalance.ToString() + " as it will cause continuous node re-balancing!");
                    return;
                }


                if ((int)nudStalledResultsMaxMinutes.Value > 0 && (int)nudStalledResultsMaxMinutes.Value < Config.MinEventInterval)
                {
                    Globals.simpleMessageBox("When Stalled Process Checking is turned on the minutes value must be >= " + Config.MinEventInterval.ToString());
                    return;

                }


                if (txtEmailSubjectExtenralFetchResults.Text.Length == 0 || txtEmailSubjectLowGHZDsToDo.Text.Length == 0 || txtEmailSubjectStalledProcess.Text.Length == 0 || txtEmailSubjectStats.Text.Length == 0 || txtEmailSubjectAlertPanelOpen.Text.Length == 0)
                {
                    Globals.simpleMessageBox("Email subject lines cannot be blank (even if you are not sending emails)");
                    return;
                }

                if (chkStartWithStallDetectionSuspended.Checked && nudStalledResultsMaxMinutes.Value == 0)
                {
                    Globals.simpleMessageBox("Cannot configure Stall Detection to be suspended at startup when Stall Detection is not enabled");
                    return;
                }

                if (chkUseWorkToDoAdd.Checked)
                {
                    //Globals.simpleMessageBox("WARNING:\r\nYou have configured MISFIT to push work into worktodo.ADD files so be sure you have MFAKTx setup to process worktodo.ADD\r\n");
                }

                Globals.CreateMisfitDirectories();
                globals.cfg.settingShowWorkingFactorInPhases = (bool)chkShowWorkingFactorInPhases.Checked;
                
                globals.cfg.settingMinimizeToSysTray = (bool)chkMinimizeToSysTray.Checked;

                globals.cfg.settingUpdateStatsInterval = (int)nudUpdateInterval.Value;
                globals.cfg.settingStartProcessDelay = (int)nudProcessStartDelay.Value;
                globals.cfg.settingShowExportInExternalViewer = chkShowResultsInExternalViewer.Checked;
                globals.cfg.settingShowConfirmationDialogs = chkShowConfDialogs.Checked;
                globals.cfg.settingSetProcessWorkingDirectory = chkSetWorkingDir.Checked;
                globals.cfg.settingExportURL = txtExportResultsURL.Text.Trim();
                globals.cfg.settingLaunchURL = txtLaunchURL.Text.Trim();
                globals.cfg.settingEnableSchedules = chkSchedulesEnabled.Checked;
                globals.cfg.settingGIMPSPassword = txtGIMPSPassword.Text.Trim();
                globals.cfg.settingGIMPSUserID = txtGimpsUserID.Text.Trim();
                globals.cfg.settingAutoBalanceDifferenceTrigger = (int)nudBalanceWorkDifference.Value;
                globals.cfg.settingSMTPServer = txtSMTPServer.Text.Trim();
                globals.cfg.settingSMTPFromAddress = txtSMTPfrom.Text.Trim();
                globals.cfg.settingSMTPPassword = txtSMTPpassword.Text.Trim();

                int p = 0;
                if (int.TryParse(txtSMTPport.Text, out p))
                {
                    globals.cfg.settingSMTPPort = int.Parse(txtSMTPport.Text);
                }
                else
                {
                    globals.cfg.settingSMTPPort = Config.DEFAULT_SMTP_PORT;
                }

                globals.cfg.settingSMTPRecipients = txtSMTPRecipients.Text.Trim();
                globals.cfg.settingSMTPRequiresAuthentication = chkSMTPAuthRequired.Checked;
                globals.cfg.settingSMTPUserID = txtSMTPaccountID.Text.Trim();
                globals.cfg.settingSMTPUseTLS = chkSMTPUseTLS.Checked;
                globals.cfg.settingMinsOldBeforeProcessStallAlarm = (int)nudStalledResultsMaxMinutes.Value;
                globals.cfg.settingStalledProcessSendEmailAlert = chkEmailOnStalledProcessDetection.Checked;
                globals.cfg.settingNotifyWhenGHZdaysToDoDropsBelow = (int)nudNotifyWhenGHZdaysDropsBelow.Value;
                globals.cfg.settingSendEmailWhenLowGHZdaysIsDetected = chkEmailOnLowWork.Checked;
                globals.cfg.settingAssignWorkWhenGHZdaysToDoDropsBelow = (int)nudDrainMISFITWorkWhenBelow.Value;
                globals.cfg.settingMaxGhDzPerAutoAssignEvent = (int)nudMaxGzDzToAssignDuringDrain.Value;
                globals.cfg.settingWorkFetchExternalCommand = txtPreDrainCommand.Text;
                globals.cfg.settingWorkFetchExternalCommandArguments = txtPreDrainCommandArguments.Text;
                globals.cfg.settingWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz = (int)nudWorkFetchGhDzThreshold.Value;
                globals.cfg.settingWorkFetchAssignmentsToFetch = (int)nudGIMPSFetchCount.Value;
                globals.cfg.settingWorkFetchBitLevelTo = (int)nudWorkBitLevel.Value;
                globals.cfg.settingWorkFetchReplaceIdentifierWithDate = (bool)chkGIMPSReplaceGUIDs.Checked;
                globals.cfg.settingEmailPreAssignRunResult = (bool)chkEmailPreAssignRunResult.Checked;
                globals.cfg.settingWorkFetchMode = this.AutoFetchMode;
                globals.cfg.settingGPU72UserID = this.txtGPU72UserID.Text;
                globals.cfg.settingGPU72Password = this.txtGPU72Password.Text;
                globals.cfg.settingWorkFetchGPU72WorkType = this.cmbGpu72TestType.SelectedIndex;
                globals.cfg.settingWorkFetchGPU72Preference = (int)this.cmbFetchGPU72PreferredWork.SelectedValue;
                globals.cfg.settingWorkFetchGPU72ExponentLow = int.Parse(this.txtGPU72Low.Text);
                globals.cfg.settingWorkFetchGPU72ExponentHigh = int.Parse(this.txtGPU72High.Text);
                globals.cfg.settingWorkFetchGPU72FallBack = (bool)(this.chkGPU72FallBack.Checked);
                globals.cfg.settingWorkFetchGPU72UseGHZdays = (int)this.nudGPU72GzDzDaysToFetch.Value;
                globals.cfg.settingWorkFetchMISFITWorkToDoHoursBetweenChecks = (int)nudMISFITworkToDoCheckInterval.Value;
                globals.cfg.settingEmailGlobalWorkStatsBeforeWorkFetch = (bool)chkEmailStatsBeforeWorkFetch.Checked;
                globals.cfg.settingPurgeLogsDaysOld = (int)nudPurgeLogsDaysOld.Value;
                globals.cfg.settingDuplicateAssignmentsDetectionIncludeBitLevel = (bool)chkIncludeBitLevelOnDupDetection.Checked;

                globals.cfg.settingProductivityShowAverages = (bool)chkShowProductivityAsAverages.Checked;
                globals.cfg.settingEmailSubjectStats = txtEmailSubjectStats.Text;
                globals.cfg.settingEmailSubjectStalledProcess = txtEmailSubjectStalledProcess.Text;
                globals.cfg.settingEmailSubjectLowGHZDsToDo = txtEmailSubjectLowGHZDsToDo.Text;
                globals.cfg.settingEmailSubjectExtenralFetchResults = txtEmailSubjectExtenralFetchResults.Text;
                globals.cfg.settingStartWithStallDetectionSuspended = chkStartWithStallDetectionSuspended.Checked;
                globals.cfg.settingEmailSubjectAlertPanelRemainsOpen = txtEmailSubjectAlertPanelOpen.Text;
                globals.cfg.settingSendEmailWhenAlertPanelRemainsOpen = (bool)chkEmailWhenAlertPanelRemainsOpen.Checked;
                globals.cfg.settingEmailSubjectGIOMPanelRemainsOpen = txtEmailSubjectGIOMPanelOpen.Text;
                globals.cfg.settingSendEmailWhenGIOMPanelRemainsOpen = (bool)chkEmailWhenGIOMPanelRemainsOpen.Checked;
                globals.cfg.settingHoldBackPartialResults = (bool)chkHoldBackUnfinishedExponents.Checked;
                globals.cfg.settingUseWorkToDoAdd = (bool)chkUseWorkToDoAdd.Checked;


                globals.cfg.settingFactoringDirectories.Clear();
                foreach (string x in lstMFinstances.Items)
                {
                    globals.cfg.settingFactoringDirectories.Add(x);
                }

                globals.cfg.settingStartProcessList.Clear();
                foreach (string x in lstStartUpProcesses.Items)
                {
                    globals.cfg.settingStartProcessList.Add(x);
                }

                globals.cfg.settingStopProcessList.Clear();
                foreach (string x in lstStopProcessName.Items)
                {
                    globals.cfg.settingStopProcessList.Add(x);
                }

                globals.cfg.settingProcessScheduleList.Clear();

                for (int i = 0; i <= lstSchedules.Items.Count - 1; i++)
                {
                    globals.cfg.settingProcessScheduleList.Add(lstSchedules.Items[i].ToString());
                }

               // globals.cfg.settingProcessScheduleList.Sort();

                if (File.Exists(Globals.FILE_MASTER_CONFIG))
                    Globals.backupFile(Globals.FILE_MASTER_CONFIG, "CONFIGURATION");

                if (globals.cfg.SaveConfigurationToFile(Globals.FILE_MASTER_CONFIG))
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Abort;

            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error on Save!\r\n" + E.Message);
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();




        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Globals.LaunchHelp();
        }


        private bool HasNoSchedEventForSameTime(string eventString, ListBox lstBox)
        {
            bool OkToAdd = true;
            string timeString = string.Empty;

            timeString = eventString.Substring(0, eventString.LastIndexOf(','));
            foreach (string item in lstBox.Items)
            {
                if (item.Contains(timeString))
                {
                    OkToAdd = false;
                    break;
                }
            }

            return OkToAdd;
        }










        private bool SchedHasDaysSelected(Control.ControlCollection cc)
        {
            bool hasSelection = false;
            foreach (object CC in cc)
            {
                Debug.WriteLine(CC.GetType().ToString());
                // //Debug.WriteLine(CC.ToString());
                if (CC.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    CheckBox cb = (CheckBox)CC;
                    //Debug.WriteLine(cb.Name);
                    if (cb.Checked)
                    {
                        hasSelection = true;
                        break;
                    }
                }
            }

            return hasSelection;

        }


        private bool SchedulerHasEventsOfType(string eventName)
        {

            bool result = false;

            foreach (string s in lstSchedules.Items)
            {
                if (s.Contains(eventName))
                {
                    result = true;
                    break;
                }


            }


            return result;

        }


        private void btnAddSched_Click(object sender, EventArgs e)
        {
            if ((lstStartUpProcesses.Items.Count < 1 || lstStopProcessName.Items.Count < 1) && (cmbSchedType.SelectedItem.ToString() == "START" || cmbSchedType.SelectedItem.ToString() == "STOP"))
            {
                Globals.simpleMessageBox("WARNING! You must configure 'Process Start/Stop Control' if you want START/STOP events to work!");
                
                
            }
            else
            {
                if (cmbDayOfWeek.Text.Length > 0 && cmbHours.Text.Length > 0 && cmbMins.Text.Length > 0 && cmbSchedType.Text.Length > 0)
                {
                    string scheduleFile = string.Empty;
                    if (cmbSchedType.Text == "LOAD_SCHEDULE")
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog();

                        openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                        openFileDialog1.Filter = "MISFIT Schedule File (*.msf)|*.msf";
                        openFileDialog1.FilterIndex = 1;
                        openFileDialog1.RestoreDirectory = false;

                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            scheduleFile = "|" + openFileDialog1.FileName;
                        }
                        else
                        {
                            Globals.simpleMessageBox("No file selected!");
                            return;

                        }

                    }
                    
                    
                    
                    
                    
                    
                    string eventstring = cmbDayOfWeek.Text + "," + cmbHours.Text + ":" + cmbMins.Text + "," + cmbSchedType.Text + scheduleFile;
                    if (!lstSchedules.Items.Contains(eventstring))
                        lstSchedules.Items.Add(eventstring);
                    else
                        Globals.simpleMessageBox("Cannot add duplicate event!");
                }
                else
                {
                    Globals.simpleMessageBox("Invalid event schedule!");
                }
                    
            }

        }

        private void btnRemoveSched_Click(object sender, EventArgs e)
        {
            ListBox lstBox = lstSchedules;
            if (lstBox.SelectedIndex >= 0)
            {

                
                DialogResult res = MsgBox.Show("Remove selected items?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    
                    //lstBox.Items.RemoveAt(lstBox.SelectedIndex);
                    
                    List<object> theSelectedItems = new List<object>();
                    foreach (object obj in lstBox.SelectedItems)
                    {
                        theSelectedItems.Add(obj);
                    }    
                    foreach (object obj in theSelectedItems.ToArray())
                    {
                        lstBox.Items.Remove(obj);
                    }

                }
                else
                {
                    lstBox.ClearSelected();

                }
            }
            else
            {
                Globals.simpleMessageBox("Nothing selected to remove");
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        


        private void nudHoursIntervalGIOMResultsUpload_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void a(object sender, EventArgs e)
        {

        }

        private void btnSendSMTPTest_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                Emailer.SendMail(txtSMTPfrom.Text, txtSMTPRecipients.Text, "Test from MISFIT smtp emailer", "Version: " + Globals.VERSION_MISFIT_STRING, txtSMTPServer.Text, int.Parse(txtSMTPport.Text), chkSMTPAuthRequired.Checked, txtSMTPaccountID.Text, txtSMTPpassword.Text, chkSMTPUseTLS.Checked);
                Globals.simpleMessageBox("Sent!");
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error Sending Email\r\n" + E.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void chkSMTPAuthRequired_CheckedChanged(object sender, EventArgs e)
        {
            grpSMTPCredentials.Enabled = !grpSMTPCredentials.Enabled;
        }

        private void txtGimpsPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSMTPpassword_Enter(object sender, EventArgs e)
        {

            //txtSMTPpassword.PasswordChar = (char)0;
        }

        private void txtSMTPpassword_Leave(object sender, EventArgs e)
        {
            //txtSMTPpassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] mySalt = Globals.MISFITCRYPTO_SALT();
            Debug.Write("");
        }




        private void radioWorkFetchDisabled_CheckedChanged(object sender, EventArgs e)
        {
            SetFethingOptions();
        }

        private void SetFethingOptions()
        {
            if (radioWorkFetchDisabled.Checked)
            {
                AutoFetchMode = (int)Config.AutoWorkFetchModes.DISABLED;
                grpFetchNative.Enabled = false;
                grpFetchExternalCommand.Enabled = false;
                grpFetchTrigger.Enabled = false;
            }
            else if (radioWorkFetchExternal.Checked)
            {
                AutoFetchMode = (int)Config.AutoWorkFetchModes.EXTERNAL_COMMAND;
                grpFetchNative.Enabled = false;
                grpFetchExternalCommand.Enabled = true;
                grpFetchTrigger.Enabled = true;
            }
            else if (radioWorkFetchGPU72.Checked)
            {
                AutoFetchMode = (int)Config.AutoWorkFetchModes.GPU72;
                grpFetchNative.Enabled = true;
                lblPledge.Text = "Request TO bit level of 2^";
                lblPledgePart2.Text = "(GPU72 decides final TO bit level)";
                grpFetchExternalCommand.Enabled = false;
                txtGPU72High.Enabled = true;
                txtGPU72Low.Enabled = true;
                grpFetchGPU72.Enabled = true;
                grpFetchTrigger.Enabled = true;
                if (nudGPU72GzDzDaysToFetch.Value > 0 && radioWorkFetchGPU72.Checked)
                    nudGIMPSFetchCount.Enabled = false;
                else
                    nudGIMPSFetchCount.Enabled = true;

                try
                {
                    if (radioWorkFetchGPU72.Checked && (int)cmbFetchGPU72PreferredWork.SelectedValue == (int)Gpu72.GPU72WorkOptionsLLTF.LetGPU72Decide)
                    {
                        txtGPU72High.Enabled = false;
                        txtGPU72Low.Enabled = false;
                        nudWorkBitLevel.Enabled = false;
                    }
                    else
                    {
                        txtGPU72High.Enabled = true;
                        txtGPU72Low.Enabled = true;
                        nudWorkBitLevel.Enabled = true;
                    }
                }
                catch
                {

                }

            }
            else if (radioWorkFetchGIMPS.Checked)
            {
                AutoFetchMode = (int)Config.AutoWorkFetchModes.GIMPS;
                grpFetchNative.Enabled = true;
                grpFetchExternalCommand.Enabled = false;
                lblPledge.Text = "Re-write TO bit level to 2^";
                lblPledgePart2.Text = "(won't reduce higher levels)";
                grpFetchGPU72.Enabled = false;
                grpFetchTrigger.Enabled = true;
                nudWorkBitLevel.Enabled = true;
                nudGIMPSFetchCount.Enabled = true;
            }


        }

        private void radioWorkFetchGIMPS_CheckedChanged(object sender, EventArgs e)
        {
            SetFethingOptions();
        }

        private void radioWorkFetchGPU72_CheckedChanged(object sender, EventArgs e)
        {
            SetFethingOptions();
        }

        private void radioWorkFetchExternal_CheckedChanged(object sender, EventArgs e)
        {
            SetFethingOptions();
        }

        private void btnAutoConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                frmAutoConfigCrap frm = new frmAutoConfigCrap();
                frm.calcBitLevel = (int)this.nudWorkBitLevel.Value;
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    nudDrainMISFITWorkWhenBelow.Value = frm.calcDrainThreshold;
                    nudGIMPSFetchCount.Value = frm.calcNumToFetch;
                    nudWorkBitLevel.Value = frm.calcBitLevel;
                    nudWorkFetchGhDzThreshold.Value = frm.calcFetchThreshold;
                    nudNotifyWhenGHZdaysDropsBelow.Value = frm.calcAlertAt;
                    nudMaxGzDzToAssignDuringDrain.Value = frm.calcGhDzToAssign;
                    nudGPU72GzDzDaysToFetch.Value = frm.calcGhDzToFetch;

                }
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }





        private void cmbGpu72TestType_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cmbGpu72TestType.SelectedIndex)
            {

                case 0:
                    cmbFetchGPU72PreferredWork.DataSource = this.Gpu72LLTFoptions.ToList();
                    cmbFetchGPU72PreferredWork.ValueMember = "Key";
                    cmbFetchGPU72PreferredWork.DisplayMember = "Value";
                    break;
                case 1:
                    cmbFetchGPU72PreferredWork.DataSource = this.Gpu72DCTFoptions.ToList();
                    cmbFetchGPU72PreferredWork.ValueMember = "Key";
                    cmbFetchGPU72PreferredWork.DisplayMember = "Value";
                    break;

            }

        }

        private void cmbFetchGPU72PreferredWork_SelectedValueChanged(object sender, EventArgs e)
        {
            SetFethingOptions();
        }

        private void nudGPU72GzDzDaysToFetch_ValueChanged(object sender, EventArgs e)
        {
            if (nudGPU72GzDzDaysToFetch.Value > 0 && radioWorkFetchGPU72.Checked)
                nudGIMPSFetchCount.Enabled = false;
            else
                nudGIMPSFetchCount.Enabled = true;
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            string msg = @"On this screen you build schedules you want MISFIT to follow. 
There are four commands that MISFIT uses to process events.

START (Will start up mfaktX instances that are configured in the Process Setup tab)

STOP (Will stop mfaktX instances that are configured in the Process Setup tab)

UPLOAD_RESULTS (Will extract the completed data from results.txt file and upload to GIMPS)

LOAD_SCHEDULE (Will load the specified schedule file thereby replacing the current schedule. This is called schedule chaining.)

LOAD_DEFAULT_SCHEDULE (Reloads the default schedule. This command is only allowed in external schedule files.)

Days of the week start on Sunday=0, Monday=1 etc.
Days and Hours can be wildcarded using '*'
External schedule files are text files containing schedule syntax and have an extension of .msf

*****************************************************
The below section are examples you can use if you are going to build schedule files yourself. 
External schedule files are completely optional but provide a means to develop very complex scheduling implementations.

Each schedule begins with the keyword 'Scheduler:' followed by the action time and the command.
Examples:
To upload results every sunday at 09:15->  Scheduler:0,09:15,UPLOAD_RESULTS

To upload results every hour at 30 minutes past the hour->  Scheduler:*,*:30,UPLOAD_RESULTS

To start processing on Mondays at 1:00 pm -> Scheduler:1,13:00,START

To stop processing on Mondays at 11:00 pm -> Scheduler:1,23:00,STOP

To load another schedule starting on Saturday at 8:30am -> Scheduler:6,08:30,LOAD_SCHEDULE|c:\abc\xyz\saturdayz.msf

To reload the default schedule on Sunday at 9:40am ->  Scheduler:0,09:40,LOAD_DEFAULT_SCHEDULE

So where is what all the examples would look like in a file

Scheduler:0,09:15,UPLOAD_RESULTS
Scheduler:*,*:30,UPLOAD_RESULTS
Scheduler:1,13:00,START
Scheduler:1,23:00,STOP
Scheduler:6,08:30,LOAD_SCHEDULE|c:\abc\xyz\saturdayz.msf

************************

Here's another example where factoring runs on a 30 minute duty cycle with results uploading every 6 hours

Scheduler:*,*:00,START
Scheduler:*,*:30,STOP
Scheduler:*,00:37,UPLOAD_RESULTS
Scheduler:*,04:37,UPLOAD_RESULTS
Scheduler:*,08:37,UPLOAD_RESULTS
Scheduler:*,12:37,UPLOAD_RESULTS
Scheduler:*,16:37,UPLOAD_RESULTS
Scheduler:*,20:37,UPLOAD_RESULTS


";
            try
            {
                File.WriteAllText("_ScheduleHelp.txt", msg);
                Process.Start("_ScheduleHelp.txt");
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
          
        }

        private void chkUseWorkToDoAdd_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        











    }
}
