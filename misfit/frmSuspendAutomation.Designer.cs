namespace MISFIT
{
    partial class frmSuspendAutomation
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
            this.DTP1 = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentlySuspendedTill = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddMins = new System.Windows.Forms.Button();
            this.btnAddHours = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResumeAutomation = new System.Windows.Forms.Button();
            this.btnSubtractHours = new System.Windows.Forms.Button();
            this.btnSubtractMinutes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTP1
            // 
            this.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP1.Location = new System.Drawing.Point(15, 64);
            this.DTP1.Name = "DTP1";
            this.DTP1.Size = new System.Drawing.Size(200, 20);
            this.DTP1.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 171);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 23);
            this.btnSave.TabIndex = 70;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Automation is currently suspended until";
            // 
            // txtCurrentlySuspendedTill
            // 
            this.txtCurrentlySuspendedTill.Location = new System.Drawing.Point(15, 25);
            this.txtCurrentlySuspendedTill.Name = "txtCurrentlySuspendedTill";
            this.txtCurrentlySuspendedTill.ReadOnly = true;
            this.txtCurrentlySuspendedTill.Size = new System.Drawing.Size(200, 20);
            this.txtCurrentlySuspendedTill.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Set date/time to resume automation";
            // 
            // btnAddMins
            // 
            this.btnAddMins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMins.Location = new System.Drawing.Point(118, 103);
            this.btnAddMins.Name = "btnAddMins";
            this.btnAddMins.Size = new System.Drawing.Size(97, 22);
            this.btnAddMins.TabIndex = 30;
            this.btnAddMins.Text = "+ 10 Min";
            this.btnAddMins.UseVisualStyleBackColor = true;
            this.btnAddMins.Click += new System.EventHandler(this.btnAddMins_Click);
            // 
            // btnAddHours
            // 
            this.btnAddHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHours.Location = new System.Drawing.Point(12, 103);
            this.btnAddHours.Name = "btnAddHours";
            this.btnAddHours.Size = new System.Drawing.Size(97, 22);
            this.btnAddHours.TabIndex = 20;
            this.btnAddHours.Text = "+ 1 Hour";
            this.btnAddHours.UseVisualStyleBackColor = true;
            this.btnAddHours.Click += new System.EventHandler(this.btnAddHours_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Or use these speed buttons";
            // 
            // btnResumeAutomation
            // 
            this.btnResumeAutomation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnResumeAutomation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumeAutomation.Location = new System.Drawing.Point(12, 224);
            this.btnResumeAutomation.Name = "btnResumeAutomation";
            this.btnResumeAutomation.Size = new System.Drawing.Size(203, 23);
            this.btnResumeAutomation.TabIndex = 100;
            this.btnResumeAutomation.Text = "Just Resume Automation!";
            this.btnResumeAutomation.UseVisualStyleBackColor = true;
            this.btnResumeAutomation.Click += new System.EventHandler(this.btnResumeAutomation_Click);
            // 
            // btnSubtractHours
            // 
            this.btnSubtractHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtractHours.Location = new System.Drawing.Point(12, 131);
            this.btnSubtractHours.Name = "btnSubtractHours";
            this.btnSubtractHours.Size = new System.Drawing.Size(97, 22);
            this.btnSubtractHours.TabIndex = 40;
            this.btnSubtractHours.Text = "- 1 Hour";
            this.btnSubtractHours.UseVisualStyleBackColor = true;
            this.btnSubtractHours.Click += new System.EventHandler(this.btnSubtractHours_Click);
            // 
            // btnSubtractMinutes
            // 
            this.btnSubtractMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtractMinutes.Location = new System.Drawing.Point(118, 131);
            this.btnSubtractMinutes.Name = "btnSubtractMinutes";
            this.btnSubtractMinutes.Size = new System.Drawing.Size(97, 22);
            this.btnSubtractMinutes.TabIndex = 50;
            this.btnSubtractMinutes.Text = "- 10 Min";
            this.btnSubtractMinutes.UseVisualStyleBackColor = true;
            this.btnSubtractMinutes.Click += new System.EventHandler(this.btnSubtractMinutes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Or just resume automation";
            // 
            // frmSuspendAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 259);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubtractHours);
            this.Controls.Add(this.btnSubtractMinutes);
            this.Controls.Add(this.btnResumeAutomation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddHours);
            this.Controls.Add(this.btnAddMins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentlySuspendedTill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DTP1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSuspendAutomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Automation Suspension";
            this.Load += new System.EventHandler(this.frmSuspendAutomation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTP1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentlySuspendedTill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddMins;
        private System.Windows.Forms.Button btnAddHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResumeAutomation;
        private System.Windows.Forms.Button btnSubtractHours;
        private System.Windows.Forms.Button btnSubtractMinutes;
        private System.Windows.Forms.Label label4;
    }
}