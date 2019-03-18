namespace P01_Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Contracts;
    using Loggers.Enums;
    using System.IO;

    public class FileAppender : IAppender
    {
        private const string path = "../../../log.txt";
        private readonly ILayout layout;
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + "\n";
                File.AppendAllText(path, content);
            }
        }
    }
}
