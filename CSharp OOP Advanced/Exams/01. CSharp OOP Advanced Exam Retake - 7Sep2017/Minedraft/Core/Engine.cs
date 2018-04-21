using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string TerminatedCommand = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter interpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        string command = string.Empty;

        while (!command.Equals(TerminatedCommand))
        {
            List<string> data = this.reader.ReadLine()
                                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .ToList();

            command = data[0];

            try
            {
                string result = this.interpreter.ProcessCommand(data);
                this.writer.WriteLine(result);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}
