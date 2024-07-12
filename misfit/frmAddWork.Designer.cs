namespace MISFIT
{
    partial class frmAddWork
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
            this.txtWork = new System.Windows.Forms.TextBox();
            this.bntSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWork
            // 
            this.txtWork.BackColor = System.Drawing.Color.Black;
            this.txtWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWork.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtWork.Location = new System.Drawing.Point(12, 12);
            this.txtWork.MaxLength = 131072;
            this.txtWork.Multiline = true;
            this.txtWork.Name = "txtWork";
            this.txtWork.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWork.Size = new System.Drawing.Size(333, 310);
            this.txtWork.TabIndex = 2;
            this.txtWork.WordWrap = false;
            this.txtWork.TextChanged += new System.EventHandler(this.txtWork_TextChanged);
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(252, 419);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(93, 28);
            this.bntSave.TabIndex = 1;
            this.bntSave.Text = "&Save";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.bntCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 341);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(333, 20);
            this.txtPath.TabIndex = 4;
            this.txtPath.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Work will be added to ";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(12, 367);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(333, 36);
            this.btnFetch.TabIndex = 10;
            this.btnFetch.Text = "&Fetch!";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 427);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(44, 13);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "Lines=0";
            // 
            // frmAddWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 456);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.txtWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stage work in MISFITworkToDo";
            this.Load += new System.EventHandler(this.AddWork_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWork;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Label lblCount;
    }
}