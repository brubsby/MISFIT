using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace MISFIT
{
    public partial class frmTextEditor : Form
    {
        public frmTextEditor()
        {
            InitializeComponent();
        }
        public Globals globals;
        public string FileToEdit = string.Empty;
        public bool FileIsReadOnly = true;


        private void LoadFile()
        {
            try
            {
               
                this.Text = "Editing File " + this.FileToEdit;
                if (this.FileIsReadOnly)
                    this.Text += " (READ ONLY)";
               
                txtData.Text = File.ReadAllText(FileToEdit);
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }
        }
        private void frmGimpsFavorites_Load(object sender, EventArgs e)
        {
            if (this.FileIsReadOnly)
            {
                btnAllowEdit.Enabled = false;
                btnExternalEditor.Enabled = false;
                btnRefresh.Enabled = false;
            }

            LoadFile();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

              
                DialogResult res = DialogResult.Yes;
                if (globals.cfg.settingShowConfirmationDialogs)
                    res = MsgBox.Show("Save " + this.FileToEdit + " ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Globals.backupFile(this.FileToEdit,"FILE_EDIT");
                    File.WriteAllText(this.FileToEdit, txtData.Text);
                    Globals.simpleMessageBox("Saved OK");
                    txtData.BackColor = Color.MintCream;
                    txtData.ForeColor = Color.Black;
                    txtData.ReadOnly = true;
                    btnAllowEdit.Enabled = true;
                    btnSave.Enabled = false;
                   
                }
            }
            catch (Exception E)
            {

                Globals.simpleMessageBox(E.Message);
            }
        }

        private void btnAllowEdit_Click(object sender, EventArgs e)
        {
            try
            {
               
                btnAllowEdit.Enabled = false;
                btnSave.Enabled = true;
                txtData.ReadOnly = false;
                txtData.BackColor = Color.Black;
                txtData.ForeColor = Color.LawnGreen;
               
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);

            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            
            txtData.BackColor = Color.MintCream;
            txtData.ForeColor = Color.Black;
            txtData.ReadOnly = true;
            btnAllowEdit.Enabled = true;
            btnSave.Enabled = false;
           
            LoadFile();
        }

        private void btnExternalEditor_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.FileToEdit);
                this.Close();
            }
            catch (Exception E)
            {
                Globals.simpleMessageBox(E.Message);
            }

        }

        private void frmTextEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

       
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
