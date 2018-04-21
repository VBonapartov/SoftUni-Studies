using System;

public class Engine : IRunnable
{
    private ICommandInterpreter interpreter;

    public Engine(ICommandInterpreter interpreter)
    {
        this.interpreter = interpreter;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                string commandName = data[0];

                string result = this.interpreter.InterpretCommand(data, commandName).Execute();
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}