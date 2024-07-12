namespace MISFIT
{
    partial class frmSafeErrorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSafeErrorDialog));
            this.bntOK = new System.Windows.Forms.Button();
            this.txtErrorText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntOK.Location = new System.Drawing.Point(332, 178);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(71, 29);
            this.bntOK.TabIndex = 0;
            this.bntOK.Text = "&OK";
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // txtErrorText
            // 
            this.txtErrorText.Location = new System.Drawing.Point(11, 12);
            this.txtErrorText.MaxLength = 100000;
            this.txtErrorText.Multiline = true;
            this.txtErrorText.Name = "txtErrorText";
            this.txtErrorText.ReadOnly = true;
            this.txtErrorText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorText.Size = new System.Drawing.Size(712, 160);
            this.txtErrorText.TabIndex = 1;
            this.txtErrorText.TextChanged += new System.EventHandler(this.txtErrorText_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSafeErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 212);
            this.Controls.Add(this.txtErrorText);
            this.Controls.Add(this.bntOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSafeErrorDialog";
            this.Text = "MISFIT Alert Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSafeErrorDialog_FormClosing);
            this.Load += new System.EventHandler(this.frmSafeErrorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntOK;
        public System.Windows.Forms.TextBox txtErrorText;
        private System.Windows.Forms.Timer timer1;
    }
}