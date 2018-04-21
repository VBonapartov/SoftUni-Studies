using System;

public class Engine : IRunnable
{
    private IRepository repository;
    private IUnitFactory unitFactory;
    private ICommandInterpreter interpreter;

    public Engine(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
        this.interpreter = new CommandInterpreter(repository, unitFactory);
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