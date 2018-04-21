namespace _01._Logger.Entities.Layouts
{    
    using System.Globalization;
    using _01._Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            return $"{dateString} - {error.ErrorLevel.ToString()} - {error.Message}";
        }
    }
}
