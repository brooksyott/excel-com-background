using System;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Logger
{
    public partial class PaneLogger : UserControl
    {
        public enum LogLevel
        {
            Debug = 0,
            Info,
            Warning,
            Error,
            None
        }

        static public LogLevel Level = LogLevel.Info;

        static public void SetLogLevel(string logLevel)
        {
            if (Enum.TryParse(logLevel, true, out LogLevel parsedLevel))
            {
                Level = parsedLevel;
            }
            else
            {
                throw new ArgumentException($"Invalid log level: {logLevel}");
            }
        }

        public PaneLogger()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            listBoxLog.Items.Clear();
        }

        private void Log(LogLevel logLevel, string message)
        {
            if (logLevel < Level)
                return;

            listBoxLog.Items.Add($"{DateTime.Now.ToString("HH:mm:ss.fff")}\t[{logLevel.ToString()}]\t{message}");
        }

        public void LogInfo(string message)
        { 
            Log(LogLevel.Info, message);
        }

        public void LogDebug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogLevel.Error, message);
        }


        private void labelStatus_Click(object sender, EventArgs e)
        {
            if (listBoxLog.Items.Count > 0)
            {
                var allText = new StringBuilder();

                foreach (var item in listBoxLog.Items)
                {
                    allText.AppendLine(item.ToString());
                }
                Clipboard.SetText(allText.ToString());
            }
        }
    }
}