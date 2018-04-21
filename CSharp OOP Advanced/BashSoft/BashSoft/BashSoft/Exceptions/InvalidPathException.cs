namespace BashSoft.Exceptions
{
    using System;

    public class InvalidPathException : Exception
    {
        private const string InvalidPath = "The source does not exists.";

        public InvalidPathException()
            : base(InvalidPath)
        {
        }

        public InvalidPathException(string message)
            : base(message)
        {
        }
    }
}