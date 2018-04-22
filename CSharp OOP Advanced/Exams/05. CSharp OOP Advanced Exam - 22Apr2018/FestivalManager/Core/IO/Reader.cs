namespace FestivalManager.Core.IO
{
    using System;
    using FestivalManager.Core.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}