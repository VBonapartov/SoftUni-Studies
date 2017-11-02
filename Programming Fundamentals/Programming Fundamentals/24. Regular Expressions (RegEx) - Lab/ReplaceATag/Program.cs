using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = @"<ul><li><a href=""http://softuni.bg"">SoftUni</a></li></ul>";
            string pattern = @"<a.*href=('|"")(.*)\1>(.*?)<\/a>";
            string replacement = @"[URL href=$1$2$1]$3[/URL]";

            var regex = new Regex(pattern, RegexOptions.Multiline);
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            { 
                string result = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(result);
            }
        }
    }
}
