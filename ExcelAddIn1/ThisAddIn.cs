using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Logger;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using ExcelAddIn1.Popup;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private CustomTaskPaneCollection customTaskPanes;
        private CustomTaskPane customTaskPane;
        public PaneLogger logger;
        private CancellationTokenSource cts;
        ProcessingDialog dialog = null;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ExcelAppContext.Initialize();

            logger = new PaneLogger();

            customTaskPane = this.CustomTaskPanes.Add(logger, "Logging");
            customTaskPane.Visible = PaneLogger.Level == PaneLogger.LogLevel.None ? false : true;
        }

        public void ShowProgressPane()
        {
            if (customTaskPane == null)
            {
                logger = new PaneLogger();
                customTaskPane = this.CustomTaskPanes.Add(logger, "Logging");
            }
            customTaskPane.Visible = true;
        }

        public void ToggleProgressPane(bool show)
        {
            if (customTaskPane != null)
                customTaskPane.Visible = show;
        }

        public void StartDataProcessing()
        {
            cts = new CancellationTokenSource();
            var token = cts.Token;
            var hwnd = new IntPtr(Globals.ThisAddIn.Application.Hwnd);
            var owner = new ExcelWindowWrapper(hwnd);

            var dialog = new ProcessingDialog();
            dialog.CancelRequested += () => cts.Cancel();

            Task.Run(async () =>
            {
                ExcelAppContext.RunOnMainThread(() =>
                {
                    logger.Clear();
                    dialog?.SetMessage("Starting data fetch...");
                    logger.LogInfo("Started processing.");
                });

                var client = new HttpClient();

                for (int i = 1; i <= 5; i++)
                {
                     await Task.Delay(2000); // Simulate some delay for each page fetch
                    if (token.IsCancellationRequested)
                    {
                        ExcelAppContext.RunOnMainThread(() => logger.LogInfo("Operation cancelled."));
                        break;
                    }

                    int page = i;
                    ExcelAppContext.RunOnMainThread(() =>
                    {
                        dialog?.SetMessage($"Fetching page {page}/5");
                        logger.LogInfo($"Requesting page {page}");
                    });

                    try
                    {
                        string url = $"https://jsonplaceholder.typicode.com/posts/{page}";
                        var response = await client.GetAsync(url, token);
                        var content = await response.Content.ReadAsStringAsync(); // Removed the token argument  

                        ExcelAppContext.RunOnMainThread(() =>
                        {
                            var sheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                            sheet.Cells[page, 1].Value = content.Substring(0, Math.Min(100, content.Length));
                            logger.LogInfo($"Loaded page {page} to Excel");
                        });
                    }
                    catch (OperationCanceledException)
                    {
                        ExcelAppContext.RunOnMainThread(() => logger.LogInfo("Operation cancelled."));
                        break;
                    }
                    catch (Exception ex)
                    {
                        ExcelAppContext.RunOnMainThread(() => logger.LogInfo($"Error fetching page {page}: {ex.Message}"));
                    }
                }

                ExcelAppContext.RunOnMainThread(() =>
                {
                    dialog?.SetMessage("Processing complete.");
                    logger.LogInfo("Task ended.");
                    if (dialog != null && !dialog.IsDisposed)
                    {
                        dialog.Close(); // Now it's safe
                        dialog.Dispose();
                    }
                });


            });

            //Task.Run(() => dialog.ShowDialog(owner));
            dialog.FormClosed += (s, e) =>
            {
                if (cts != null)
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                }
            };

            ExcelAppContext.RunOnMainThread(() =>
            {
                dialog.ShowDialog(new ExcelWindowWrapper(new IntPtr(Globals.ThisAddIn.Application.Hwnd)));
            });

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code  

        /// <summary>  
        /// Required method for Designer support - do not modify  
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
