namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indecies = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (currentSymbol.Equals('('))
                {
                    indecies.Push(i);
                }
                else if (currentSymbol.Equals(')'))
                {
                    int openBracketIndex = indecies.Pop();

                    Console.WriteLine(ExtractSubExpression(input, openBracketIndex, i));
                }
            }
        }

        private static string ExtractSubExpression(string expression, int openBracketIndex, int closeBracketIndex)
        {
            return expression.Substring(openBracketIndex, closeBracketIndex - openBracketIndex + 1);
        }
    }
}
