using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandClassSuffix = "Command";

    private IRepository repository;
    private IUnitFactory unitFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        string fullCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandClassSuffix;

        Type commandNameType = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(fullCommandName));

        if (commandNameType == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        if (!typeof(IExecutable).IsAssignableFrom(commandNameType))
        {
            throw new ArgumentException($"{commandName} is not a Command!");
        }

        return (IExecutable)Activator.CreateInstance(commandNameType, new object[] { data, this.repository, this.unitFactory });
    }
}
