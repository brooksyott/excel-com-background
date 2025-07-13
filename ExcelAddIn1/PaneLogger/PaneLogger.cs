using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Logger
{
    public partial class PaneLogger : UserControl
    {
        public enum LogLevel
        {
            None = 0,
            Debug,
            Info,
            Warning,
            Error
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

            listBoxLog.Items.Add($"{DateTime.Now.ToString("HH:mm:ss.fff")} [{logLevel.ToString()}] - {message}");
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
    }
}