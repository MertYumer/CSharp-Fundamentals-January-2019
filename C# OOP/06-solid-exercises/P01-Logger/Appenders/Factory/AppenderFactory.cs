namespace P01_Logger.Appenders.Factory
{
    using Contracts;
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);

                case "fileappender":
                    return new FileAppender(layout, new LogFile());

                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
