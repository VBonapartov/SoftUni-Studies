using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandClassSuffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        string result = command.Execute();
        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        string fullCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandClassSuffix;

        Type commandType = Assembly
                                .GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(fullCommandName));

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new ArgumentException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo ctor = commandType.GetConstructors().First();
        ParameterInfo[] parameterInfos = ctor.GetParameters();
        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameterInfos.Length; i++)
        {
            Type paramType = parameterInfos[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType()
                                                .GetProperties()
                                                .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, parameters);
        return command;
    }
}