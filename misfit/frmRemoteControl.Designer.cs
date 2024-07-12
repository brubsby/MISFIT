namespace MISFIT
{
    partial class frmRemoteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoteControl));
            this.dgvRemote = new System.Windows.Forms.DataGridView();
            this.REMOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMAND = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LAST_RESPONSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExecuteRemoteAction = new System.Windows.Forms.Button();
            this.cmbGlobalCommand = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemote)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRemote
            // 
            this.dgvRemote.AllowUserToAddRows = false;
            this.dgvRemote.AllowUserToDeleteRows = false;
            this.dgvRemote.AllowUserToResizeColumns = false;
            this.dgvRemote.AllowUserToResizeRows = false;
            this.dgvRemote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRemote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.REMOTE,
            this.COMMAND,
            this.LAST_RESPONSE});
            this.dgvRemote.Location = new System.Drawing.Point(12, 1);
            this.dgvRemote.MultiSelect = false;
            this.dgvRemote.Name = "dgvRemote";
            this.dgvRemote.RowHeadersVisible = false;
            this.dgvRemote.Size = new System.Drawing.Size(430, 173);
            this.dgvRemote.TabIndex = 0;
            this.dgvRemote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemote_CellClick);
            // 
            // REMOTE
            // 
            this.REMOTE.FillWeight = 50F;
            this.REMOTE.HeaderText = "REMOTE";
            this.REMOTE.Name = "REMOTE";
            this.REMOTE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // COMMAND
            // 
            this.COMMAND.FillWeight = 50F;
            this.COMMAND.HeaderText = "COMMAND";
            this.COMMAND.Items.AddRange(new object[] {
            "",
            "INQUIRE",
            "START",
            "STOP",
            "KILL",
            "REBOOT-SAFE",
            "REBOOT-FORCE"});
            this.COMMAND.Name = "COMMAND";
            this.COMMAND.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LAST_RESPONSE
            // 
            this.LAST_RESPONSE.HeaderText = "LAST RESPONSE";
            this.LAST_RESPONSE.Name = "LAST_RESPONSE";
            this.LAST_RESPONSE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnExecuteRemoteAction
            // 
            this.btnExecuteRemoteAction.Location = new System.Drawing.Point(298, 192);
            this.btnExecuteRemoteAction.Name = "btnExecuteRemoteAction";
            this.btnExecuteRemoteAction.Size = new System.Drawing.Size(69, 31);
            this.btnExecuteRemoteAction.TabIndex = 1;
            this.btnExecuteRemoteAction.Text = "&Execute";
            this.btnExecuteRemoteAction.UseVisualStyleBackColor = true;
            this.btnExecuteRemoteAction.Click += new System.EventHandler(this.btnExecuteRemoteAction_Click);
            // 
            // cmbGlobalCommand
            // 
            this.cmbGlobalCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGlobalCommand.FormattingEnabled = true;
            this.cmbGlobalCommand.Items.AddRange(new object[] {
            "",
            "INQUIRE",
            "START",
            "STOP",
            "KILL",
            "REBOOT-SAFE",
            "REBOOT-FORCE"});
            this.cmbGlobalCommand.Location = new System.Drawing.Point(9, 17);
            this.cmbGlobalCommand.Name = "cmbGlobalCommand";
            this.cmbGlobalCommand.Size = new System.Drawing.Size(115, 21);
            this.cmbGlobalCommand.TabIndex = 2;
            this.cmbGlobalCommand.SelectedIndexChanged += new System.EventHandler(this.cmbGlobalCommand_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbGlobalCommand);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 46);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Global Command";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(373, 192);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 31);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // frmRemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 229);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExecuteRemoteAction);
            this.Controls.Add(this.dgvRemote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRemoteControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remote Control";
            this.Load += new System.EventHandler(this.frmRemoteControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemote)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRemote;
        private System.Windows.Forms.Button btnExecuteRemoteAction;
        private System.Windows.Forms.ComboBox cmbGlobalCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMOTE;
        private System.Windows.Forms.DataGridViewComboBoxColumn COMMAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_RESPONSE;
        private System.Windows.Forms.Button button1;
    }
}