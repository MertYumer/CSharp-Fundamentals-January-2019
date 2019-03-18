namespace P01_Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;
    using System;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}
