using System;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}