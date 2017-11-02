using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambadaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> lambadaExpressions = new Dictionary<string, Dictionary<string, string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("lambada"))
            {
                string[] command = input.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0].Equals("dance"))
                {
                    lambadaExpressions = Dance(lambadaExpressions);
                }
                else
                {
                    string selector = command[0];
                    string[] selAttr = command[1].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    string selectorObject = selAttr[0];
                    string property = selAttr[1];

                    if (!lambadaExpressions.ContainsKey(selector))
                    {
                        lambadaExpressions.Add(selector, new Dictionary<string, string>());
                    }

                    lambadaExpressions[selector][selectorObject] = property;
                }
            }

            PrintLambadaExpressions(lambadaExpressions);
        }

        static private Dictionary<string, Dictionary<string, string>> Dance(Dictionary<string, Dictionary<string, string>> lambadaExpressions)
        {
            lambadaExpressions = lambadaExpressions
                                        .ToDictionary(
                                                       selector => selector.Key,
                                                       selector => selector.Value
                                                                              .ToDictionary(
                                                                                             sObj => sObj.Key,
                                                                                             sObj => sObj.Key + "." + sObj.Value
                                                                                            )
                                                     );

            return lambadaExpressions;
        }

        static private void PrintLambadaExpressions(Dictionary<string, Dictionary<string, string>> lambadaExpressions)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> selector in lambadaExpressions)
            {
                foreach (KeyValuePair<string, string> selObject in selector.Value)
                {
                    Console.WriteLine($"{selector.Key} => {selObject.Key}.{selObject.Value}");
                }
            }
        }
    }
}
