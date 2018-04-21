namespace BashSoft
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.IO.Commands;    

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[] { input, data };

            Type typeOfCommand = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                                        .Where(atr => atr.Equals(command))
                                                        .ToArray()
                                                        .Length > 0);

            if (typeOfCommand is null)
            {
                throw new InvalidCommandException(command);
            }

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            Type typeofInterpreter = typeof(CommandInterpreter);
            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeofInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType.Equals(fieldOfCommand.FieldType)))
                    {
                        object value = fieldsOfInterpreter.First(x => x.FieldType.Equals(fieldOfCommand.FieldType)).GetValue(this);
                        fieldOfCommand.SetValue(exe, value);
                    }
                }
            }

            return exe;
        }
    }
}
