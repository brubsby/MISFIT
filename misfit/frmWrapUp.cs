using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MISFIT
{
    public partial class frmWrapUp : Form
    {
       
        public frmWrapUp()
        {
            InitializeComponent();
        }

        public int RowsToLeaveInEachWorkToDo = 0;
        public bool SendEmail = false;
        public bool UploadResults = false;
        public bool ExecuteWrapUpBatch = false;
       


        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWrapItUp_Click(object sender, EventArgs e)
        {
            RowsToLeaveInEachWorkToDo = (int)numRowsToKeep.Value;
            SendEmail = chkSendCompletionEmail.Checked;
            UploadResults = chkUploadResults.Checked;
            ExecuteWrapUpBatch = chkExecuteWrapUpBatch.Checked;

        }

        private void frmWrapUp_Load(object sender, EventArgs e)
        {
            if (File.Exists(Globals.FILE_WRAPUP_BATCH))
            {
                chkExecuteWrapUpBatch.Enabled = true;
            }else
            {
                chkExecuteWrapUpBatch.Enabled = false;
            }

        }

      

       
    }
}
