using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISFIT
{
    public partial class frmSuspendAutomation : Form
    {
        public DateTime CurrentlySuspendedTill;
        public frmSuspendAutomation()
        {
            InitializeComponent();
        }

        private void frmSuspendAutomation_Load(object sender, EventArgs e)
        {
            this.btnCancel.Select();
            DTP1.MinDate = DateTime.Now;
            DTP1.MaxDate = DateTime.Now.AddDays(10);
            DTP1.Format = DateTimePickerFormat.Custom;
            DTP1.CustomFormat = "MM/dd/yyyy h:mm tt";
           
           // DTP1.ShowCheckBox = true;
            //DTP1.ShowUpDown = true;

            try
            {
                if (CurrentlySuspendedTill > DateTime.Now)
                {
                    DTP1.Value = CurrentlySuspendedTill;
                    txtCurrentlySuspendedTill.Text = CurrentlySuspendedTill.ToString("MM/dd/yyyy h:mm tt");

                }
                else
                {
                    DTP1.Value = DateTime.Now;
                    txtCurrentlySuspendedTill.Text = "N/A";

                }
            }
            catch(Exception E)
            {

                Globals.simpleMessageBox("Error loading Automation Suspension form\r\n" + E.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DTP1.Value > DateTime.Now)
            {
                CurrentlySuspendedTill = DTP1.Value;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Globals.simpleMessageBox("Date/Time cannot be in the past!");

            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnAddMins_Click(object sender, EventArgs e)
        {
           
            UpdateDTP(10);
        }

        private void btnAddHours_Click(object sender, EventArgs e)
        {
            UpdateDTP(60);
        }

        private void UpdateDTP( int MinutesChange)
        {
            try
            {
                DTP1.Value = DTP1.Value.AddMinutes(MinutesChange);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error changing time!\r\n" + E.Message);
            }
        }

        private void btnResumeAutomation_Click(object sender, EventArgs e)
        {
            CurrentlySuspendedTill = DateTime.Now.AddSeconds(-1);
            this.DialogResult = DialogResult.OK;
        }

        private void btnSubtractHours_Click(object sender, EventArgs e)
        {
            UpdateDTP(-60);
        }

        private void btnSubtractMinutes_Click(object sender, EventArgs e)
        {
            UpdateDTP(-10);
        }

       
    }
}
