namespace _01._Logger.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _01._Logger.Enums;
    using _01._Logger.Factories;
    using _01._Logger.Interfaces;

    public class Controller
    {
        private readonly ICollection<IAppender> appenders;
        private AppenderFactory appenderFactory;
        private ErrorFactory errorFactory;

        public Controller(IList<IAppender> appenders, AppenderFactory appenderFactory, ErrorFactory errorFactory)
        {
            this.appenders = appenders;
            this.appenderFactory = appenderFactory;
            this.errorFactory = errorFactory;
        }

        public IReadOnlyCollection<IAppender> Appenders
        {
            get => this.appenders.ToList().AsReadOnly();
        }

        public void ReadAppendersFromConsole()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            while (numberOfAppenders > 0)
            {
                string[] input = Console.ReadLine().Split(' ');
                string appenderName = input[0];
                string layoutName = input[1];

                IAppender appender = this.appenderFactory.CreateAppender(appenderName, layoutName);

                if (input.Length == 3)
                {
                    this.SetLevelThreshold(appender, input[2]);
                }

                this.appenders.Add(appender);
                numberOfAppenders--;
            }
        }

        public void ExecuteCommands(ILogger logger)
        {
            string logMessage = string.Empty;

            while (!(logMessage = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = logMessage.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string errorLevelString = cmdArgs[0];
                string dateTimeString = cmdArgs[1];
                string message = cmdArgs[2];

                IError error = this.errorFactory.CreateError(errorLevelString, dateTimeString, message);
                logger.Log(error);
            }

            Console.WriteLine(logger);
        }

        private void SetLevelThreshold(IAppender appender, string thresholdName)
        {
            bool isValidErrorLevel = Enum.TryParse(thresholdName, out ErrorLevel levelThreshold);

            if (isValidErrorLevel)
            {
                appender.ErrorLevel = levelThreshold;
            }
        }
    }
}
