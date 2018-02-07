namespace BashSoft
{
    using System;

    class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {    
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();

                if(input.Equals(endCommand))
                {
                    break;
                }

                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}
