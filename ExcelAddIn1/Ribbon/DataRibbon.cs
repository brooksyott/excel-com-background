using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Logger;
using Microsoft.Office.Tools.Ribbon;
using static Logger.PaneLogger;

namespace ExcelAddIn1.Ribbon
{
    public partial class DataRibbon : RibbonBase
    {
        public DataRibbon() : base(Globals.Factory.GetRibbonFactory()) { InitializeComponent(); }

        private void DataRibbon_Load(object sender, RibbonUIEventArgs e) { }

        private void btnStartProcessing_Click(object sender, RibbonControlEventArgs e)
        {
            if (chkShowPane.Checked)
            {
                Globals.ThisAddIn.ShowProgressPane();
            }
            Globals.ThisAddIn.StartDataProcessing();
        }

        private void chkShowPane_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ToggleProgressPane(chkShowPane.Checked);
        }

        private void ddLogLevel_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            PaneLogger.SetLogLevel(ddLogLevel.SelectedItem.Label);
            if (ddLogLevel.SelectedItem.Label == "None")
            {
                Globals.ThisAddIn.ToggleProgressPane(false); // disable the logging window
                chkShowPane.Checked = false; // uncheck the checkbox
            }
            else
            {
                Globals.ThisAddIn.ToggleProgressPane(true); // logging enabled
                chkShowPane.Checked = true; // uncheck the checkbox
            }
        }
    }
}

