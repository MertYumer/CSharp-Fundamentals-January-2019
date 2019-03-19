namespace P01_Logger.Appenders.Contracts
{
    using Loggers.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
