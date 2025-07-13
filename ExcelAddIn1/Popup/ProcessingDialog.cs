using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddIn1.Popup
{
    public partial class ProcessingDialog: Form
    {
        public event Action CancelRequested;

        public ProcessingDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke();
            btnCancel.Enabled = false;
            lblStatus.Text = "Cancelling...";
        }

        public void SetMessage(string message)
        {
            lblStatus.Text = message;
        }
    }
}
