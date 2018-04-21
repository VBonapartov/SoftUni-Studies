namespace _01._Logger.Entities.Appenders
{   
    using System;
    using System.IO;
    using _01._Logger.Attributes;
    using _01._Logger.Interfaces;

    public class FileAppender : Appender
    {
        [Inject]
        private string defaultFileName = string.Empty;

        public FileAppender(ILayout layout) : base(layout)
        {            
            this.File = new LogFile();
        }

        private ILogFile File { get; set; }

        public override void Append(IError error)
        {
            string report = this.Layout.FormatError(error);
            this.File.Write(report);
            System.IO.File.AppendAllText(this.defaultFileName, report + Environment.NewLine);
            this.MessagesCount++;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.File.Size}";
        }
    }
}
