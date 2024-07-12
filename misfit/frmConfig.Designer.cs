namespace MISFIT
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstMFinstances = new System.Windows.Forms.ListBox();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRemoveLocation = new System.Windows.Forms.Button();
            this.btnRemoveStartupProcess = new System.Windows.Forms.Button();
            this.btnAddStartupProcesses = new System.Windows.Forms.Button();
            this.lstStartUpProcesses = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudProcessStartDelay = new System.Windows.Forms.NumericUpDown();
            this.chkSetWorkingDir = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPstopInfo = new System.Windows.Forms.TextBox();
            this.btnRemoveStopProcessName = new System.Windows.Forms.Button();
            this.btnAddStopProcessName = new System.Windows.Forms.Button();
            this.txtStopProcessName = new System.Windows.Forms.TextBox();
            this.lstStopProcessName = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUseWorkToDoAdd = new System.Windows.Forms.CheckBox();
            this.chkHoldBackUnfinishedExponents = new System.Windows.Forms.CheckBox();
            this.chkStartWithStallDetectionSuspended = new System.Windows.Forms.CheckBox();
            this.chkShowProductivityAsAverages = new System.Windows.Forms.CheckBox();
            this.chkIncludeBitLevelOnDupDetection = new System.Windows.Forms.CheckBox();
            this.nudPurgeLogsDaysOld = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.chkMinimizeToSysTray = new System.Windows.Forms.CheckBox();
            this.txtExportResultsURL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShowResultsInExternalViewer = new System.Windows.Forms.CheckBox();
            this.chkShowConfDialogs = new System.Windows.Forms.CheckBox();
            this.txtLaunchURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.cmbMins = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.chkSchedulesEnabled = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemoveSched = new System.Windows.Forms.Button();
            this.lstSchedules = new System.Windows.Forms.ListBox();
            this.cmbSchedType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddSched = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nudStalledResultsMaxMinutes = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.grpFetchTrigger = new System.Windows.Forms.GroupBox();
            this.btnAutoConfigure = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.nudMISFITworkToDoCheckInterval = new System.Windows.Forms.NumericUpDown();
            this.lblFetchThreshold = new System.Windows.Forms.Label();
            this.nudWorkFetchGhDzThreshold = new System.Windows.Forms.NumericUpDown();
            this.grpFetchExternalCommand = new System.Windows.Forms.GroupBox();
            this.txtPreDrainCommandArguments = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPreDrainCommand = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.radioWorkFetchDisabled = new System.Windows.Forms.RadioButton();
            this.radioWorkFetchExternal = new System.Windows.Forms.RadioButton();
            this.radioWorkFetchGPU72 = new System.Windows.Forms.RadioButton();
            this.radioWorkFetchGIMPS = new System.Windows.Forms.RadioButton();
            this.grpFetchNative = new System.Windows.Forms.GroupBox();
            this.lblPledgePart2 = new System.Windows.Forms.Label();
            this.grpFetchGPU72 = new System.Windows.Forms.GroupBox();
            this.nudGPU72GzDzDaysToFetch = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cmbGpu72TestType = new System.Windows.Forms.ComboBox();
            this.chkGPU72FallBack = new System.Windows.Forms.CheckBox();
            this.txtGPU72High = new System.Windows.Forms.TextBox();
            this.txtGPU72Low = new System.Windows.Forms.TextBox();
            this.cmbFetchGPU72PreferredWork = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblPledge = new System.Windows.Forms.Label();
            this.chkGIMPSReplaceGUIDs = new System.Windows.Forms.CheckBox();
            this.nudWorkBitLevel = new System.Windows.Forms.NumericUpDown();
            this.nudGIMPSFetchCount = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkShowWorkingFactorInPhases = new System.Windows.Forms.CheckBox();
            this.nudMaxGzDzToAssignDuringDrain = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.nudNotifyWhenGHZdaysDropsBelow = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudDrainMISFITWorkWhenBelow = new System.Windows.Forms.NumericUpDown();
            this.nudBalanceWorkDifference = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtGPU72UserID = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtGPU72Password = new System.Windows.Forms.TextBox();
            this.txtCryptoInfo = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.grpSMTPCredentials = new System.Windows.Forms.GroupBox();
            this.txtSMTPaccountID = new System.Windows.Forms.TextBox();
            this.txtSMTPpassword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSMTPUseTLS = new System.Windows.Forms.CheckBox();
            this.chkSMTPAuthRequired = new System.Windows.Forms.CheckBox();
            this.txtSMTPfrom = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSMTPRecipients = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSendSMTPTest = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtSMTPport = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtGimpsUserID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGIMPSPassword = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectGIOMPanelOpen = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.chkEmailWhenGIOMPanelRemainsOpen = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectAlertPanelOpen = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.chkEmailWhenAlertPanelRemainsOpen = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectStats = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.chkEmailStatsBeforeWorkFetch = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectLowGHZDsToDo = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectExtenralFetchResults = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.chkEmailOnLowWork = new System.Windows.Forms.CheckBox();
            this.chkEmailPreAssignRunResult = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmailSubjectStalledProcess = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEmailOnStalledProcessDetection = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProcessStartDelay)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurgeLogsDaysOld)).BeginInit();
            this.grpSchedule.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStalledResultsMaxMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateInterval)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.grpFetchTrigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMISFITworkToDoCheckInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkFetchGhDzThreshold)).BeginInit();
            this.grpFetchExternalCommand.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.grpFetchNative.SuspendLayout();
            this.grpFetchGPU72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPU72GzDzDaysToFetch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkBitLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGIMPSFetchCount)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGzDzToAssignDuringDrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNotifyWhenGHZdaysDropsBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrainMISFITWorkWhenBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBalanceWorkDifference)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpSMTPCredentials.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMFinstances
            // 
            this.lstMFinstances.FormattingEnabled = true;
            this.lstMFinstances.Location = new System.Drawing.Point(9, 32);
            this.lstMFinstances.Name = "lstMFinstances";
            this.lstMFinstances.Size = new System.Drawing.Size(370, 56);
            this.lstMFinstances.TabIndex = 1;
            this.lstMFinstances.TabStop = false;
            this.toolTip1.SetToolTip(this.lstMFinstances, "Locations of instances");
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(385, 32);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(71, 22);
            this.btnAddLocation.TabIndex = 2;
            this.btnAddLocation.Text = "Browse";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnRemoveLocation
            // 
            this.btnRemoveLocation.Location = new System.Drawing.Point(385, 60);
            this.btnRemoveLocation.Name = "btnRemoveLocation";
            this.btnRemoveLocation.Size = new System.Drawing.Size(71, 22);
            this.btnRemoveLocation.TabIndex = 3;
            this.btnRemoveLocation.Text = "Remove";
            this.btnRemoveLocation.UseVisualStyleBackColor = true;
            this.btnRemoveLocation.Click += new System.EventHandler(this.btnRemoveLocation_Click);
            // 
            // btnRemoveStartupProcess
            // 
            this.btnRemoveStartupProcess.Location = new System.Drawing.Point(385, 63);
            this.btnRemoveStartupProcess.Name = "btnRemoveStartupProcess";
            this.btnRemoveStartupProcess.Size = new System.Drawing.Size(71, 22);
            this.btnRemoveStartupProcess.TabIndex = 10;
            this.btnRemoveStartupProcess.Text = "Remove";
            this.btnRemoveStartupProcess.UseVisualStyleBackColor = true;
            this.btnRemoveStartupProcess.Click += new System.EventHandler(this.btnRemoveStartupProcess_Click);
            // 
            // btnAddStartupProcesses
            // 
            this.btnAddStartupProcesses.Location = new System.Drawing.Point(385, 35);
            this.btnAddStartupProcesses.Name = "btnAddStartupProcesses";
            this.btnAddStartupProcesses.Size = new System.Drawing.Size(71, 22);
            this.btnAddStartupProcesses.TabIndex = 9;
            this.btnAddStartupProcesses.Text = "Browse";
            this.btnAddStartupProcesses.UseVisualStyleBackColor = true;
            this.btnAddStartupProcesses.Click += new System.EventHandler(this.btnAddStartupProcesses_Click);
            // 
            // lstStartUpProcesses
            // 
            this.lstStartUpProcesses.FormattingEnabled = true;
            this.lstStartUpProcesses.Location = new System.Drawing.Point(9, 35);
            this.lstStartUpProcesses.Name = "lstStartUpProcesses";
            this.lstStartUpProcesses.Size = new System.Drawing.Size(370, 56);
            this.lstStartUpProcesses.TabIndex = 8;
            this.lstStartUpProcesses.TabStop = false;
            this.toolTip1.SetToolTip(this.lstStartUpProcesses, "Locations of startup executables");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudProcessStartDelay);
            this.groupBox1.Controls.Add(this.chkSetWorkingDir);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnRemoveStartupProcess);
            this.groupBox1.Controls.Add(this.lstStartUpProcesses);
            this.groupBox1.Controls.Add(this.btnAddStartupProcesses);
            this.groupBox1.Location = new System.Drawing.Point(6, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 131);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MFAKTx Startup Control";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Seconds between process start";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudProcessStartDelay
            // 
            this.nudProcessStartDelay.Location = new System.Drawing.Point(385, 97);
            this.nudProcessStartDelay.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudProcessStartDelay.Name = "nudProcessStartDelay";
            this.nudProcessStartDelay.Size = new System.Drawing.Size(47, 20);
            this.nudProcessStartDelay.TabIndex = 42;
            this.nudProcessStartDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkSetWorkingDir
            // 
            this.chkSetWorkingDir.AutoSize = true;
            this.chkSetWorkingDir.Location = new System.Drawing.Point(9, 97);
            this.chkSetWorkingDir.Name = "chkSetWorkingDir";
            this.chkSetWorkingDir.Size = new System.Drawing.Size(160, 17);
            this.chkSetWorkingDir.TabIndex = 20;
            this.chkSetWorkingDir.Text = "Set process default directory";
            this.toolTip1.SetToolTip(this.chkSetWorkingDir, "Force OS to start process from specified directory");
            this.chkSetWorkingDir.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(282, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Programs to start (batch files to launch MFAKTx instances)";
            // 
            // txtPstopInfo
            // 
            this.txtPstopInfo.Location = new System.Drawing.Point(197, 17);
            this.txtPstopInfo.Multiline = true;
            this.txtPstopInfo.Name = "txtPstopInfo";
            this.txtPstopInfo.ReadOnly = true;
            this.txtPstopInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPstopInfo.Size = new System.Drawing.Size(259, 85);
            this.txtPstopInfo.TabIndex = 55;
            this.txtPstopInfo.TabStop = false;
            // 
            // btnRemoveStopProcessName
            // 
            this.btnRemoveStopProcessName.Location = new System.Drawing.Point(120, 59);
            this.btnRemoveStopProcessName.Name = "btnRemoveStopProcessName";
            this.btnRemoveStopProcessName.Size = new System.Drawing.Size(71, 22);
            this.btnRemoveStopProcessName.TabIndex = 60;
            this.btnRemoveStopProcessName.Text = "Remove";
            this.btnRemoveStopProcessName.UseVisualStyleBackColor = true;
            this.btnRemoveStopProcessName.Click += new System.EventHandler(this.btnRemoveStopProcessName_Click);
            // 
            // btnAddStopProcessName
            // 
            this.btnAddStopProcessName.Location = new System.Drawing.Point(120, 33);
            this.btnAddStopProcessName.Name = "btnAddStopProcessName";
            this.btnAddStopProcessName.Size = new System.Drawing.Size(71, 22);
            this.btnAddStopProcessName.TabIndex = 51;
            this.btnAddStopProcessName.Text = "Add";
            this.btnAddStopProcessName.UseVisualStyleBackColor = true;
            this.btnAddStopProcessName.Click += new System.EventHandler(this.btnAddStopProcessName_Click);
            // 
            // txtStopProcessName
            // 
            this.txtStopProcessName.Location = new System.Drawing.Point(12, 33);
            this.txtStopProcessName.Name = "txtStopProcessName";
            this.txtStopProcessName.Size = new System.Drawing.Size(102, 20);
            this.txtStopProcessName.TabIndex = 50;
            // 
            // lstStopProcessName
            // 
            this.lstStopProcessName.FormattingEnabled = true;
            this.lstStopProcessName.Location = new System.Drawing.Point(12, 59);
            this.lstStopProcessName.Name = "lstStopProcessName";
            this.lstStopProcessName.Size = new System.Drawing.Size(102, 43);
            this.lstStopProcessName.TabIndex = 68;
            this.lstStopProcessName.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Process names to stop";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstMFinstances);
            this.groupBox2.Controls.Add(this.btnAddLocation);
            this.groupBox2.Controls.Add(this.btnRemoveLocation);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MFAKTx Instances Locations";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUseWorkToDoAdd);
            this.groupBox3.Controls.Add(this.chkHoldBackUnfinishedExponents);
            this.groupBox3.Controls.Add(this.chkStartWithStallDetectionSuspended);
            this.groupBox3.Controls.Add(this.chkShowProductivityAsAverages);
            this.groupBox3.Controls.Add(this.chkIncludeBitLevelOnDupDetection);
            this.groupBox3.Controls.Add(this.nudPurgeLogsDaysOld);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.chkMinimizeToSysTray);
            this.groupBox3.Controls.Add(this.txtExportResultsURL);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkShowResultsInExternalViewer);
            this.groupBox3.Controls.Add(this.chkShowConfDialogs);
            this.groupBox3.Controls.Add(this.txtLaunchURL);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 352);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc";
            // 
            // chkUseWorkToDoAdd
            // 
            this.chkUseWorkToDoAdd.AutoSize = true;
            this.chkUseWorkToDoAdd.Location = new System.Drawing.Point(11, 194);
            this.chkUseWorkToDoAdd.Name = "chkUseWorkToDoAdd";
            this.chkUseWorkToDoAdd.Size = new System.Drawing.Size(335, 17);
            this.chkUseWorkToDoAdd.TabIndex = 568;
            this.chkUseWorkToDoAdd.Text = "Assign work into WorkToDo.Add  (be sure MFAKTx is configured)";
            this.toolTip1.SetToolTip(this.chkUseWorkToDoAdd, "De-queue work into WorkToDo.Add instead of directly into WorkToDo.Txt");
            this.chkUseWorkToDoAdd.UseVisualStyleBackColor = true;
            // 
            // chkHoldBackUnfinishedExponents
            // 
            this.chkHoldBackUnfinishedExponents.AutoSize = true;
            this.chkHoldBackUnfinishedExponents.Location = new System.Drawing.Point(11, 171);
            this.chkHoldBackUnfinishedExponents.Name = "chkHoldBackUnfinishedExponents";
            this.chkHoldBackUnfinishedExponents.Size = new System.Drawing.Size(154, 17);
            this.chkHoldBackUnfinishedExponents.TabIndex = 531;
            this.chkHoldBackUnfinishedExponents.Text = "Do not export partial results";
            this.toolTip1.SetToolTip(this.chkHoldBackUnfinishedExponents, "MISFIT will not turn in work for an exponent range that is not 100% completed");
            this.chkHoldBackUnfinishedExponents.UseVisualStyleBackColor = true;
            // 
            // chkStartWithStallDetectionSuspended
            // 
            this.chkStartWithStallDetectionSuspended.AutoSize = true;
            this.chkStartWithStallDetectionSuspended.Location = new System.Drawing.Point(11, 146);
            this.chkStartWithStallDetectionSuspended.Name = "chkStartWithStallDetectionSuspended";
            this.chkStartWithStallDetectionSuspended.Size = new System.Drawing.Size(221, 17);
            this.chkStartWithStallDetectionSuspended.TabIndex = 529;
            this.chkStartWithStallDetectionSuspended.Text = "Startup with Stalled Detection suspended";
            this.toolTip1.SetToolTip(this.chkStartWithStallDetectionSuspended, "Detection is enabled when MISFIT performs a Process Startup");
            this.chkStartWithStallDetectionSuspended.UseVisualStyleBackColor = true;
            // 
            // chkShowProductivityAsAverages
            // 
            this.chkShowProductivityAsAverages.AutoSize = true;
            this.chkShowProductivityAsAverages.Location = new System.Drawing.Point(11, 121);
            this.chkShowProductivityAsAverages.Name = "chkShowProductivityAsAverages";
            this.chkShowProductivityAsAverages.Size = new System.Drawing.Size(203, 17);
            this.chkShowProductivityAsAverages.TabIndex = 527;
            this.chkShowProductivityAsAverages.Text = "Show \'Productivity Stats\' as averages";
            this.toolTip1.SetToolTip(this.chkShowProductivityAsAverages, "On=averages, Off=actuals");
            this.chkShowProductivityAsAverages.UseVisualStyleBackColor = true;
            // 
            // chkIncludeBitLevelOnDupDetection
            // 
            this.chkIncludeBitLevelOnDupDetection.AutoSize = true;
            this.chkIncludeBitLevelOnDupDetection.Location = new System.Drawing.Point(11, 98);
            this.chkIncludeBitLevelOnDupDetection.Name = "chkIncludeBitLevelOnDupDetection";
            this.chkIncludeBitLevelOnDupDetection.Size = new System.Drawing.Size(294, 17);
            this.chkIncludeBitLevelOnDupDetection.TabIndex = 520;
            this.chkIncludeBitLevelOnDupDetection.Text = "Assess bit level as part of duplicate assignment detection";
            this.toolTip1.SetToolTip(this.chkIncludeBitLevelOnDupDetection, "On detects any duplicated exponent. Off will allow duplicate exponents if the bit" +
        " levels are unique");
            this.chkIncludeBitLevelOnDupDetection.UseVisualStyleBackColor = true;
            // 
            // nudPurgeLogsDaysOld
            // 
            this.nudPurgeLogsDaysOld.Increment = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudPurgeLogsDaysOld.Location = new System.Drawing.Point(216, 224);
            this.nudPurgeLogsDaysOld.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudPurgeLogsDaysOld.Name = "nudPurgeLogsDaysOld";
            this.nudPurgeLogsDaysOld.Size = new System.Drawing.Size(47, 20);
            this.nudPurgeLogsDaysOld.TabIndex = 545;
            this.toolTip1.SetToolTip(this.nudPurgeLogsDaysOld, "Controls the deletion of aged MISFIT log files");
            this.nudPurgeLogsDaysOld.Value = new decimal(new int[] {
            365,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(9, 228);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(181, 13);
            this.label39.TabIndex = 567;
            this.label39.Text = "Purge log files older than days (0=off)";
            // 
            // chkMinimizeToSysTray
            // 
            this.chkMinimizeToSysTray.AutoSize = true;
            this.chkMinimizeToSysTray.Location = new System.Drawing.Point(11, 73);
            this.chkMinimizeToSysTray.Name = "chkMinimizeToSysTray";
            this.chkMinimizeToSysTray.Size = new System.Drawing.Size(139, 17);
            this.chkMinimizeToSysTray.TabIndex = 510;
            this.chkMinimizeToSysTray.Text = "Minimize to System Tray";
            this.toolTip1.SetToolTip(this.chkMinimizeToSysTray, "You\'ll have to guess what this does");
            this.chkMinimizeToSysTray.UseVisualStyleBackColor = true;
            // 
            // txtExportResultsURL
            // 
            this.txtExportResultsURL.Location = new System.Drawing.Point(91, 276);
            this.txtExportResultsURL.Name = "txtExportResultsURL";
            this.txtExportResultsURL.Size = new System.Drawing.Size(371, 20);
            this.txtExportResultsURL.TabIndex = 565;
            this.toolTip1.SetToolTip(this.txtExportResultsURL, "URL to launch if uploading results is disabled");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Results URL";
            // 
            // chkShowResultsInExternalViewer
            // 
            this.chkShowResultsInExternalViewer.AutoSize = true;
            this.chkShowResultsInExternalViewer.Location = new System.Drawing.Point(11, 48);
            this.chkShowResultsInExternalViewer.Name = "chkShowResultsInExternalViewer";
            this.chkShowResultsInExternalViewer.Size = new System.Drawing.Size(215, 17);
            this.chkShowResultsInExternalViewer.TabIndex = 505;
            this.chkShowResultsInExternalViewer.Text = "Show exported results in external viewer";
            this.toolTip1.SetToolTip(this.chkShowResultsInExternalViewer, "After processing results file(s) open the file in default application for .txt fi" +
        "les");
            this.chkShowResultsInExternalViewer.UseVisualStyleBackColor = true;
            // 
            // chkShowConfDialogs
            // 
            this.chkShowConfDialogs.AutoSize = true;
            this.chkShowConfDialogs.Location = new System.Drawing.Point(11, 23);
            this.chkShowConfDialogs.Name = "chkShowConfDialogs";
            this.chkShowConfDialogs.Size = new System.Drawing.Size(149, 17);
            this.chkShowConfDialogs.TabIndex = 500;
            this.chkShowConfDialogs.Text = "Show confirmation dialogs";
            this.toolTip1.SetToolTip(this.chkShowConfDialogs, "MISFIT will prompt you to confirm actions");
            this.chkShowConfDialogs.UseVisualStyleBackColor = true;
            // 
            // txtLaunchURL
            // 
            this.txtLaunchURL.Location = new System.Drawing.Point(91, 250);
            this.txtLaunchURL.Name = "txtLaunchURL";
            this.txtLaunchURL.Size = new System.Drawing.Size(371, 20);
            this.txtLaunchURL.TabIndex = 560;
            this.toolTip1.SetToolTip(this.txtLaunchURL, "URL to launch from the \'Favorite URL\' button");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Favorite URL";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 28);
            this.btnSave.TabIndex = 12002;
            this.btnSave.Text = "&Save All";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 28);
            this.btnCancel.TabIndex = 12000;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // grpSchedule
            // 
            this.grpSchedule.Controls.Add(this.btnHelp);
            this.grpSchedule.Controls.Add(this.textBox1);
            this.grpSchedule.Controls.Add(this.label46);
            this.grpSchedule.Controls.Add(this.cmbMins);
            this.grpSchedule.Controls.Add(this.label29);
            this.grpSchedule.Controls.Add(this.cmbDayOfWeek);
            this.grpSchedule.Controls.Add(this.cmbHours);
            this.grpSchedule.Controls.Add(this.chkSchedulesEnabled);
            this.grpSchedule.Controls.Add(this.label11);
            this.grpSchedule.Controls.Add(this.btnRemoveSched);
            this.grpSchedule.Controls.Add(this.lstSchedules);
            this.grpSchedule.Controls.Add(this.cmbSchedType);
            this.grpSchedule.Controls.Add(this.label9);
            this.grpSchedule.Controls.Add(this.btnAddSched);
            this.grpSchedule.Controls.Add(this.label10);
            this.grpSchedule.Location = new System.Drawing.Point(13, 59);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Size = new System.Drawing.Size(456, 311);
            this.grpSchedule.TabIndex = 110;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "Event Scheduling";
            this.toolTip1.SetToolTip(this.grpSchedule, "Schedule specific events");
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(377, 13);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(73, 26);
            this.btnHelp.TabIndex = 115;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 220);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(356, 59);
            this.textBox1.TabIndex = 577;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "NOTE: The scheduler has a resolution of ONE minute and is only lightly protected " +
    "from scheduling conflicts. Time conflicts must be avoided.";
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(12, 45);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(427, 18);
            this.label46.TabIndex = 575;
            this.label46.Text = "Tips: Day 0=Sunday.  Day and Hour can be wildcarded by using *";
            // 
            // cmbMins
            // 
            this.cmbMins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMins.FormattingEnabled = true;
            this.cmbMins.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            ""});
            this.cmbMins.Location = new System.Drawing.Point(208, 66);
            this.cmbMins.Name = "cmbMins";
            this.cmbMins.Size = new System.Drawing.Size(43, 21);
            this.cmbMins.TabIndex = 130;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(26, 13);
            this.label29.TabIndex = 573;
            this.label29.Text = "Day";
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOfWeek.FormattingEnabled = true;
            this.cmbDayOfWeek.Items.AddRange(new object[] {
            "*",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbDayOfWeek.Location = new System.Drawing.Point(44, 66);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(43, 21);
            this.cmbDayOfWeek.TabIndex = 122;
            // 
            // cmbHours
            // 
            this.cmbHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Items.AddRange(new object[] {
            "*",
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbHours.Location = new System.Drawing.Point(129, 66);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(43, 21);
            this.cmbHours.TabIndex = 124;
            // 
            // chkSchedulesEnabled
            // 
            this.chkSchedulesEnabled.AutoSize = true;
            this.chkSchedulesEnabled.Location = new System.Drawing.Point(15, 19);
            this.chkSchedulesEnabled.Name = "chkSchedulesEnabled";
            this.chkSchedulesEnabled.Size = new System.Drawing.Size(110, 17);
            this.chkSchedulesEnabled.TabIndex = 111;
            this.chkSchedulesEnabled.Text = "Enable Scheduler";
            this.chkSchedulesEnabled.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Event";
            // 
            // btnRemoveSched
            // 
            this.btnRemoveSched.Location = new System.Drawing.Point(377, 188);
            this.btnRemoveSched.Name = "btnRemoveSched";
            this.btnRemoveSched.Size = new System.Drawing.Size(73, 26);
            this.btnRemoveSched.TabIndex = 160;
            this.btnRemoveSched.Text = "Remove";
            this.btnRemoveSched.UseVisualStyleBackColor = true;
            this.btnRemoveSched.Click += new System.EventHandler(this.btnRemoveSched_Click);
            // 
            // lstSchedules
            // 
            this.lstSchedules.FormattingEnabled = true;
            this.lstSchedules.Location = new System.Drawing.Point(15, 93);
            this.lstSchedules.Name = "lstSchedules";
            this.lstSchedules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSchedules.Size = new System.Drawing.Size(356, 121);
            this.lstSchedules.TabIndex = 150;
            this.lstSchedules.TabStop = false;
            // 
            // cmbSchedType
            // 
            this.cmbSchedType.FormattingEnabled = true;
            this.cmbSchedType.Items.AddRange(new object[] {
            "",
            "START",
            "STOP",
            "UPLOAD_RESULTS",
            "LOAD_SCHEDULE"});
            this.cmbSchedType.Location = new System.Drawing.Point(307, 66);
            this.cmbSchedType.Name = "cmbSchedType";
            this.cmbSchedType.Size = new System.Drawing.Size(143, 21);
            this.cmbSchedType.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Hour";
            // 
            // btnAddSched
            // 
            this.btnAddSched.Location = new System.Drawing.Point(377, 93);
            this.btnAddSched.Name = "btnAddSched";
            this.btnAddSched.Size = new System.Drawing.Size(73, 26);
            this.btnAddSched.TabIndex = 140;
            this.btnAddSched.Text = "Add";
            this.btnAddSched.UseVisualStyleBackColor = true;
            this.btnAddSched.Click += new System.EventHandler(this.btnAddSched_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Min";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPstopInfo);
            this.groupBox4.Controls.Add(this.btnRemoveStopProcessName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnAddStopProcessName);
            this.groupBox4.Controls.Add(this.lstStopProcessName);
            this.groupBox4.Controls.Add(this.txtStopProcessName);
            this.groupBox4.Location = new System.Drawing.Point(6, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(462, 112);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MFAKTx CTRL-C Signaling";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 413);
            this.tabControl1.TabIndex = 26;
            this.tabControl1.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(474, 387);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Process Setup";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.nudStalledResultsMaxMinutes);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.nudUpdateInterval);
            this.tabPage2.Controls.Add(this.grpSchedule);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(474, 387);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Scheduling";
            // 
            // nudStalledResultsMaxMinutes
            // 
            this.nudStalledResultsMaxMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudStalledResultsMaxMinutes.Location = new System.Drawing.Point(235, 33);
            this.nudStalledResultsMaxMinutes.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudStalledResultsMaxMinutes.Name = "nudStalledResultsMaxMinutes";
            this.nudStalledResultsMaxMinutes.Size = new System.Drawing.Size(47, 20);
            this.nudStalledResultsMaxMinutes.TabIndex = 104;
            this.toolTip1.SetToolTip(this.nudStalledResultsMaxMinutes, "Frequency to check instances for possible stalled processes.");
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 35);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(221, 13);
            this.label28.TabIndex = 534;
            this.label28.Text = "Minutes process is stalled before alarm (0=off)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(291, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(148, 18);
            this.label19.TabIndex = 569;
            this.label19.Text = "-Required for automation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 568;
            this.label2.Text = "Auto update stats minutes (0=off)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudUpdateInterval
            // 
            this.nudUpdateInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudUpdateInterval.Location = new System.Drawing.Point(235, 7);
            this.nudUpdateInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudUpdateInterval.Name = "nudUpdateInterval";
            this.nudUpdateInterval.Size = new System.Drawing.Size(47, 20);
            this.nudUpdateInterval.TabIndex = 100;
            this.toolTip1.SetToolTip(this.nudUpdateInterval, "Frequency of updating the statistics grid");
            this.nudUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage6.Controls.Add(this.grpFetchTrigger);
            this.tabPage6.Controls.Add(this.grpFetchExternalCommand);
            this.tabPage6.Controls.Add(this.groupBox12);
            this.tabPage6.Controls.Add(this.grpFetchNative);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(474, 387);
            this.tabPage6.TabIndex = 7;
            this.tabPage6.Text = "Work Fetch";
            // 
            // grpFetchTrigger
            // 
            this.grpFetchTrigger.Controls.Add(this.btnAutoConfigure);
            this.grpFetchTrigger.Controls.Add(this.label22);
            this.grpFetchTrigger.Controls.Add(this.nudMISFITworkToDoCheckInterval);
            this.grpFetchTrigger.Controls.Add(this.lblFetchThreshold);
            this.grpFetchTrigger.Controls.Add(this.nudWorkFetchGhDzThreshold);
            this.grpFetchTrigger.Location = new System.Drawing.Point(6, 56);
            this.grpFetchTrigger.Name = "grpFetchTrigger";
            this.grpFetchTrigger.Size = new System.Drawing.Size(462, 77);
            this.grpFetchTrigger.TabIndex = 6010;
            this.grpFetchTrigger.TabStop = false;
            this.grpFetchTrigger.Text = "Fetch Trigger";
            // 
            // btnAutoConfigure
            // 
            this.btnAutoConfigure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAutoConfigure.ForeColor = System.Drawing.Color.Yellow;
            this.btnAutoConfigure.Location = new System.Drawing.Point(322, 25);
            this.btnAutoConfigure.Name = "btnAutoConfigure";
            this.btnAutoConfigure.Size = new System.Drawing.Size(134, 38);
            this.btnAutoConfigure.TabIndex = 6014;
            this.btnAutoConfigure.Text = "Work Calculator";
            this.toolTip1.SetToolTip(this.btnAutoConfigure, "Work calculator eases configuration of this form");
            this.btnAutoConfigure.UseVisualStyleBackColor = false;
            this.btnAutoConfigure.Click += new System.EventHandler(this.btnAutoConfigure_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(190, 13);
            this.label22.TabIndex = 580;
            this.label22.Text = "Check MISFITworkToDo every (hours)";
            // 
            // nudMISFITworkToDoCheckInterval
            // 
            this.nudMISFITworkToDoCheckInterval.BackColor = System.Drawing.SystemColors.Window;
            this.nudMISFITworkToDoCheckInterval.Location = new System.Drawing.Point(258, 21);
            this.nudMISFITworkToDoCheckInterval.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudMISFITworkToDoCheckInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMISFITworkToDoCheckInterval.Name = "nudMISFITworkToDoCheckInterval";
            this.nudMISFITworkToDoCheckInterval.Size = new System.Drawing.Size(58, 20);
            this.nudMISFITworkToDoCheckInterval.TabIndex = 6012;
            this.toolTip1.SetToolTip(this.nudMISFITworkToDoCheckInterval, "Frequency to check staged work");
            this.nudMISFITworkToDoCheckInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFetchThreshold
            // 
            this.lblFetchThreshold.AutoSize = true;
            this.lblFetchThreshold.Location = new System.Drawing.Point(6, 50);
            this.lblFetchThreshold.Name = "lblFetchThreshold";
            this.lblFetchThreshold.Size = new System.Drawing.Size(248, 13);
            this.lblFetchThreshold.TabIndex = 578;
            this.lblFetchThreshold.Text = "Fetch when MISFITworkToDo GHzDs drops below";
            // 
            // nudWorkFetchGhDzThreshold
            // 
            this.nudWorkFetchGhDzThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.nudWorkFetchGhDzThreshold.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudWorkFetchGhDzThreshold.Location = new System.Drawing.Point(258, 46);
            this.nudWorkFetchGhDzThreshold.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudWorkFetchGhDzThreshold.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudWorkFetchGhDzThreshold.Name = "nudWorkFetchGhDzThreshold";
            this.nudWorkFetchGhDzThreshold.Size = new System.Drawing.Size(58, 20);
            this.nudWorkFetchGhDzThreshold.TabIndex = 6013;
            this.toolTip1.SetToolTip(this.nudWorkFetchGhDzThreshold, "Threshold to fetch more work");
            this.nudWorkFetchGhDzThreshold.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // grpFetchExternalCommand
            // 
            this.grpFetchExternalCommand.Controls.Add(this.txtPreDrainCommandArguments);
            this.grpFetchExternalCommand.Controls.Add(this.label33);
            this.grpFetchExternalCommand.Controls.Add(this.txtPreDrainCommand);
            this.grpFetchExternalCommand.Controls.Add(this.label17);
            this.grpFetchExternalCommand.Location = new System.Drawing.Point(6, 328);
            this.grpFetchExternalCommand.Name = "grpFetchExternalCommand";
            this.grpFetchExternalCommand.Size = new System.Drawing.Size(462, 48);
            this.grpFetchExternalCommand.TabIndex = 6040;
            this.grpFetchExternalCommand.TabStop = false;
            this.grpFetchExternalCommand.Text = "External Fetching via OS command";
            // 
            // txtPreDrainCommandArguments
            // 
            this.txtPreDrainCommandArguments.Location = new System.Drawing.Point(258, 17);
            this.txtPreDrainCommandArguments.Name = "txtPreDrainCommandArguments";
            this.txtPreDrainCommandArguments.Size = new System.Drawing.Size(198, 20);
            this.txtPreDrainCommandArguments.TabIndex = 6092;
            this.toolTip1.SetToolTip(this.txtPreDrainCommandArguments, "Arguments for external command");
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(230, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(28, 13);
            this.label33.TabIndex = 594;
            this.label33.Text = "Args";
            // 
            // txtPreDrainCommand
            // 
            this.txtPreDrainCommand.Location = new System.Drawing.Point(49, 17);
            this.txtPreDrainCommand.Name = "txtPreDrainCommand";
            this.txtPreDrainCommand.Size = new System.Drawing.Size(175, 20);
            this.txtPreDrainCommand.TabIndex = 6090;
            this.toolTip1.SetToolTip(this.txtPreDrainCommand, "Full path to OS command");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 591;
            this.label17.Text = "CMD";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.radioWorkFetchDisabled);
            this.groupBox12.Controls.Add(this.radioWorkFetchExternal);
            this.groupBox12.Controls.Add(this.radioWorkFetchGPU72);
            this.groupBox12.Controls.Add(this.radioWorkFetchGIMPS);
            this.groupBox12.Location = new System.Drawing.Point(6, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(462, 44);
            this.groupBox12.TabIndex = 6000;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Work Source";
            // 
            // radioWorkFetchDisabled
            // 
            this.radioWorkFetchDisabled.AutoSize = true;
            this.radioWorkFetchDisabled.Location = new System.Drawing.Point(40, 16);
            this.radioWorkFetchDisabled.Name = "radioWorkFetchDisabled";
            this.radioWorkFetchDisabled.Size = new System.Drawing.Size(78, 17);
            this.radioWorkFetchDisabled.TabIndex = 6002;
            this.radioWorkFetchDisabled.TabStop = true;
            this.radioWorkFetchDisabled.Text = "DISABLED";
            this.toolTip1.SetToolTip(this.radioWorkFetchDisabled, "No automated work fetching");
            this.radioWorkFetchDisabled.UseVisualStyleBackColor = true;
            this.radioWorkFetchDisabled.CheckedChanged += new System.EventHandler(this.radioWorkFetchDisabled_CheckedChanged);
            // 
            // radioWorkFetchExternal
            // 
            this.radioWorkFetchExternal.AutoSize = true;
            this.radioWorkFetchExternal.Location = new System.Drawing.Point(267, 16);
            this.radioWorkFetchExternal.Name = "radioWorkFetchExternal";
            this.radioWorkFetchExternal.Size = new System.Drawing.Size(155, 17);
            this.radioWorkFetchExternal.TabIndex = 6006;
            this.radioWorkFetchExternal.TabStop = true;
            this.radioWorkFetchExternal.Text = "Execute External Command";
            this.toolTip1.SetToolTip(this.radioWorkFetchExternal, "Execute a custom OS command instead of any embedded method");
            this.radioWorkFetchExternal.UseVisualStyleBackColor = true;
            this.radioWorkFetchExternal.CheckedChanged += new System.EventHandler(this.radioWorkFetchExternal_CheckedChanged);
            // 
            // radioWorkFetchGPU72
            // 
            this.radioWorkFetchGPU72.AutoSize = true;
            this.radioWorkFetchGPU72.Location = new System.Drawing.Point(197, 16);
            this.radioWorkFetchGPU72.Name = "radioWorkFetchGPU72";
            this.radioWorkFetchGPU72.Size = new System.Drawing.Size(60, 17);
            this.radioWorkFetchGPU72.TabIndex = 6005;
            this.radioWorkFetchGPU72.TabStop = true;
            this.radioWorkFetchGPU72.Text = "GPU72";
            this.toolTip1.SetToolTip(this.radioWorkFetchGPU72, "GP72 automated work fetching");
            this.radioWorkFetchGPU72.UseVisualStyleBackColor = true;
            this.radioWorkFetchGPU72.CheckedChanged += new System.EventHandler(this.radioWorkFetchGPU72_CheckedChanged);
            // 
            // radioWorkFetchGIMPS
            // 
            this.radioWorkFetchGIMPS.AutoSize = true;
            this.radioWorkFetchGIMPS.Location = new System.Drawing.Point(128, 16);
            this.radioWorkFetchGIMPS.Name = "radioWorkFetchGIMPS";
            this.radioWorkFetchGIMPS.Size = new System.Drawing.Size(59, 17);
            this.radioWorkFetchGIMPS.TabIndex = 6003;
            this.radioWorkFetchGIMPS.TabStop = true;
            this.radioWorkFetchGIMPS.Text = "GIMPS";
            this.toolTip1.SetToolTip(this.radioWorkFetchGIMPS, "GIMPS automated work fetching");
            this.radioWorkFetchGIMPS.UseVisualStyleBackColor = true;
            this.radioWorkFetchGIMPS.CheckedChanged += new System.EventHandler(this.radioWorkFetchGIMPS_CheckedChanged);
            // 
            // grpFetchNative
            // 
            this.grpFetchNative.Controls.Add(this.lblPledgePart2);
            this.grpFetchNative.Controls.Add(this.grpFetchGPU72);
            this.grpFetchNative.Controls.Add(this.lblPledge);
            this.grpFetchNative.Controls.Add(this.chkGIMPSReplaceGUIDs);
            this.grpFetchNative.Controls.Add(this.nudWorkBitLevel);
            this.grpFetchNative.Controls.Add(this.nudGIMPSFetchCount);
            this.grpFetchNative.Controls.Add(this.label20);
            this.grpFetchNative.Location = new System.Drawing.Point(6, 139);
            this.grpFetchNative.Name = "grpFetchNative";
            this.grpFetchNative.Size = new System.Drawing.Size(462, 183);
            this.grpFetchNative.TabIndex = 6020;
            this.grpFetchNative.TabStop = false;
            this.grpFetchNative.Text = "Native Fetching Parameters";
            // 
            // lblPledgePart2
            // 
            this.lblPledgePart2.AutoSize = true;
            this.lblPledgePart2.Location = new System.Drawing.Point(224, 50);
            this.lblPledgePart2.Name = "lblPledgePart2";
            this.lblPledgePart2.Size = new System.Drawing.Size(10, 13);
            this.lblPledgePart2.TabIndex = 596;
            this.lblPledgePart2.Text = ".";
            // 
            // grpFetchGPU72
            // 
            this.grpFetchGPU72.Controls.Add(this.nudGPU72GzDzDaysToFetch);
            this.grpFetchGPU72.Controls.Add(this.label40);
            this.grpFetchGPU72.Controls.Add(this.label38);
            this.grpFetchGPU72.Controls.Add(this.cmbGpu72TestType);
            this.grpFetchGPU72.Controls.Add(this.chkGPU72FallBack);
            this.grpFetchGPU72.Controls.Add(this.txtGPU72High);
            this.grpFetchGPU72.Controls.Add(this.txtGPU72Low);
            this.grpFetchGPU72.Controls.Add(this.cmbFetchGPU72PreferredWork);
            this.grpFetchGPU72.Controls.Add(this.label37);
            this.grpFetchGPU72.Controls.Add(this.label32);
            this.grpFetchGPU72.Controls.Add(this.label36);
            this.grpFetchGPU72.Location = new System.Drawing.Point(6, 72);
            this.grpFetchGPU72.Name = "grpFetchGPU72";
            this.grpFetchGPU72.Size = new System.Drawing.Size(450, 102);
            this.grpFetchGPU72.TabIndex = 6030;
            this.grpFetchGPU72.TabStop = false;
            this.grpFetchGPU72.Text = "GPU72 specific options";
            // 
            // nudGPU72GzDzDaysToFetch
            // 
            this.nudGPU72GzDzDaysToFetch.BackColor = System.Drawing.SystemColors.Window;
            this.nudGPU72GzDzDaysToFetch.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudGPU72GzDzDaysToFetch.Location = new System.Drawing.Point(385, 18);
            this.nudGPU72GzDzDaysToFetch.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudGPU72GzDzDaysToFetch.Name = "nudGPU72GzDzDaysToFetch";
            this.nudGPU72GzDzDaysToFetch.Size = new System.Drawing.Size(53, 20);
            this.nudGPU72GzDzDaysToFetch.TabIndex = 6055;
            this.toolTip1.SetToolTip(this.nudGPU72GzDzDaysToFetch, "Fetch a calculated amount of work instead of a fixed number of assignments");
            this.nudGPU72GzDzDaysToFetch.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudGPU72GzDzDaysToFetch.ValueChanged += new System.EventHandler(this.nudGPU72GzDzDaysToFetch_ValueChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(216, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(148, 13);
            this.label40.TabIndex = 6041;
            this.label40.Text = "GHzDs to fetch (0=use count)";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 22);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(31, 13);
            this.label38.TabIndex = 6040;
            this.label38.Text = "Type";
            // 
            // cmbGpu72TestType
            // 
            this.cmbGpu72TestType.FormattingEnabled = true;
            this.cmbGpu72TestType.Items.AddRange(new object[] {
            "First-Time tests",
            "Double-Check tests"});
            this.cmbGpu72TestType.Location = new System.Drawing.Point(71, 18);
            this.cmbGpu72TestType.Name = "cmbGpu72TestType";
            this.cmbGpu72TestType.Size = new System.Drawing.Size(141, 21);
            this.cmbGpu72TestType.TabIndex = 6050;
            this.toolTip1.SetToolTip(this.cmbGpu72TestType, "Type of work");
            this.cmbGpu72TestType.SelectedIndexChanged += new System.EventHandler(this.cmbGpu72TestType_SelectedIndexChanged);
            // 
            // chkGPU72FallBack
            // 
            this.chkGPU72FallBack.AutoSize = true;
            this.chkGPU72FallBack.Checked = true;
            this.chkGPU72FallBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGPU72FallBack.Location = new System.Drawing.Point(9, 79);
            this.chkGPU72FallBack.Name = "chkGPU72FallBack";
            this.chkGPU72FallBack.Size = new System.Drawing.Size(395, 17);
            this.chkGPU72FallBack.TabIndex = 6070;
            this.chkGPU72FallBack.Text = "Fallback to \'What Makes Sense\' (0,100000000) if no assignments are returned";
            this.toolTip1.SetToolTip(this.chkGPU72FallBack, "Safety net if above selections fail to get work");
            this.chkGPU72FallBack.UseVisualStyleBackColor = true;
            // 
            // txtGPU72High
            // 
            this.txtGPU72High.Location = new System.Drawing.Point(358, 46);
            this.txtGPU72High.MaxLength = 9;
            this.txtGPU72High.Name = "txtGPU72High";
            this.txtGPU72High.Size = new System.Drawing.Size(80, 20);
            this.txtGPU72High.TabIndex = 6069;
            this.txtGPU72High.Text = "100000000";
            this.toolTip1.SetToolTip(this.txtGPU72High, "Exponent Range (high)");
            // 
            // txtGPU72Low
            // 
            this.txtGPU72Low.Location = new System.Drawing.Point(246, 46);
            this.txtGPU72Low.MaxLength = 9;
            this.txtGPU72Low.Name = "txtGPU72Low";
            this.txtGPU72Low.Size = new System.Drawing.Size(80, 20);
            this.txtGPU72Low.TabIndex = 6065;
            this.txtGPU72Low.Text = "0";
            this.toolTip1.SetToolTip(this.txtGPU72Low, "Exponent Range (low)");
            // 
            // cmbFetchGPU72PreferredWork
            // 
            this.cmbFetchGPU72PreferredWork.FormattingEnabled = true;
            this.cmbFetchGPU72PreferredWork.Location = new System.Drawing.Point(71, 46);
            this.cmbFetchGPU72PreferredWork.Name = "cmbFetchGPU72PreferredWork";
            this.cmbFetchGPU72PreferredWork.Size = new System.Drawing.Size(141, 21);
            this.cmbFetchGPU72PreferredWork.TabIndex = 6060;
            this.toolTip1.SetToolTip(this.cmbFetchGPU72PreferredWork, "Tell GPU72 what you want");
            this.cmbFetchGPU72PreferredWork.SelectedValueChanged += new System.EventHandler(this.cmbFetchGPU72PreferredWork_SelectedValueChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(327, 50);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 592;
            this.label37.Text = "High";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 50);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 13);
            this.label32.TabIndex = 590;
            this.label32.Text = "Preference";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(216, 50);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(27, 13);
            this.label36.TabIndex = 591;
            this.label36.Text = "Low";
            // 
            // lblPledge
            // 
            this.lblPledge.AutoSize = true;
            this.lblPledge.Location = new System.Drawing.Point(6, 50);
            this.lblPledge.Name = "lblPledge";
            this.lblPledge.Size = new System.Drawing.Size(40, 13);
            this.lblPledge.TabIndex = 588;
            this.lblPledge.Text = "Pledge";
            // 
            // chkGIMPSReplaceGUIDs
            // 
            this.chkGIMPSReplaceGUIDs.AutoSize = true;
            this.chkGIMPSReplaceGUIDs.Checked = true;
            this.chkGIMPSReplaceGUIDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGIMPSReplaceGUIDs.Location = new System.Drawing.Point(227, 22);
            this.chkGIMPSReplaceGUIDs.Name = "chkGIMPSReplaceGUIDs";
            this.chkGIMPSReplaceGUIDs.Size = new System.Drawing.Size(217, 17);
            this.chkGIMPSReplaceGUIDs.TabIndex = 6026;
            this.chkGIMPSReplaceGUIDs.Text = "Replace placeholder with YYYY-MM-DD";
            this.toolTip1.SetToolTip(this.chkGIMPSReplaceGUIDs, "Datestamp inside the assignment determines when it was fetched");
            this.chkGIMPSReplaceGUIDs.UseVisualStyleBackColor = true;
            // 
            // nudWorkBitLevel
            // 
            this.nudWorkBitLevel.Location = new System.Drawing.Point(169, 46);
            this.nudWorkBitLevel.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudWorkBitLevel.Name = "nudWorkBitLevel";
            this.nudWorkBitLevel.Size = new System.Drawing.Size(47, 20);
            this.nudWorkBitLevel.TabIndex = 6028;
            this.toolTip1.SetToolTip(this.nudWorkBitLevel, "Maximum bit level to request");
            this.nudWorkBitLevel.Value = new decimal(new int[] {
            73,
            0,
            0,
            0});
            // 
            // nudGIMPSFetchCount
            // 
            this.nudGIMPSFetchCount.BackColor = System.Drawing.SystemColors.Window;
            this.nudGIMPSFetchCount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudGIMPSFetchCount.Location = new System.Drawing.Point(169, 21);
            this.nudGIMPSFetchCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGIMPSFetchCount.Name = "nudGIMPSFetchCount";
            this.nudGIMPSFetchCount.Size = new System.Drawing.Size(47, 20);
            this.nudGIMPSFetchCount.TabIndex = 6022;
            this.toolTip1.SetToolTip(this.nudGIMPSFetchCount, "Really?");
            this.nudGIMPSFetchCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(135, 13);
            this.label20.TabIndex = 586;
            this.label20.Text = "Count assignments to fetch";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(474, 387);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "Work Mgmt";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 367);
            this.panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkShowWorkingFactorInPhases);
            this.groupBox5.Controls.Add(this.nudMaxGzDzToAssignDuringDrain);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.nudNotifyWhenGHZdaysDropsBelow);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.nudDrainMISFITWorkWhenBelow);
            this.groupBox5.Controls.Add(this.nudBalanceWorkDifference);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(462, 159);
            this.groupBox5.TabIndex = 583;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Assigning Staged Work (Performed as part of Stats Updating)";
            // 
            // chkShowWorkingFactorInPhases
            // 
            this.chkShowWorkingFactorInPhases.AutoSize = true;
            this.chkShowWorkingFactorInPhases.Location = new System.Drawing.Point(11, 127);
            this.chkShowWorkingFactorInPhases.Name = "chkShowWorkingFactorInPhases";
            this.chkShowWorkingFactorInPhases.Size = new System.Drawing.Size(386, 17);
            this.chkShowWorkingFactorInPhases.TabIndex = 860;
            this.chkShowWorkingFactorInPhases.Text = "Show \"working\" exponent in phases (current_range|max_bit_level exponent)";
            this.toolTip1.SetToolTip(this.chkShowWorkingFactorInPhases, "(see MFAKTx documentation on the \'Stages\' variable");
            this.chkShowWorkingFactorInPhases.UseVisualStyleBackColor = true;
            // 
            // nudMaxGzDzToAssignDuringDrain
            // 
            this.nudMaxGzDzToAssignDuringDrain.BackColor = System.Drawing.SystemColors.Window;
            this.nudMaxGzDzToAssignDuringDrain.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxGzDzToAssignDuringDrain.Location = new System.Drawing.Point(346, 45);
            this.nudMaxGzDzToAssignDuringDrain.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudMaxGzDzToAssignDuringDrain.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxGzDzToAssignDuringDrain.Name = "nudMaxGzDzToAssignDuringDrain";
            this.nudMaxGzDzToAssignDuringDrain.ReadOnly = true;
            this.nudMaxGzDzToAssignDuringDrain.Size = new System.Drawing.Size(55, 20);
            this.nudMaxGzDzToAssignDuringDrain.TabIndex = 808;
            this.toolTip1.SetToolTip(this.nudMaxGzDzToAssignDuringDrain, "How much work to assign out during a drain event");
            this.nudMaxGzDzToAssignDuringDrain.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(189, 13);
            this.label21.TabIndex = 586;
            this.label21.Text = "Total GHzDs to assign-out during drain";
            // 
            // nudNotifyWhenGHZdaysDropsBelow
            // 
            this.nudNotifyWhenGHZdaysDropsBelow.BackColor = System.Drawing.SystemColors.Window;
            this.nudNotifyWhenGHZdaysDropsBelow.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudNotifyWhenGHZdaysDropsBelow.Location = new System.Drawing.Point(346, 99);
            this.nudNotifyWhenGHZdaysDropsBelow.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNotifyWhenGHZdaysDropsBelow.Name = "nudNotifyWhenGHZdaysDropsBelow";
            this.nudNotifyWhenGHZdaysDropsBelow.Size = new System.Drawing.Size(55, 20);
            this.nudNotifyWhenGHZdaysDropsBelow.TabIndex = 850;
            this.toolTip1.SetToolTip(this.nudNotifyWhenGHZdaysDropsBelow, "Failsafe system informing you something is seriously wrong with your work load");
            this.nudNotifyWhenGHZdaysDropsBelow.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 23);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(329, 13);
            this.label31.TabIndex = 578;
            this.label31.Text = "Drain MISFITworkToDo when total GHzDsToDo drops below (0=off)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(321, 13);
            this.label18.TabIndex = 573;
            this.label18.Text = "Balance work between instances when row difference is >= (0=off)";
            // 
            // nudDrainMISFITWorkWhenBelow
            // 
            this.nudDrainMISFITWorkWhenBelow.BackColor = System.Drawing.SystemColors.Window;
            this.nudDrainMISFITWorkWhenBelow.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudDrainMISFITWorkWhenBelow.Location = new System.Drawing.Point(346, 19);
            this.nudDrainMISFITWorkWhenBelow.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDrainMISFITWorkWhenBelow.Name = "nudDrainMISFITWorkWhenBelow";
            this.nudDrainMISFITWorkWhenBelow.Size = new System.Drawing.Size(55, 20);
            this.nudDrainMISFITWorkWhenBelow.TabIndex = 800;
            this.toolTip1.SetToolTip(this.nudDrainMISFITWorkWhenBelow, "Threshold to move work from staging file to live WorkToDo.txt files");
            this.nudDrainMISFITWorkWhenBelow.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // nudBalanceWorkDifference
            // 
            this.nudBalanceWorkDifference.BackColor = System.Drawing.SystemColors.Window;
            this.nudBalanceWorkDifference.Location = new System.Drawing.Point(346, 71);
            this.nudBalanceWorkDifference.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudBalanceWorkDifference.Name = "nudBalanceWorkDifference";
            this.nudBalanceWorkDifference.Size = new System.Drawing.Size(55, 20);
            this.nudBalanceWorkDifference.TabIndex = 820;
            this.toolTip1.SetToolTip(this.nudBalanceWorkDifference, "Threshold at which point unbalanced instances are re-balanced");
            this.nudBalanceWorkDifference.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 101);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(216, 13);
            this.label30.TabIndex = 575;
            this.label30.Text = "Alert if total GHzDsToDo drops below (0=off)";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.txtCryptoInfo);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(474, 387);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Security";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtGPU72UserID);
            this.groupBox11.Controls.Add(this.label34);
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Controls.Add(this.txtGPU72Password);
            this.groupBox11.Location = new System.Drawing.Point(3, 85);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(203, 74);
            this.groupBox11.TabIndex = 33;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "GPU72 Credentials";
            // 
            // txtGPU72UserID
            // 
            this.txtGPU72UserID.Location = new System.Drawing.Point(73, 14);
            this.txtGPU72UserID.Name = "txtGPU72UserID";
            this.txtGPU72UserID.Size = new System.Drawing.Size(119, 20);
            this.txtGPU72UserID.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtGPU72UserID, "Really?");
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(11, 43);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "Password";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 17);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(43, 13);
            this.label35.TabIndex = 0;
            this.label35.Text = "User ID";
            // 
            // txtGPU72Password
            // 
            this.txtGPU72Password.Location = new System.Drawing.Point(73, 40);
            this.txtGPU72Password.Name = "txtGPU72Password";
            this.txtGPU72Password.PasswordChar = '*';
            this.txtGPU72Password.Size = new System.Drawing.Size(119, 20);
            this.txtGPU72Password.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtGPU72Password, "Really?");
            // 
            // txtCryptoInfo
            // 
            this.txtCryptoInfo.Location = new System.Drawing.Point(3, 301);
            this.txtCryptoInfo.Multiline = true;
            this.txtCryptoInfo.Name = "txtCryptoInfo";
            this.txtCryptoInfo.ReadOnly = true;
            this.txtCryptoInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCryptoInfo.Size = new System.Drawing.Size(471, 65);
            this.txtCryptoInfo.TabIndex = 32;
            this.txtCryptoInfo.Text = "z";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.grpSMTPCredentials);
            this.groupBox7.Controls.Add(this.chkSMTPAuthRequired);
            this.groupBox7.Controls.Add(this.txtSMTPfrom);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.txtSMTPRecipients);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.btnSendSMTPTest);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.txtSMTPport);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.txtSMTPServer);
            this.groupBox7.Location = new System.Drawing.Point(212, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(259, 292);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SMTP Email";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(70, 63);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 13);
            this.label27.TabIndex = 251;
            this.label27.Text = "comma separated list";
            // 
            // grpSMTPCredentials
            // 
            this.grpSMTPCredentials.Controls.Add(this.txtSMTPaccountID);
            this.grpSMTPCredentials.Controls.Add(this.txtSMTPpassword);
            this.grpSMTPCredentials.Controls.Add(this.label16);
            this.grpSMTPCredentials.Controls.Add(this.label1);
            this.grpSMTPCredentials.Controls.Add(this.chkSMTPUseTLS);
            this.grpSMTPCredentials.Enabled = false;
            this.grpSMTPCredentials.Location = new System.Drawing.Point(14, 154);
            this.grpSMTPCredentials.Name = "grpSMTPCredentials";
            this.grpSMTPCredentials.Size = new System.Drawing.Size(239, 96);
            this.grpSMTPCredentials.TabIndex = 2052;
            this.grpSMTPCredentials.TabStop = false;
            this.grpSMTPCredentials.Text = "SMTP credentials";
            // 
            // txtSMTPaccountID
            // 
            this.txtSMTPaccountID.Location = new System.Drawing.Point(66, 20);
            this.txtSMTPaccountID.Name = "txtSMTPaccountID";
            this.txtSMTPaccountID.Size = new System.Drawing.Size(167, 20);
            this.txtSMTPaccountID.TabIndex = 2055;
            this.toolTip1.SetToolTip(this.txtSMTPaccountID, "Really?");
            // 
            // txtSMTPpassword
            // 
            this.txtSMTPpassword.Location = new System.Drawing.Point(66, 46);
            this.txtSMTPpassword.Name = "txtSMTPpassword";
            this.txtSMTPpassword.PasswordChar = '*';
            this.txtSMTPpassword.Size = new System.Drawing.Size(167, 20);
            this.txtSMTPpassword.TabIndex = 2060;
            this.toolTip1.SetToolTip(this.txtSMTPpassword, "Really?");
            this.txtSMTPpassword.Enter += new System.EventHandler(this.txtSMTPpassword_Enter);
            this.txtSMTPpassword.Leave += new System.EventHandler(this.txtSMTPpassword_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "AccountID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password";
            // 
            // chkSMTPUseTLS
            // 
            this.chkSMTPUseTLS.AutoSize = true;
            this.chkSMTPUseTLS.Location = new System.Drawing.Point(7, 72);
            this.chkSMTPUseTLS.Name = "chkSMTPUseTLS";
            this.chkSMTPUseTLS.Size = new System.Drawing.Size(68, 17);
            this.chkSMTPUseTLS.TabIndex = 2070;
            this.chkSMTPUseTLS.Text = "Use TLS";
            this.toolTip1.SetToolTip(this.chkSMTPUseTLS, "Transport Layer Security. Determined by your SMTP server");
            this.chkSMTPUseTLS.UseVisualStyleBackColor = true;
            // 
            // chkSMTPAuthRequired
            // 
            this.chkSMTPAuthRequired.AutoSize = true;
            this.chkSMTPAuthRequired.Location = new System.Drawing.Point(14, 131);
            this.chkSMTPAuthRequired.Name = "chkSMTPAuthRequired";
            this.chkSMTPAuthRequired.Size = new System.Drawing.Size(140, 17);
            this.chkSMTPAuthRequired.TabIndex = 2050;
            this.chkSMTPAuthRequired.Text = "Authentication Required";
            this.toolTip1.SetToolTip(this.chkSMTPAuthRequired, "SMTP server requires authentication to send messages");
            this.chkSMTPAuthRequired.UseVisualStyleBackColor = true;
            this.chkSMTPAuthRequired.CheckedChanged += new System.EventHandler(this.chkSMTPAuthRequired_CheckedChanged);
            // 
            // txtSMTPfrom
            // 
            this.txtSMTPfrom.Location = new System.Drawing.Point(73, 14);
            this.txtSMTPfrom.Name = "txtSMTPfrom";
            this.txtSMTPfrom.Size = new System.Drawing.Size(180, 20);
            this.txtSMTPfrom.TabIndex = 2000;
            this.toolTip1.SetToolTip(this.txtSMTPfrom, "Email address emails originate from");
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 248;
            this.label26.Text = "From";
            // 
            // txtSMTPRecipients
            // 
            this.txtSMTPRecipients.Location = new System.Drawing.Point(73, 40);
            this.txtSMTPRecipients.Name = "txtSMTPRecipients";
            this.txtSMTPRecipients.Size = new System.Drawing.Size(180, 20);
            this.txtSMTPRecipients.TabIndex = 2010;
            this.toolTip1.SetToolTip(this.txtSMTPRecipients, "Email address of recipients");
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 246;
            this.label25.Text = "Recipients ";
            // 
            // btnSendSMTPTest
            // 
            this.btnSendSMTPTest.Location = new System.Drawing.Point(44, 256);
            this.btnSendSMTPTest.Name = "btnSendSMTPTest";
            this.btnSendSMTPTest.Size = new System.Drawing.Size(180, 29);
            this.btnSendSMTPTest.TabIndex = 2090;
            this.btnSendSMTPTest.Text = "Send Test Message";
            this.toolTip1.SetToolTip(this.btnSendSMTPTest, "Really?");
            this.btnSendSMTPTest.UseVisualStyleBackColor = true;
            this.btnSendSMTPTest.Click += new System.EventHandler(this.btnSendSMTPTest_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 108);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 13);
            this.label24.TabIndex = 243;
            this.label24.Text = "Port";
            // 
            // txtSMTPport
            // 
            this.txtSMTPport.Location = new System.Drawing.Point(73, 105);
            this.txtSMTPport.Name = "txtSMTPport";
            this.txtSMTPport.Size = new System.Drawing.Size(180, 20);
            this.txtSMTPport.TabIndex = 2030;
            this.toolTip1.SetToolTip(this.txtSMTPport, "Port SMTP server is listening on");
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(38, 13);
            this.label23.TabIndex = 241;
            this.label23.Text = "Server";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Location = new System.Drawing.Point(73, 79);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(180, 20);
            this.txtSMTPServer.TabIndex = 2020;
            this.toolTip1.SetToolTip(this.txtSMTPServer, "SMTP server name or IP");
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtGimpsUserID);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.txtGIMPSPassword);
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(203, 74);
            this.groupBox8.TabIndex = 30;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "GIMPS Credentials";
            this.groupBox8.TextChanged += new System.EventHandler(this.a);
            // 
            // txtGimpsUserID
            // 
            this.txtGimpsUserID.Location = new System.Drawing.Point(73, 14);
            this.txtGimpsUserID.Name = "txtGimpsUserID";
            this.txtGimpsUserID.Size = new System.Drawing.Size(119, 20);
            this.txtGimpsUserID.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtGimpsUserID, "Really?");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "User ID";
            // 
            // txtGIMPSPassword
            // 
            this.txtGIMPSPassword.Location = new System.Drawing.Point(73, 40);
            this.txtGIMPSPassword.Name = "txtGIMPSPassword";
            this.txtGIMPSPassword.PasswordChar = '*';
            this.txtGIMPSPassword.Size = new System.Drawing.Size(119, 20);
            this.txtGIMPSPassword.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtGIMPSPassword, "Really?");
            this.txtGIMPSPassword.TextChanged += new System.EventHandler(this.txtGimpsPassword_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(474, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Misc";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage7.Controls.Add(this.panel7);
            this.tabPage7.Controls.Add(this.txtEmailSubjectGIOMPanelOpen);
            this.tabPage7.Controls.Add(this.label45);
            this.tabPage7.Controls.Add(this.chkEmailWhenGIOMPanelRemainsOpen);
            this.tabPage7.Controls.Add(this.panel6);
            this.tabPage7.Controls.Add(this.txtEmailSubjectAlertPanelOpen);
            this.tabPage7.Controls.Add(this.label44);
            this.tabPage7.Controls.Add(this.chkEmailWhenAlertPanelRemainsOpen);
            this.tabPage7.Controls.Add(this.panel5);
            this.tabPage7.Controls.Add(this.txtEmailSubjectStats);
            this.tabPage7.Controls.Add(this.label43);
            this.tabPage7.Controls.Add(this.chkEmailStatsBeforeWorkFetch);
            this.tabPage7.Controls.Add(this.panel4);
            this.tabPage7.Controls.Add(this.txtEmailSubjectLowGHZDsToDo);
            this.tabPage7.Controls.Add(this.label42);
            this.tabPage7.Controls.Add(this.panel3);
            this.tabPage7.Controls.Add(this.txtEmailSubjectExtenralFetchResults);
            this.tabPage7.Controls.Add(this.label41);
            this.tabPage7.Controls.Add(this.chkEmailOnLowWork);
            this.tabPage7.Controls.Add(this.chkEmailPreAssignRunResult);
            this.tabPage7.Controls.Add(this.panel2);
            this.tabPage7.Controls.Add(this.txtEmailSubjectStalledProcess);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.chkEmailOnStalledProcessDetection);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(474, 387);
            this.tabPage7.TabIndex = 8;
            this.tabPage7.Text = "Emails";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(3, 325);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(462, 1);
            this.panel7.TabIndex = 6114;
            // 
            // txtEmailSubjectGIOMPanelOpen
            // 
            this.txtEmailSubjectGIOMPanelOpen.Location = new System.Drawing.Point(75, 305);
            this.txtEmailSubjectGIOMPanelOpen.Name = "txtEmailSubjectGIOMPanelOpen";
            this.txtEmailSubjectGIOMPanelOpen.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectGIOMPanelOpen.TabIndex = 6213;
            this.toolTip1.SetToolTip(this.txtEmailSubjectGIOMPanelOpen, "Customize the email subject line");
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 309);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 13);
            this.label45.TabIndex = 6112;
            this.label45.Text = "Subject Line:";
            // 
            // chkEmailWhenGIOMPanelRemainsOpen
            // 
            this.chkEmailWhenGIOMPanelRemainsOpen.AutoSize = true;
            this.chkEmailWhenGIOMPanelRemainsOpen.Location = new System.Drawing.Point(6, 289);
            this.chkEmailWhenGIOMPanelRemainsOpen.Name = "chkEmailWhenGIOMPanelRemainsOpen";
            this.chkEmailWhenGIOMPanelRemainsOpen.Size = new System.Drawing.Size(285, 17);
            this.chkEmailWhenGIOMPanelRemainsOpen.TabIndex = 6211;
            this.chkEmailWhenGIOMPanelRemainsOpen.Text = "Email when GIOM Panel remains open for > 65 minutes";
            this.toolTip1.SetToolTip(this.chkEmailWhenGIOMPanelRemainsOpen, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailWhenGIOMPanelRemainsOpen.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(3, 273);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(462, 1);
            this.panel6.TabIndex = 6110;
            // 
            // txtEmailSubjectAlertPanelOpen
            // 
            this.txtEmailSubjectAlertPanelOpen.Location = new System.Drawing.Point(75, 253);
            this.txtEmailSubjectAlertPanelOpen.Name = "txtEmailSubjectAlertPanelOpen";
            this.txtEmailSubjectAlertPanelOpen.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectAlertPanelOpen.TabIndex = 6209;
            this.toolTip1.SetToolTip(this.txtEmailSubjectAlertPanelOpen, "Customize the email subject line");
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 257);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(69, 13);
            this.label44.TabIndex = 6108;
            this.label44.Text = "Subject Line:";
            // 
            // chkEmailWhenAlertPanelRemainsOpen
            // 
            this.chkEmailWhenAlertPanelRemainsOpen.AutoSize = true;
            this.chkEmailWhenAlertPanelRemainsOpen.Location = new System.Drawing.Point(6, 237);
            this.chkEmailWhenAlertPanelRemainsOpen.Name = "chkEmailWhenAlertPanelRemainsOpen";
            this.chkEmailWhenAlertPanelRemainsOpen.Size = new System.Drawing.Size(278, 17);
            this.chkEmailWhenAlertPanelRemainsOpen.TabIndex = 6207;
            this.chkEmailWhenAlertPanelRemainsOpen.Text = "Email when Alert Panel remains open for > 60 minutes";
            this.toolTip1.SetToolTip(this.chkEmailWhenAlertPanelRemainsOpen, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailWhenAlertPanelRemainsOpen.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(3, 219);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(462, 1);
            this.panel5.TabIndex = 6106;
            // 
            // txtEmailSubjectStats
            // 
            this.txtEmailSubjectStats.Location = new System.Drawing.Point(75, 199);
            this.txtEmailSubjectStats.Name = "txtEmailSubjectStats";
            this.txtEmailSubjectStats.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectStats.TabIndex = 6205;
            this.toolTip1.SetToolTip(this.txtEmailSubjectStats, "Customize the email subject line");
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 203);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(69, 13);
            this.label43.TabIndex = 6104;
            this.label43.Text = "Subject Line:";
            // 
            // chkEmailStatsBeforeWorkFetch
            // 
            this.chkEmailStatsBeforeWorkFetch.AutoSize = true;
            this.chkEmailStatsBeforeWorkFetch.Location = new System.Drawing.Point(6, 183);
            this.chkEmailStatsBeforeWorkFetch.Name = "chkEmailStatsBeforeWorkFetch";
            this.chkEmailStatsBeforeWorkFetch.Size = new System.Drawing.Size(243, 17);
            this.chkEmailStatsBeforeWorkFetch.TabIndex = 6203;
            this.chkEmailStatsBeforeWorkFetch.Text = "Email work statistics before fetching new work";
            this.toolTip1.SetToolTip(this.chkEmailStatsBeforeWorkFetch, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailStatsBeforeWorkFetch.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(3, 162);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 1);
            this.panel4.TabIndex = 6102;
            // 
            // txtEmailSubjectLowGHZDsToDo
            // 
            this.txtEmailSubjectLowGHZDsToDo.Location = new System.Drawing.Point(75, 142);
            this.txtEmailSubjectLowGHZDsToDo.Name = "txtEmailSubjectLowGHZDsToDo";
            this.txtEmailSubjectLowGHZDsToDo.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectLowGHZDsToDo.TabIndex = 6110;
            this.toolTip1.SetToolTip(this.txtEmailSubjectLowGHZDsToDo, "Customize the email subject line");
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 146);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 13);
            this.label42.TabIndex = 6100;
            this.label42.Text = "Subject Line:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(3, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 1);
            this.panel3.TabIndex = 6099;
            // 
            // txtEmailSubjectExtenralFetchResults
            // 
            this.txtEmailSubjectExtenralFetchResults.Location = new System.Drawing.Point(75, 87);
            this.txtEmailSubjectExtenralFetchResults.Name = "txtEmailSubjectExtenralFetchResults";
            this.txtEmailSubjectExtenralFetchResults.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectExtenralFetchResults.TabIndex = 6098;
            this.toolTip1.SetToolTip(this.txtEmailSubjectExtenralFetchResults, "Customize the email subject line");
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 91);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 6097;
            this.label41.Text = "Subject Line:";
            // 
            // chkEmailOnLowWork
            // 
            this.chkEmailOnLowWork.AutoSize = true;
            this.chkEmailOnLowWork.Location = new System.Drawing.Point(6, 126);
            this.chkEmailOnLowWork.Name = "chkEmailOnLowWork";
            this.chkEmailOnLowWork.Size = new System.Drawing.Size(250, 17);
            this.chkEmailOnLowWork.TabIndex = 6100;
            this.chkEmailOnLowWork.Text = "Email when GHzDsToDo drops below threshold";
            this.toolTip1.SetToolTip(this.chkEmailOnLowWork, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailOnLowWork.UseVisualStyleBackColor = true;
            // 
            // chkEmailPreAssignRunResult
            // 
            this.chkEmailPreAssignRunResult.AutoSize = true;
            this.chkEmailPreAssignRunResult.Location = new System.Drawing.Point(6, 71);
            this.chkEmailPreAssignRunResult.Name = "chkEmailPreAssignRunResult";
            this.chkEmailPreAssignRunResult.Size = new System.Drawing.Size(217, 17);
            this.chkEmailPreAssignRunResult.TabIndex = 6095;
            this.chkEmailPreAssignRunResult.Text = "Email results of External Fetch Command";
            this.toolTip1.SetToolTip(this.chkEmailPreAssignRunResult, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailPreAssignRunResult.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 1);
            this.panel2.TabIndex = 112;
            // 
            // txtEmailSubjectStalledProcess
            // 
            this.txtEmailSubjectStalledProcess.Location = new System.Drawing.Point(75, 33);
            this.txtEmailSubjectStalledProcess.Name = "txtEmailSubjectStalledProcess";
            this.txtEmailSubjectStalledProcess.Size = new System.Drawing.Size(390, 20);
            this.txtEmailSubjectStalledProcess.TabIndex = 6020;
            this.toolTip1.SetToolTip(this.txtEmailSubjectStalledProcess, "Customize the email subject line");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Subject Line:";
            // 
            // chkEmailOnStalledProcessDetection
            // 
            this.chkEmailOnStalledProcessDetection.AutoSize = true;
            this.chkEmailOnStalledProcessDetection.Location = new System.Drawing.Point(6, 17);
            this.chkEmailOnStalledProcessDetection.Name = "chkEmailOnStalledProcessDetection";
            this.chkEmailOnStalledProcessDetection.Size = new System.Drawing.Size(217, 17);
            this.chkEmailOnStalledProcessDetection.TabIndex = 6000;
            this.chkEmailOnStalledProcessDetection.Text = "Email when a stalled process is detected";
            this.toolTip1.SetToolTip(this.chkEmailOnStalledProcessDetection, "Keep track of progress and key events. Good idea when on vacation!");
            this.chkEmailOnStalledProcessDetection.UseVisualStyleBackColor = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 454);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Editor";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProcessStartDelay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurgeLogsDaysOld)).EndInit();
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStalledResultsMaxMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateInterval)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.grpFetchTrigger.ResumeLayout(false);
            this.grpFetchTrigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMISFITworkToDoCheckInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkFetchGhDzThreshold)).EndInit();
            this.grpFetchExternalCommand.ResumeLayout(false);
            this.grpFetchExternalCommand.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.grpFetchNative.ResumeLayout(false);
            this.grpFetchNative.PerformLayout();
            this.grpFetchGPU72.ResumeLayout(false);
            this.grpFetchGPU72.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPU72GzDzDaysToFetch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkBitLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGIMPSFetchCount)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGzDzToAssignDuringDrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNotifyWhenGHZdaysDropsBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrainMISFITWorkWhenBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBalanceWorkDifference)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpSMTPCredentials.ResumeLayout(false);
            this.grpSMTPCredentials.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMFinstances;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRemoveLocation;
        private System.Windows.Forms.Button btnRemoveStartupProcess;
        private System.Windows.Forms.Button btnAddStartupProcesses;
        private System.Windows.Forms.ListBox lstStartUpProcesses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveStopProcessName;
        private System.Windows.Forms.Button btnAddStopProcessName;
        private System.Windows.Forms.TextBox txtStopProcessName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstStopProcessName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkShowConfDialogs;
        private System.Windows.Forms.TextBox txtLaunchURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPstopInfo;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.Button btnRemoveSched;
        private System.Windows.Forms.ListBox lstSchedules;
        private System.Windows.Forms.ComboBox cmbSchedType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddSched;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSchedulesEnabled;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudProcessStartDelay;
        private System.Windows.Forms.CheckBox chkSetWorkingDir;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtExportResultsURL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShowResultsInExternalViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtSMTPaccountID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSMTPpassword;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtGimpsUserID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGIMPSPassword;
        private System.Windows.Forms.TextBox txtSMTPRecipients;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSendSMTPTest;
        private System.Windows.Forms.CheckBox chkSMTPUseTLS;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtSMTPport;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.TextBox txtSMTPfrom;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox grpSMTPCredentials;
        private System.Windows.Forms.CheckBox chkSMTPAuthRequired;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCryptoInfo;
        private System.Windows.Forms.CheckBox chkMinimizeToSysTray;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudUpdateInterval;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudMaxGzDzToAssignDuringDrain;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown nudDrainMISFITWorkWhenBelow;
        private System.Windows.Forms.CheckBox chkShowWorkingFactorInPhases;
        private System.Windows.Forms.NumericUpDown nudNotifyWhenGHZdaysDropsBelow;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nudBalanceWorkDifference;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox grpFetchExternalCommand;
        private System.Windows.Forms.TextBox txtPreDrainCommandArguments;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtPreDrainCommand;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton radioWorkFetchExternal;
        private System.Windows.Forms.RadioButton radioWorkFetchGPU72;
        private System.Windows.Forms.RadioButton radioWorkFetchGIMPS;
        private System.Windows.Forms.GroupBox grpFetchNative;
        private System.Windows.Forms.Label lblPledge;
        private System.Windows.Forms.CheckBox chkGIMPSReplaceGUIDs;
        private System.Windows.Forms.NumericUpDown nudWorkBitLevel;
        private System.Windows.Forms.NumericUpDown nudGIMPSFetchCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblFetchThreshold;
        private System.Windows.Forms.NumericUpDown nudWorkFetchGhDzThreshold;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtGPU72UserID;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtGPU72Password;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmbFetchGPU72PreferredWork;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.RadioButton radioWorkFetchDisabled;
        private System.Windows.Forms.GroupBox grpFetchGPU72;
        private System.Windows.Forms.Label lblPledgePart2;
        private System.Windows.Forms.TextBox txtGPU72Low;
        private System.Windows.Forms.GroupBox grpFetchTrigger;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudMISFITworkToDoCheckInterval;
        private System.Windows.Forms.CheckBox chkGPU72FallBack;
        private System.Windows.Forms.TextBox txtGPU72High;
        private System.Windows.Forms.Button btnAutoConfigure;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cmbGpu72TestType;
        private System.Windows.Forms.NumericUpDown nudPurgeLogsDaysOld;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.CheckBox chkIncludeBitLevelOnDupDetection;
        private System.Windows.Forms.NumericUpDown nudGPU72GzDzDaysToFetch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkShowProductivityAsAverages;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEmailSubjectStalledProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEmailOnStalledProcessDetection;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtEmailSubjectLowGHZDsToDo;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtEmailSubjectExtenralFetchResults;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox chkEmailOnLowWork;
        private System.Windows.Forms.CheckBox chkEmailPreAssignRunResult;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtEmailSubjectStats;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckBox chkEmailStatsBeforeWorkFetch;
        private System.Windows.Forms.CheckBox chkStartWithStallDetectionSuspended;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtEmailSubjectAlertPanelOpen;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.CheckBox chkEmailWhenAlertPanelRemainsOpen;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtEmailSubjectGIOMPanelOpen;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox chkEmailWhenGIOMPanelRemainsOpen;
        private System.Windows.Forms.NumericUpDown nudStalledResultsMaxMinutes;
        private System.Windows.Forms.CheckBox chkHoldBackUnfinishedExponents;
        private System.Windows.Forms.ComboBox cmbHours;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox cmbMins;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkUseWorkToDoAdd;
    }
}