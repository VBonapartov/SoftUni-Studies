namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static string text = string.Empty;
        private static Stack<string> previousTextState = new Stack<string>();

        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ExecuteCommand(command);
            }
        }

        private static void ExecuteCommand(string[] command)
        {
            switch (command[0])
            {
                case "1": // appends someString to the end of the text
                    previousTextState.Push(text);
                    text += command[1];
                    break;

                case "2": // erases the last count elements from the text
                    previousTextState.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(command[1]));
                    break;

                case "3": // returns the element at position index from the text
                    Console.WriteLine(text[int.Parse(command[1]) - 1]);
                    break;

                case "4": // undoes the last not undone command
                    text = previousTextState.Pop();
                    break;
            }
        }
    }
}
