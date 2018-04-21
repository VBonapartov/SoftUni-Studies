namespace _01._Logger.Entities.Appenders
{    
    using System;
    using _01._Logger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(IError error)
        {
            Console.WriteLine(this.Layout.FormatError(error));
            this.MessagesCount++;
        }
    }
}
