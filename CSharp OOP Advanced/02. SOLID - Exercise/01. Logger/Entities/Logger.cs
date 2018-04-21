namespace _01._Logger.Entities
{   
    using System.Collections.Generic;
    using System.Text;
    using _01._Logger.Interfaces;

    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
            this.AddAppenders(appenders);
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        private void AddAppenders(IEnumerable<IAppender> appenders)
        {
            foreach (IAppender appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }
    }
}
