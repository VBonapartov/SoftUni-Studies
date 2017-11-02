using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placeholders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string text = tokens[0];
                string[] elements = tokens[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < elements.Length; i++)
                    text = ReplacePlaceholders(text, elements[i], i);

                PrintText(text);
            }            
        }

        private static string ReplacePlaceholders(string text, string element, int index)
        {
            string placeholder = "{" + index + "}";
            return text.Replace(placeholder, element);
        }

        private static void PrintText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
