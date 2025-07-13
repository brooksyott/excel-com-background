using System.Windows.Forms;

namespace Logger
{
    partial class PaneLogger
    {
        private Button btnCopyAll;
        private ListBox listBoxLog;

        private void InitializeComponent()
        {
            this.btnCopyAll = new Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.btnCopyAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCopyAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCopyAll.Location = new System.Drawing.Point(0, 0);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(1000, 30);
            this.btnCopyAll.TabIndex = 3;
            this.btnCopyAll.Text = "Copy All";
            this.btnCopyAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCopyAll.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Location = new System.Drawing.Point(0, 30);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1000, 170);
            this.listBoxLog.TabIndex = 0;
            // 
            // PaneLogger
            // 
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnCopyAll);
            this.Name = "PaneLogger";
            this.Size = new System.Drawing.Size(1000, 200);
            this.ResumeLayout(false);

        }
    }
}