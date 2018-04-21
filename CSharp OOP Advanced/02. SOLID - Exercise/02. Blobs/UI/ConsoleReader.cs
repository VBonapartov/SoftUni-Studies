using System;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        string line = Console.ReadLine();

        return line;
    }
}
