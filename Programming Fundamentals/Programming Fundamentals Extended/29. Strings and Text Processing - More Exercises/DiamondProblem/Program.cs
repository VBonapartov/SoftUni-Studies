using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> diamonds = FindsDiamonds(input);
            PrintDiamonds(diamonds);
        }

        private static List<int> FindsDiamonds(string input)
        {
            // Example input -> No>diamonds<<<<123<<<123>>>here
            List<int> diamonds = new List<int>();

            while (true)
            {
                int startIndex = input.IndexOf('<');
                int endIndex = input.IndexOf('>');              

                if(endIndex != -1)
                {
                    string temp = input.Substring(0, endIndex);
                    startIndex = temp.LastIndexOf('<');

                    if(startIndex != -1)
                    {
                        string diamond = input.Substring(startIndex + 1, endIndex - startIndex - 1);
                        input = input.Substring(endIndex + 1);
                        diamonds.Add(CalculateCarats(diamond));
                    }
                    else if(startIndex < endIndex)
                    {
                        input = input.Substring(endIndex + 1);
                    }
                }
                else
                {
                    break;
                }
            }

            return diamonds;
        }

        private static int CalculateCarats(string diamond)
        {
            return diamond.Where(c => char.IsDigit(c)).Select(c => Convert.ToInt32(c.ToString())).ToArray().Sum();
        }

        private static void PrintDiamonds(List<int> diamonds)
        {
            if (diamonds.Count > 0)
            {
                foreach (int carat in diamonds)
                {
                    Console.WriteLine($"Found {carat} carat diamond");
                }
            }
            else
            {
                Console.WriteLine("Better luck next time");
            }
        }
    }
}
