namespace MISFIT
{
    partial class frmAutoConfigCrap
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
            this.nudGHZDZ = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAlert = new System.Windows.Forms.TextBox();
            this.txtGHzDsReference = new System.Windows.Forms.TextBox();
            this.lbl89 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhDzToAssign = new System.Windows.Forms.TextBox();
            this.txtDrain = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtFetchCount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFetchWhen = new System.Windows.Forms.TextBox();
            this.lblFetchThreshold = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudExponentMill = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.nudBitLevelMax = new System.Windows.Forms.NumericUpDown();
            this.nudBitLevelMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudGHZDZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExponentMill)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitLevelMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitLevelMin)).BeginInit();
            this.SuspendLayout();
            // 
            // nudGHZDZ
            // 
            this.nudGHZDZ.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudGHZDZ.Location = new System.Drawing.Point(163, 24);
            this.nudGHZDZ.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.nudGHZDZ.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudGHZDZ.Name = "nudGHZDZ";
            this.nudGHZDZ.Size = new System.Drawing.Size(52, 20);
            this.nudGHZDZ.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nudGHZDZ, "Measured GHz Days output from GPU(s)");
            this.nudGHZDZ.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudGHZDZ.ValueChanged += new System.EventHandler(this.nudGHZDZ_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAlert);
            this.groupBox1.Controls.Add(this.txtGHzDsReference);
            this.groupBox1.Controls.Add(this.lbl89);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGhDzToAssign);
            this.groupBox1.Controls.Add(this.txtDrain);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.txtFetchCount);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtFetchWhen);
            this.groupBox1.Controls.Add(this.lblFetchThreshold);
            this.groupBox1.Location = new System.Drawing.Point(9, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 190);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resulting Values";
            // 
            // txtAlert
            // 
            this.txtAlert.Location = new System.Drawing.Point(317, 149);
            this.txtAlert.Name = "txtAlert";
            this.txtAlert.ReadOnly = true;
            this.txtAlert.Size = new System.Drawing.Size(91, 20);
            this.txtAlert.TabIndex = 594;
            // 
            // txtGHzDsReference
            // 
            this.txtGHzDsReference.Location = new System.Drawing.Point(317, 22);
            this.txtGHzDsReference.Name = "txtGHzDsReference";
            this.txtGHzDsReference.ReadOnly = true;
            this.txtGHzDsReference.Size = new System.Drawing.Size(91, 20);
            this.txtGHzDsReference.TabIndex = 582;
            this.txtGHzDsReference.TextChanged += new System.EventHandler(this.txtGHzDsReference_TextChanged);
            // 
            // lbl89
            // 
            this.lbl89.AutoSize = true;
            this.lbl89.Location = new System.Drawing.Point(6, 153);
            this.lbl89.Name = "lbl89";
            this.lbl89.Size = new System.Drawing.Size(160, 13);
            this.lbl89.TabIndex = 593;
            this.lbl89.Text = "Alert if GHzDsToDo drops below";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 581;
            this.label5.Text = "GHzDs Reference";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtGhDzToAssign
            // 
            this.txtGhDzToAssign.Location = new System.Drawing.Point(317, 123);
            this.txtGhDzToAssign.Name = "txtGhDzToAssign";
            this.txtGhDzToAssign.ReadOnly = true;
            this.txtGhDzToAssign.Size = new System.Drawing.Size(91, 20);
            this.txtGhDzToAssign.TabIndex = 592;
            // 
            // txtDrain
            // 
            this.txtDrain.Location = new System.Drawing.Point(317, 96);
            this.txtDrain.Name = "txtDrain";
            this.txtDrain.ReadOnly = true;
            this.txtDrain.Size = new System.Drawing.Size(91, 20);
            this.txtDrain.TabIndex = 591;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 127);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(162, 13);
            this.label21.TabIndex = 590;
            this.label21.Text = "GHzDs to assign-out during drain";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 100);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(273, 13);
            this.label31.TabIndex = 589;
            this.label31.Text = "Drain MISFITworkToDo when GHzDsToDo drops below";
            // 
            // txtFetchCount
            // 
            this.txtFetchCount.Location = new System.Drawing.Point(317, 71);
            this.txtFetchCount.Name = "txtFetchCount";
            this.txtFetchCount.ReadOnly = true;
            this.txtFetchCount.Size = new System.Drawing.Size(91, 20);
            this.txtFetchCount.TabIndex = 588;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(156, 13);
            this.label20.TabIndex = 587;
            this.label20.Text = "Number of assignments to fetch";
            // 
            // txtFetchWhen
            // 
            this.txtFetchWhen.Location = new System.Drawing.Point(317, 48);
            this.txtFetchWhen.Name = "txtFetchWhen";
            this.txtFetchWhen.ReadOnly = true;
            this.txtFetchWhen.Size = new System.Drawing.Size(91, 20);
            this.txtFetchWhen.TabIndex = 580;
            // 
            // lblFetchThreshold
            // 
            this.lblFetchThreshold.AutoSize = true;
            this.lblFetchThreshold.Location = new System.Drawing.Point(6, 52);
            this.lblFetchThreshold.Name = "lblFetchThreshold";
            this.lblFetchThreshold.Size = new System.Drawing.Size(248, 13);
            this.lblFetchThreshold.TabIndex = 579;
            this.lblFetchThreshold.Text = "Fetch when MISFITworkToDo GHzDs drops below";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(322, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(215, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Max bit level";
            this.toolTip1.SetToolTip(this.label3, "Expected max bit level of assignments");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(414, 68);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Exponent Range (million)";
            // 
            // nudExponentMill
            // 
            this.nudExponentMill.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudExponentMill.Location = new System.Drawing.Point(163, 48);
            this.nudExponentMill.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudExponentMill.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudExponentMill.Name = "nudExponentMill";
            this.nudExponentMill.Size = new System.Drawing.Size(52, 20);
            this.nudExponentMill.TabIndex = 11;
            this.toolTip1.SetToolTip(this.nudExponentMill, "Expected exponent range of assignments");
            this.nudExponentMill.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.nudExponentMill.ValueChanged += new System.EventHandler(this.nudExponentMill_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Min bit level";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.nudBitLevelMax);
            this.groupBox3.Controls.Add(this.nudBitLevelMin);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nudGHZDZ);
            this.groupBox3.Controls.Add(this.nudExponentMill);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 140);
            this.groupBox3.TabIndex = 584;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variables";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(32, 89);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 24);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // nudBitLevelMax
            // 
            this.nudBitLevelMax.Location = new System.Drawing.Point(163, 96);
            this.nudBitLevelMax.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudBitLevelMax.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudBitLevelMax.Name = "nudBitLevelMax";
            this.nudBitLevelMax.Size = new System.Drawing.Size(52, 20);
            this.nudBitLevelMax.TabIndex = 17;
            this.toolTip1.SetToolTip(this.nudBitLevelMax, "Expected max bit level of assignments");
            this.nudBitLevelMax.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.nudBitLevelMax.ValueChanged += new System.EventHandler(this.nudBitLevelMax_ValueChanged);
            // 
            // nudBitLevelMin
            // 
            this.nudBitLevelMin.Location = new System.Drawing.Point(163, 72);
            this.nudBitLevelMin.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudBitLevelMin.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudBitLevelMin.Name = "nudBitLevelMin";
            this.nudBitLevelMin.Size = new System.Drawing.Size(52, 20);
            this.nudBitLevelMin.TabIndex = 16;
            this.toolTip1.SetToolTip(this.nudBitLevelMin, "Expected min bit level of assignments");
            this.nudBitLevelMin.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.nudBitLevelMin.ValueChanged += new System.EventHandler(this.nudBitLevelMin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "System GHzDs Output";
            // 
            // frmAutoConfigCrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmAutoConfigCrap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Configuration Calculator";
            this.Load += new System.EventHandler(this.frmAutoConfigCrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGHZDZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExponentMill)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitLevelMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitLevelMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudGHZDZ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFetchWhen;
        private System.Windows.Forms.Label lblFetchThreshold;
        private System.Windows.Forms.TextBox txtFetchCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtGhDzToAssign;
        private System.Windows.Forms.TextBox txtDrain;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtAlert;
        private System.Windows.Forms.Label lbl89;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudExponentMill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGHzDsReference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudBitLevelMax;
        private System.Windows.Forms.NumericUpDown nudBitLevelMin;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}