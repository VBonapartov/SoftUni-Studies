namespace _01._Logger.Entities
{
    using System;
    using _01._Logger.Enums;
    using _01._Logger.Interfaces;

    public class Error : IError
    {
        public Error(ErrorLevel errorLevel, DateTime dateTime, string message)
        {
            this.ErrorLevel = errorLevel;
            this.DateTime = dateTime;
            this.Message = message;
        }

        public ErrorLevel ErrorLevel { get; private set; }

        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }
    }
}
