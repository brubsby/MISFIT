using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.IO;


namespace MISFIT
{
    public partial class frmSafeErrorDialog : Form
    {
        public frmSafeErrorDialog()
        {
            InitializeComponent();
        }

        public Globals globals;
        public DateTime TimeStarted = DateTime.Now;
        public bool EmailSent = false;
        private string LogFileName = Globals.CreateFileName(Globals.DIR_MISFIT_BACKUPS + "\\" + Globals.FILE_PREFIX_ERRORFORM, Globals.FILE_EXT_TXT);
      

        private void frmSafeErrorDialog_Load(object sender, EventArgs e)
        {
            
            timer1.Interval = 30000;
            timer1.Enabled = true;

        }

        private void play()
        {

            this.BackColor=Color.Red;
            Application.DoEvents();
            SystemSounds.Exclamation.Play();
           Globals.Sleep(500);
            Application.DoEvents();
           Globals.Sleep(500);
            this.BackColor = SystemColors.Control;
            Application.DoEvents();

        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
            try
            {

                play();
                Debug.WriteLine("Window start time is " + this.TimeStarted.ToString());


                if (TimeStarted.AddMinutes(60) < DateTime.Now && !EmailSent && globals.cfg.isEmailConfigured() && globals.cfg.settingSendEmailWhenAlertPanelRemainsOpen)
                {
                    EmailSent = true;
                    txtErrorText.AppendText(DateTime.Now.ToString() + " " + "Sending Email since the Alert Panel has been opened > 60 minutes!" + "\r\n");
                    try
                    {
                        globals.GlobalSendEmail(globals.cfg.settingEmailSubjectAlertPanelRemainsOpen, "****************** CONTENT OF ALERT PANEL IS AS FOLLOWS ******************\r\n\r\n" + this.txtErrorText.Text);
                        
                    }
                    catch (Exception EE)
                    {
                        txtErrorText.AppendText("Error:" + EE.Message);
                    }
                }

                
            }
           
            catch (Exception E)
            {
                timer1.Enabled = false; 
                Globals.simpleMessageBox("Exception INSIDE Alert Panel:" + E.Message);
            }
        }

        private void frmSafeErrorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void txtErrorText_TextChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            File.WriteAllText(LogFileName, this.txtErrorText.Text);
        }
    }
}
