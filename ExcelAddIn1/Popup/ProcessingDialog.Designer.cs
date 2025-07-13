using System.Windows.Forms;
using System;
using System.Drawing;

namespace ExcelAddIn1.Popup
{
    partial class ProcessingDialog
    {
        private Label lblStatus;
        private Button btnCancel;
        private ProgressBar progressBar;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStatus = new Label();
            this.btnCancel = new Button();
            this.progressBar = new ProgressBar();

            // lblStatus
            this.lblStatus.Text = "Fetching data...";
            this.lblStatus.Dock = DockStyle.Top;
            this.lblStatus.Height = 30;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // progressBar
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.Dock = DockStyle.Top;
            this.progressBar.Height = 20;

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Dock = DockStyle.Bottom;
            this.btnCancel.Height = 35;
            this.btnCancel.Click += (s, e) =>
            {
                btnCancel.Enabled = false;
                lblStatus.Text = "Cancelling...";
                CancelRequested?.Invoke();
            };

            // Form
            this.Text = "Processing";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ControlBox = false;
            this.Width = 350;
            this.Height = 130;
            this.ShowInTaskbar = false;

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
        }

        #endregion
    }
}