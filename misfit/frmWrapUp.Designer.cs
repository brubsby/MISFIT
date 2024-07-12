namespace MISFIT
{
    partial class frmWrapUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.numRowsToKeep = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnWrapItUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSendCompletionEmail = new System.Windows.Forms.CheckBox();
            this.chkUploadResults = new System.Windows.Forms.CheckBox();
            this.chkExecuteWrapUpBatch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRowsToKeep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rows to leave in each WorkToDo";
            // 
            // numRowsToKeep
            // 
            this.numRowsToKeep.Location = new System.Drawing.Point(190, 12);
            this.numRowsToKeep.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numRowsToKeep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowsToKeep.Name = "numRowsToKeep";
            this.numRowsToKeep.Size = new System.Drawing.Size(49, 20);
            this.numRowsToKeep.TabIndex = 1;
            this.numRowsToKeep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(24, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnWrapItUp
            // 
            this.btnWrapItUp.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnWrapItUp.Location = new System.Drawing.Point(126, 129);
            this.btnWrapItUp.Name = "btnWrapItUp";
            this.btnWrapItUp.Size = new System.Drawing.Size(92, 29);
            this.btnWrapItUp.TabIndex = 5;
            this.btnWrapItUp.Text = "Wrap it up";
            this.btnWrapItUp.UseVisualStyleBackColor = true;
            this.btnWrapItUp.Click += new System.EventHandler(this.btnWrapItUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(Applies to local paths only)";
            // 
            // chkSendCompletionEmail
            // 
            this.chkSendCompletionEmail.AutoSize = true;
            this.chkSendCompletionEmail.Checked = true;
            this.chkSendCompletionEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendCompletionEmail.Location = new System.Drawing.Point(18, 79);
            this.chkSendCompletionEmail.Name = "chkSendCompletionEmail";
            this.chkSendCompletionEmail.Size = new System.Drawing.Size(134, 17);
            this.chkSendCompletionEmail.TabIndex = 7;
            this.chkSendCompletionEmail.Text = "Send Completion Email";
            this.chkSendCompletionEmail.UseVisualStyleBackColor = true;
            // 
            // chkUploadResults
            // 
            this.chkUploadResults.AutoSize = true;
            this.chkUploadResults.Checked = true;
            this.chkUploadResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUploadResults.Location = new System.Drawing.Point(18, 56);
            this.chkUploadResults.Name = "chkUploadResults";
            this.chkUploadResults.Size = new System.Drawing.Size(98, 17);
            this.chkUploadResults.TabIndex = 8;
            this.chkUploadResults.Text = "Upload Results";
            this.chkUploadResults.UseVisualStyleBackColor = true;
            // 
            // chkExecuteWrapUpBatch
            // 
            this.chkExecuteWrapUpBatch.AutoSize = true;
            this.chkExecuteWrapUpBatch.Location = new System.Drawing.Point(18, 102);
            this.chkExecuteWrapUpBatch.Name = "chkExecuteWrapUpBatch";
            this.chkExecuteWrapUpBatch.Size = new System.Drawing.Size(126, 17);
            this.chkExecuteWrapUpBatch.TabIndex = 9;
            this.chkExecuteWrapUpBatch.Text = "Execute WrapUp.bat";
            this.chkExecuteWrapUpBatch.UseVisualStyleBackColor = true;
            // 
            // frmWrapUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 170);
            this.Controls.Add(this.chkExecuteWrapUpBatch);
            this.Controls.Add(this.chkUploadResults);
            this.Controls.Add(this.chkSendCompletionEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWrapItUp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numRowsToKeep);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmWrapUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wrap up processing";
            this.Load += new System.EventHandler(this.frmWrapUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRowsToKeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numRowsToKeep;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnWrapItUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSendCompletionEmail;
        private System.Windows.Forms.CheckBox chkUploadResults;
        private System.Windows.Forms.CheckBox chkExecuteWrapUpBatch;
    }
}