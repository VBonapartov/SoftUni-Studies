using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(<.{2}?>)";
            MatchCollection matchMines = Regex.Matches(input, pattern);

            StringBuilder result = new StringBuilder(input.Length);
            result.Append(input);
            foreach(Match matchMine in matchMines)
            {
                char firstCharacter = matchMine.Groups[1].Value[1];
                char secondCharacter = matchMine.Groups[1].Value[2];

                int minePower = Math.Abs(firstCharacter - secondCharacter);
                int startBlastRadius = matchMine.Index - minePower;
                int endBlastRadius = (matchMine.Index + 4) + minePower;

                startBlastRadius = (startBlastRadius < 0) ? 0 : startBlastRadius;
                endBlastRadius = (endBlastRadius > result.Length) ? result.Length : endBlastRadius;

                string beforeBlastRadius = result.ToString().Substring(0, startBlastRadius);
                string blastRadius = new string('_', endBlastRadius - startBlastRadius);
                string afterBlastRadius = result.ToString().Substring(endBlastRadius);

                result.Clear();
                result.Append(beforeBlastRadius + blastRadius + afterBlastRadius);
            }

            Console.WriteLine(result);
        }
    }
}
