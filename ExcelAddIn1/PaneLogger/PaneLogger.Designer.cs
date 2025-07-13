using System.Windows.Forms;

namespace Logger
{
    partial class PaneLogger
    {
        private Label labelStatus;
        private ListBox listBoxLog;

        private void InitializeComponent()
        {
            this.labelStatus = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(300, 30);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Ready";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Location = new System.Drawing.Point(0, 30);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(300, 170);
            this.listBoxLog.TabIndex = 0;
            // 
            // ProgressPane
            // 
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelStatus);
            this.Name = "ProgressPane";
            this.Size = new System.Drawing.Size(1000, 200);
            this.ResumeLayout(false);

        }
    }
}