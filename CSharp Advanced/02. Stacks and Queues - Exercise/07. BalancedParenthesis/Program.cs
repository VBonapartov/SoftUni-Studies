namespace _07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Console.WriteLine((IsExpressionBalanced(expression)) ? "YES" : "NO");
        }

        private static bool IsExpressionBalanced(string expression)
        {
            if (expression.Length % 2 != 0)
            {
                return false;
            }                

            Stack<char> parenthesises = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentParenthesis = expression[i];

                if (currentParenthesis.Equals('(') ||
                    currentParenthesis.Equals('{') ||
                    currentParenthesis.Equals('['))
                {
                    parenthesises.Push(expression[i]);
                }
                else
                {
                    if (currentParenthesis.Equals(')'))
                    {
                        if (!parenthesises.Pop().Equals('('))
                        {
                            return false;
                        }
                    }
                    else if (currentParenthesis.Equals('}'))
                    {
                        if (!parenthesises.Pop().Equals('{'))
                        {
                            return false;
                        }
                    }
                    else if (currentParenthesis.Equals(']'))
                    {
                        if (!parenthesises.Pop().Equals('['))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return parenthesises.Count == 0;
        }
    }
}