using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace MISFIT
{
    public partial class frmRemoteControl : Form
    {
        public frmRemoteControl()
        {
            InitializeComponent();
        }
        public Globals globals;
        private const string cmd_INQUIRE="INQUIRE";
        private const string cmd_START = "START";
        private const string cmd_STOP= "STOP";
        private const string cmd_KILL = "KILL";

        private void frmRemoteControl_Load(object sender, EventArgs e)
        {
            this.btnClose.Select();
            this.Show();
            PopulateGrid();

           // ExecuteCommands(string.Empty);
        }


        public void PopulateGrid()
        {
           // int col = 0;
            //int row = 0;
            dgvRemote.Rows.Clear();
            //dgvRemote.Rows.Add(globals.cfg.settingLookinList.Count);

            

            Hashtable hst = new Hashtable();
            foreach (string path in globals.cfg.settingFactoringDirectories)
            {
                if(path.StartsWith(@"\\"))  //a unc!
                {
                    //Debug.WriteLine(path.Substring(1,path.IndexOf('\\')));
                    
                    try
                    {
                        string[] splitter = path.Split('\\');
                        hst.Add(splitter[2], "0");
                    }
                    catch
                    {
                        //didn't load a duplicate... good.
                        Debug.WriteLine("duplicate path. tossing");
                    }
                }
            }
            dgvRemote.Rows.Clear();
            dgvRemote.Rows.Add(hst.Count);
            int i = 0;
            foreach (object remotepath in hst.Keys)//LOAD UP THE GRID
            {
                dgvRemote[0, i].Value = (string)remotepath;
                dgvRemote[1, i].Value = string.Empty;
                i++;

            }



            if (hst.Count == 1)
            {

                groupBox1.Visible = false;
            }
           



        }



        

        private void ExecuteCommands()
        {
            string server = string.Empty;
            string command = string.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                for (int k = 0; k < dgvRemote.Rows.Count; k++)
                {
                    server = dgvRemote["REMOTE", k].Value.ToString();
                    command = string.Empty;

                  if (dgvRemote["COMMAND", k].Value != null)
                    {
                        command = dgvRemote["COMMAND", k].Value.ToString();
                    }
                   

                    if (command != string.Empty)
                    {
                        Debug.WriteLine(server + ":" + command + ":");
                        try
                        {
                            string resp = RemoteControl.SendCommand(server, command);
                            Debug.WriteLine("server response " + resp);
                            dgvRemote["LAST_RESPONSE", k].Value = resp;
                        }
                        catch (Exception EE)
                        {
                            //Globals.simpleMessageBox("Error sending " + command + " to server " + server + ".\r\n" + EE.Message + "!");
                            dgvRemote["LAST_RESPONSE", k].Value = EE.Message;
                        }


                    }
                    else
                    {
                       // Globals.simpleMessageBox("No command selected");
                    }

                    Application.DoEvents();
                }


            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExecuteRemoteAction_Click(object sender, EventArgs e)
        {
            string c = string.Empty;
            for (int k = 0; k < dgvRemote.Rows.Count; k++)
            {
                c = dgvRemote["COMMAND", k].Value.ToString();

            }

            if (c != string.Empty)
                ExecuteCommands();
            else
                Globals.simpleMessageBox("No commands selected");

        }

        private void cmbGlobalCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGlobalCommand.Text.StartsWith("REBOOT"))
            {
                Globals.simpleMessageBox("Warning! You selected a system wide reboot command!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        

        private void dgvRemote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgvRemote.Rows.Count; k++)
            {
                dgvRemote["COMMAND", k].Value = cmbGlobalCommand.Text;

            }
            Application.DoEvents();
            //ExecuteCommands();            
           
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
