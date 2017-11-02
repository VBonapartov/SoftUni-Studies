using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            string pattern = @"(?:\|<)\w{" + elements[0] + @"}(?<view>(?:\w[^\|\<]*?){1," + elements[1] + "})";
            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> views = matches
                                   .Cast<Match>()
                                   .Select(v => v.Groups["view"].Value)
                                   .ToList();

            Console.WriteLine(string.Join(", ", views));
        }
    }
}
