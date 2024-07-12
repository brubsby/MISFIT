namespace MISFIT
{
    partial class frmGIMPSresultsUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGIMPSresultsUpload));
            this.txtLogWindow = new System.Windows.Forms.TextBox();
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblUploadCheck = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblWorkStatus = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogWindow
            // 
            this.txtLogWindow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLogWindow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogWindow.ForeColor = System.Drawing.Color.Black;
            this.txtLogWindow.Location = new System.Drawing.Point(12, 28);
            this.txtLogWindow.Multiline = true;
            this.txtLogWindow.Name = "txtLogWindow";
            this.txtLogWindow.ReadOnly = true;
            this.txtLogWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogWindow.Size = new System.Drawing.Size(622, 267);
            this.txtLogWindow.TabIndex = 7;
            // 
            // timer7
            // 
            this.timer7.Interval = 1000;
            this.timer7.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Event Log";
            // 
            // lblUploadCheck
            // 
            this.lblUploadCheck.AutoSize = true;
            this.lblUploadCheck.Location = new System.Drawing.Point(149, 9);
            this.lblUploadCheck.Name = "lblUploadCheck";
            this.lblUploadCheck.Size = new System.Drawing.Size(128, 13);
            this.lblUploadCheck.TabIndex = 11;
            this.lblUploadCheck.Text = "Waiting to perform upload";
            this.lblUploadCheck.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(284, 5);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Maximum = 60;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 20);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // lblWorkStatus
            // 
            this.lblWorkStatus.BackColor = System.Drawing.Color.DimGray;
            this.lblWorkStatus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkStatus.ForeColor = System.Drawing.Color.White;
            this.lblWorkStatus.Location = new System.Drawing.Point(12, 298);
            this.lblWorkStatus.Name = "lblWorkStatus";
            this.lblWorkStatus.Size = new System.Drawing.Size(622, 24);
            this.lblWorkStatus.TabIndex = 13;
            this.lblWorkStatus.Text = "..";
            this.lblWorkStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(559, 5);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(75, 20);
            this.btnRetry.TabIndex = 14;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // frmGIMPSresultsUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 329);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.lblWorkStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblUploadCheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLogWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGIMPSresultsUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GIMPS IO Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWebIO_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWebIO_FormClosed);
            this.Load += new System.EventHandler(this.frmWebIO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogWindow;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUploadCheck;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblWorkStatus;
        private System.Windows.Forms.Button btnRetry;
    }
}