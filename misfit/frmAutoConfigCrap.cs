using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MISFIT
{
    public partial class frmAutoConfigCrap : Form
    {
        public frmAutoConfigCrap()
        {
            InitializeComponent();
        }

        public int calcFetchThreshold = 0;
        public int calcDrainThreshold = 0;
        public int calcAlertAt = 0;
        public int calcNumToFetch=0;
        public int calcGhDzToAssign = 0;
        public int calcBitLevel = 0;
        public int calcGhDzToFetch = 0;
        private const string regSystemGHzDs = "GhzDayTotal";
        private const string regMinBitLevel = "MinBitLevel";
        private const string regExponentRange = "ExponentRange";
        private const int DEFAULT_EXPONENT_RANGE = 70;
        private const int DEFAULT_BIT_MIN = 68;
        private const int DEFAULT_BIT_MAX = 73;
        private const int DEFAULT_SYSTEM_GHZDS = 100;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudBitLevelMin.Value >= nudBitLevelMax.Value)
                    throw new Exception("Invalid bit level selected");


                double GHzDsReference = Globals.CalcGHDZ((int)(nudExponentMill.Value * 1000000), (int)nudBitLevelMin.Value, (int)nudBitLevelMax.Value);
                txtGHzDsReference.Text = GHzDsReference.ToString("N3");


                calcBitLevel = (int)nudBitLevelMax.Value;
                btnSave.Enabled = true;
                calcFetchThreshold = Convert.ToInt32((double)nudGHZDZ.Value * 1.25);
                calcDrainThreshold = Convert.ToInt32((double)nudGHZDZ.Value * .85);
                calcAlertAt = Convert.ToInt32((double)nudGHZDZ.Value * 0.5);
                calcGhDzToFetch = Convert.ToInt32((double)nudGHZDZ.Value);
                calcGhDzToAssign = Convert.ToInt32((double)nudGHZDZ.Value * 0.65);
                double fetchCount = (double)nudGHZDZ.Value / GHzDsReference;
                calcNumToFetch = Convert.ToInt32(fetchCount);
                if (calcNumToFetch > 100)
                    calcNumToFetch = 100;
                else if(calcNumToFetch==0)
                    calcNumToFetch=1;
               

               
                txtFetchCount.Text = calcNumToFetch.ToString();
                txtGhDzToAssign.Text = calcGhDzToAssign.ToString();
                txtFetchWhen.Text = calcFetchThreshold.ToString();
                txtDrain.Text = calcDrainThreshold.ToString();
                txtAlert.Text = calcAlertAt.ToString();
                
                
                if (calcNumToFetch==100)
                    throw new Exception("Maximum fetch count of 100 is indicated. Likely multiple fetches will be required in a single day!");
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

           
        }

        private void frmAutoConfigCrap_Load(object sender, EventArgs e)
        {


            try
            {
                this.btnClose.Select();
                RegistryKey rkey = Registry.CurrentUser;



                nudBitLevelMax.Value = calcBitLevel;
                textBox1.AppendText("The work calculator is useful if YOU know the total GhzDays output from your GPU(s) and you select meaningful variables. Work fetch sites (GIMPS, GPU72) may not return values you configure if those values are not meaningful to the project. If you are not sure what values to use then use the defaults to get started then use the forums to ask for more information. The calculated values are to ensure you have sufficient work queued up even if the work source is unavailable for an extended period of time.");



                string v = (string)rkey.GetValue(regSystemGHzDs, DEFAULT_SYSTEM_GHZDS.ToString());
                nudGHZDZ.Value = int.Parse(v);

                v = (string)rkey.GetValue(regExponentRange, DEFAULT_EXPONENT_RANGE.ToString());
                nudExponentMill.Value = int.Parse(v);

                v = (string)rkey.GetValue(regMinBitLevel, DEFAULT_BIT_MIN.ToString());
                nudBitLevelMin.Value = int.Parse(v);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Show("Do you want to set all configuration values to calculated values?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                RegistryKey rkey = Registry.CurrentUser;
                rkey.SetValue(regSystemGHzDs, nudGHZDZ.Value.ToString());
                rkey.SetValue(regExponentRange, nudExponentMill.Value.ToString());
                rkey.SetValue(regMinBitLevel, nudBitLevelMin.Value.ToString());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
               // this.DialogResult = DialogResult.Cancel;
            }
            
        }

        private void nudGHZDZ_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

       
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globals.simpleMessageBox(Globals.CalcGHDZ(65000000, 70, 73).ToString());
            Globals.simpleMessageBox(Globals.CalcGHDZ(332000000, 70, 73).ToString());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbBitLevelMin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGHzDsReference_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetVariableDefaults()
        {
            nudGHZDZ.Value = DEFAULT_SYSTEM_GHZDS;
            nudExponentMill.Value = DEFAULT_EXPONENT_RANGE;
            nudBitLevelMin.Value = DEFAULT_BIT_MIN;
            nudBitLevelMax.Value = DEFAULT_BIT_MAX;

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            SetVariableDefaults();
        }

        private void nudExponentMill_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void nudBitLevelMin_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void nudBitLevelMax_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        
    }
}
