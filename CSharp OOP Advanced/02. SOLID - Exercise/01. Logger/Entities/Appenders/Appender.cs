namespace _01._Logger.Entities.Appenders
{
    using _01._Logger.Enums;
    using _01._Logger.Interfaces;

    public abstract class Appender : IAppender
    {
        private const ErrorLevel DefaultReportLevel = ErrorLevel.INFO;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ErrorLevel = DefaultReportLevel;
        }

        public ErrorLevel ErrorLevel { get; set; }

        public ILayout Layout { get; private set; }

        protected int MessagesCount { get; set; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}
