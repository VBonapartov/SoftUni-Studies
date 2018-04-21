namespace _01._Logger.Interfaces
{    
    using System;
    using _01._Logger.Enums;

    public interface IError
    {
        DateTime DateTime { get; }

        ErrorLevel ErrorLevel { get; }

        string Message { get; }
    }
}
