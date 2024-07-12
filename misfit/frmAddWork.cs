using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MISFIT
{
    public partial class frmAddWork : Form
    {
        public frmAddWork()
        {
            InitializeComponent();
        }

       // public string firstWorker = string.Empty;
       public Globals globals;
       public bool DataWasSaved = false;
     

        private void bntSave_Click(object sender, EventArgs e)
        {
           
            if (txtWork.Text.Length > 0)
            {
                string[] lines = txtWork.Lines;
                string offending = string.Empty;
                bool isClean = true;

              
                foreach (string x in lines)
                {
                    if (x.Length > 0 && !x.StartsWith(Globals.PHRASE_WORKTODO_EXPONENT_ROW))
                    {
                        offending += x + "\r\n";
                        isClean = false;
                    }
               }

                if (isClean)
                {
                    DialogResult dres = DialogResult.Yes;
                    if (globals.cfg.settingShowConfirmationDialogs)
                        dres = MsgBox.Show("Add work to staging file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dres != DialogResult.Yes)
                        return;
                    try
                    {
                        Globals.FileAppend_ListToFile(Globals.FILE_MISFIT_WORK_TODO, Globals.TerminatedStringLinesToList("\r\n" + txtWork.Text));
                        DataWasSaved = true;
                        Globals.simpleMessageBox("Data was appended to " + Globals.FILE_MISFIT_WORK_TODO + " OK");
                        txtWork.Clear();
                        this.Close();
                   
                        
                                        
                    }
                    catch (Exception E)
                    {
                        Globals.simpleMessageBox(E.Message);
                        
                    }



                }

                else
                {
                   const int maax = 300;
                    if (offending.Length > maax)
                        offending = offending.Substring(0, maax);
                    Globals.simpleMessageBox("Not Saved: Found offending text!\r\n" + offending);
                }

            }
            else
            {
                Globals.simpleMessageBox("Nothing to save!");
            }
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            if (txtWork.Text.Length > 0)
            {
                
                Globals.simpleMessageBox("Cannot close when text exists in textbox!");
            }
            else
            {
                //this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void AddWork_Load(object sender, EventArgs e)
        {
            this.btnCancel.Select();
            txtPath.Text = Environment.CurrentDirectory + "\\" +Globals.FILE_MISFIT_WORK_TODO;
            switch (globals.cfg.settingWorkFetchMode)
            {
                case (int)Config.AutoWorkFetchModes.DISABLED:
                    btnFetch.Enabled = false;
                    break;

                case (int)Config.AutoWorkFetchModes.GIMPS:
                    btnFetch.Enabled = true;
                    btnFetch.Text = "FETCH FROM GIMPS";
                    break;

                case (int)Config.AutoWorkFetchModes.GPU72:
                    btnFetch.Enabled = true;
                    btnFetch.Text = "FETCH FROM GPU72";
                    break;
                case (int)Config.AutoWorkFetchModes.EXTERNAL_COMMAND:
                    btnFetch.Enabled = false;
                    break;
                default:
                    btnFetch.Enabled = false;
                    break;


            }

            if(!btnFetch.Enabled)
            {
                Application.DoEvents();
               
                Globals.simpleMessageBox("No fetching sources configured!\r\nYou can only paste new work here now.");
                //this.Close();
            }
        }

        private void chkFactorUp_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkFactorUp.Checked && globals.cfg.settingShowConfirmationDialogs)
            //    Globals.simpleMessageBox("All factors TO value will be changed to 2^" + numericUpDown2.Value + " on save");
                
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Escape)
                this.Close();
        
        }



       


        private string FetchWorkFromButton()
        {
            List<string> AssignmentList = new List<string>();
            DialogResult res = DialogResult.Yes;
            if (globals.cfg.settingShowConfirmationDialogs)              
               res = MsgBox.Show("Fetch work now?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                try
                {
                    switch (globals.cfg.settingWorkFetchMode)
                    {

                        case (int)Config.AutoWorkFetchModes.GIMPS:

                                this.Cursor = Cursors.WaitCursor;
                                AssignmentList = globals.FetchGimps();
                                Globals.ChangeTOBitLevel(AssignmentList, globals.cfg.settingWorkFetchBitLevelTo);
                                break;

                        case (int)Config.AutoWorkFetchModes.GPU72:
                            Debug.WriteLine("Calling Gpu72.FetchWork");
                            AssignmentList = globals.FetchGpu72();
                            break;

                    }

                    if (globals.cfg.settingWorkFetchReplaceIdentifierWithDate)
                        Globals.ReplaceFactorLinePlaceHolderWithDate(AssignmentList);


                }

                catch (Exception E)
                {
                    Globals.simpleMessageBox("Error during fetch:\r\n" + E.Message);

                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            return Globals.ListStringToString(AssignmentList);
        }





        private void btnFetch_Click(object sender, EventArgs e)
        {

            
            txtWork.AppendText(FetchWorkFromButton());
           

            
            
        }

        private void txtWork_TextChanged(object sender, EventArgs e)
        {
            string[] lines = txtWork.Lines;
            lblCount.Text = "Lines=" + lines.Length.ToString();
        }    
    }
}
