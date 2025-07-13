using Logger;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddIn1.Ribbon
{

    partial class DataRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        private RibbonTab tab;
        private RibbonGroup group;
        private RibbonButton btnStartProcessing;
        private RibbonCheckBox chkShowPane;
        private RibbonDropDown ddLogLevel;

        private void InitializeComponent()
        {
            this.tab = this.Factory.CreateRibbonTab();
            this.group = this.Factory.CreateRibbonGroup();
            this.btnStartProcessing = this.Factory.CreateRibbonButton();
            this.chkShowPane = this.Factory.CreateRibbonCheckBox();
            this.ddLogLevel = this.Factory.CreateRibbonDropDown();

            this.tab.Label = "Async AddIn";
            this.tab.Groups.Add(this.group);

            this.group.Label = "Actions";
            this.group.Items.Add(this.btnStartProcessing);
            this.group.Items.Add(this.ddLogLevel);
            this.group.Items.Add(this.chkShowPane);

            this.chkShowPane.Label = "Show Data Processor";
            this.chkShowPane.Checked = true;
            this.chkShowPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkShowPane_Click);

            this.ddLogLevel.Label = "Log Level";
            this.ddLogLevel.Items.Add(this.Factory.CreateRibbonDropDownItem());
            this.ddLogLevel.Items[0].Label = "None";
            this.ddLogLevel.Items.Add(this.Factory.CreateRibbonDropDownItem());
            this.ddLogLevel.Items[1].Label = "Debug";
            this.ddLogLevel.Items.Add(this.Factory.CreateRibbonDropDownItem());
            this.ddLogLevel.Items[2].Label = "Info";
            this.ddLogLevel.Items.Add(this.Factory.CreateRibbonDropDownItem());
            this.ddLogLevel.Items[3].Label = "Warning";
            this.ddLogLevel.Items.Add(this.Factory.CreateRibbonDropDownItem());
            this.ddLogLevel.Items[4].Label = "Error";
            this.ddLogLevel.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ddLogLevel_SelectionChanged);
            this.ddLogLevel.SelectedItemIndex = (int)PaneLogger.Level;

            this.btnStartProcessing.Label = "Run Queries";
            this.btnStartProcessing.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartProcessing_Click);

            this.Name = "DataRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.DataRibbon_Load);
        }
    }
}