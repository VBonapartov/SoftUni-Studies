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

        IExecutable command = (IExecutable)Activator.CreateInstance(commandNameType, new object[] { data });
        this.InjectDependencies(commandNameType, command);

        return command;
    }

    private void InjectDependencies(Type commandNameType, IExecutable command)
    {
        FieldInfo[] commandNameFields = commandNameType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo[] interpreterFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo fieldCommand in commandNameFields)
        {
            if (fieldCommand.GetCustomAttributes(typeof(InjectAttribute)) == null)
            {
                continue;
            }

            if (interpreterFields.Any(ifield => ifield.FieldType.Equals(fieldCommand.FieldType)))
            {
                object fieldValue = interpreterFields.First(iField => iField.FieldType.Equals(fieldCommand.FieldType)).GetValue(this);
                fieldCommand.SetValue(command, fieldValue);
            }
        }
    }
}
