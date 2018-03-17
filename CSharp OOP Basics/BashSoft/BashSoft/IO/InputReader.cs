namespace BashSoft
{
    using System;

    public class InputReader
    {
        private const string EndCommand = "quit";

        private CommandInterpreter interpreter;        

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {    
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();

                if (input.Equals(EndCommand))
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
            }
        }
    }
}
