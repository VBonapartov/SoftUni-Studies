﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            IList<string> arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private IList<string> ParseInput(string input)
    {
        return input
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToList();
    }

    private string ProcessInput(IList<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Assembly
                  .GetExecutingAssembly()
                  .GetTypes()
                  .FirstOrDefault(t => t.Name == command + "Command");
        object[] commandParams = new object[] { arguments, this.heroManager };

        ICommand cmd = (ICommand)Activator.CreateInstance(commandType, commandParams);

        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}