namespace _01._Logger.Entities.Layouts
{    
    using System.Globalization;
    using System.Text;
    using _01._Logger.Interfaces;

    public class XmlLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            StringBuilder report = new StringBuilder();

            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            return report.AppendLine("<log>")
                         .AppendLine($"\t<date>{dateString}</date>")
                         .AppendLine($"\t<level>{error.ErrorLevel.ToString()}</level>")
                         .AppendLine($"\t<message>{error.Message}</message>")
                         .Append("</log>")
                         .ToString();
        }
    }
}
