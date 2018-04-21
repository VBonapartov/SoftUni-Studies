namespace _01._Logger.Factories
{   
    using System;
    using System.Globalization;
    using _01._Logger.Entities;
    using _01._Logger.Enums;
    using _01._Logger.Interfaces;

    public class ErrorFactory
    {       
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string reportLevelString, string dateTimeString, string message)
        {
            ErrorLevel errorLevel = this.ParseErrorLevel(reportLevelString);
            DateTime dateTime = this.ParseDateTime(dateTimeString);

            IError error = new Error(errorLevel, dateTime, message);
            return error;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            bool isValidErrorLevel = Enum.TryParse(typeof(ErrorLevel), levelString, out object errorLevel);

            if (!isValidErrorLevel)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!");
            }

            return (ErrorLevel)errorLevel;
        }

        private DateTime ParseDateTime(string dateTimeString)
        {
            bool isValidDateTime = DateTime.TryParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isValidDateTime)
            {
                throw new ArgumentException("Invalid DateTime!");
            }

            return dateTime;
        }
    }
}
