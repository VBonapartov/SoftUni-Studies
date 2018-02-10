namespace _04.JediDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> code = ReadCode();
            List<Method> methods = ParseCode(code);
            PrintResult(methods);
        }

        private static List<string> ReadCode()
        {
            List<string> code = new List<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfLines; i++)
            {
                code.Add(Console.ReadLine().Trim());
            }

            return code;
        }

        private static List<Method> ParseCode(List<string> code)
        {
            List<Method> methods = new List<Method>();

            string methodPattern = @"static\s+.*\s+(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
            string invokedMethodPattern = @"(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
            
            foreach (string line in code)
            {
                Match methodMatch = Regex.Match(line, methodPattern);
                MatchCollection invokedMethodsMatches = Regex.Matches(line, invokedMethodPattern);

                if (methodMatch.Success)
                {
                    methods.Add(new Method(methodMatch.Groups["methodName"].Value));
                }
                else
                {
                    Method method = methods.LastOrDefault();

                    if (method != null)
                    {
                        foreach (Match mhMatch in invokedMethodsMatches)
                        {
                            method.AddInvokedMethod(mhMatch.Groups["methodName"].Value);
                        }
                    }
                }
            }

            return methods;
        }

        private static void PrintResult(List<Method> methods)
        {
            List<Method> sortedMethods = methods
                                            .OrderByDescending(m => m.NumberOfInvokedMethods())
                                            .ThenBy(m => m.Name)
                                            .ToList();

            foreach(Method method in sortedMethods)
            {
                Console.WriteLine(method);
            }
        }
    }
}
