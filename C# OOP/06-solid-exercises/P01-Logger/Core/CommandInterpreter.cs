namespace P01_Logger.Core
{
    using Contracts;
    using Appenders.Contracts;
    using System;
    using System.Collections.Generic;
    using Loggers.Enums;
    using Appenders.Factory.Contracts;
    using Appenders.Factory;
    using Layouts.Contracts;
    using Layouts.Factory.Contracts;
    using Layouts.Factory;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] input)
        {
            string appenderType = input[0];
            string layoutType = input[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (input.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(input[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            this.appenders.Add(appender);
        }

        public void AddMessage(string[] input)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(input[0]);
            string dateTime = input[1];
            string message = input[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
