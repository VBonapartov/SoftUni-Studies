using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tickets = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

            for(int i = 0; i < tickets.Count; i++)
            {
                bool isValidTicket = (tickets[i].Length == 20);
                if(!isValidTicket)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool isWinning = Regex.IsMatch(tickets[i], @"([\@\#\$\^])\1{19}");
                if(isWinning)
                {
                    Console.WriteLine($"ticket \"" + tickets[i] + "\" - 10" + tickets[i][0] + " Jackpot!");
                    continue;
                }

                Match matchLeftPart = Regex.Match(tickets[i].Substring(0, 10), @"([\@\#\$\^])\1{5,8}");
                if(matchLeftPart.Success)
                {
                    Match matchRightPart = Regex.Match(tickets[i].Substring(10), @"([\@\#\$\^])\1{5,8}");
                    if(matchRightPart.Success && matchLeftPart.Value[0].Equals(matchRightPart.Value[0]))
                    {
                        Console.WriteLine($"ticket \"" + tickets[i]  + $"\" - {Math.Min(matchLeftPart.Length, matchRightPart.Length)}{matchLeftPart.Value[0]}");
                        continue;
                    }
                }

                Console.WriteLine($"ticket \"" + tickets[i] + "\" - no match");
            }
        }
    }
}
