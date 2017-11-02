using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Venue : {Singer : TotalMoney}
            Dictionary<string, Dictionary<string, long>> concertsInfo = new Dictionary<string, Dictionary<string, long>>();
            
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                if (!IsValidInput(input))
                    continue;

                (string singer, string venue, long totalMoney) = GetInfoFromInput(input);

                if (concertsInfo.ContainsKey(venue))
                {
                    if (concertsInfo[venue].ContainsKey(singer))
                    {
                        concertsInfo[venue][singer] += totalMoney;
                    }
                    else
                    {
                        concertsInfo[venue].Add(singer, totalMoney);
                    }
                }
                else
                {
                    concertsInfo.Add(venue, new Dictionary<string, long>() { { singer, totalMoney } });
                }
            }

            PrintConcertsInfo(concertsInfo);
        }

        static private bool IsValidInput(string input)
        {
            // Check for symbol '@'
            int indexAt = input.IndexOf('@');
            if (indexAt == -1)
                return false;

            // Before '@' -> ' '(spaces)
            if (!char.IsWhiteSpace(input[indexAt - 1]))
                return false;

            // Number of speces after '@' - from 3 to 7
            int countSpaces = input.Count(Char.IsWhiteSpace);
            if (countSpaces < 3 || countSpaces > 7)
                return false;

            string strAfterAt = input.Substring(indexAt + 1);
            string[] info = strAfterAt.Split(' ');
            int elementsInInfo = info.Length;

            // Check last two numbers - ticketsPrice and ticketsCount
            int result = 0;
            bool isTicketsPrice = int.TryParse(info[elementsInInfo - 1], out result);
            bool isTicketsCount = int.TryParse(info[elementsInInfo - 2], out result);
            if (!isTicketsPrice || !isTicketsCount)
                return false;

            return true;
        }

        static private (string singer, string venue, long totalMoney) GetInfoFromInput(string input)
        {
            int indexAt = input.IndexOf('@');
            string strAfterAt = input.Substring(indexAt + 1);            
            string[] info = strAfterAt.Split(' ');

            string singer = input.Substring(0, indexAt - 1);
            string venue = string.Empty;
            int ticketsPrice = 0;
            int ticketsCount = 0;

            // spaces are 2, 3 or 4 after @
            int countSpaces = strAfterAt.Count(Char.IsWhiteSpace);
            if (countSpaces == 2)
            {     
                venue = info[0];
                ticketsPrice = Convert.ToInt32(info[1]);
                ticketsCount = Convert.ToInt32(info[2]);
            }
            else if(countSpaces == 3)
            {
                venue = info[0] + " " + info[1];
                ticketsPrice = Convert.ToInt32(info[2]);
                ticketsCount = Convert.ToInt32(info[3]);                
            }
            else
            {
                venue = info[0] + " " + info[1] + " " + info[2];
                ticketsPrice = Convert.ToInt32(info[3]);
                ticketsCount = Convert.ToInt32(info[4]);
            }

            int totalMoney = ticketsPrice * ticketsCount;

            return (singer, venue, totalMoney);
        }

        static private void PrintConcertsInfo(Dictionary<string, Dictionary<string, long>> concertsInfo)
        {
            foreach(KeyValuePair<string, Dictionary<string, long>> concert in concertsInfo)
            {
                Console.WriteLine(concert.Key);
                PrintSingers(concert.Value);
            }
        }

        static private void PrintSingers(Dictionary<string, long> singersInfo)
        {
            while (singersInfo.Count > 0)
            {
                KeyValuePair<string, long> currentSingerInfo = singersInfo.ElementAt(0);

                string singer = currentSingerInfo.Key;
                long totalMoney = currentSingerInfo.Value;

                for (int p = 0; p < singersInfo.Count; p++)
                {
                    KeyValuePair<string, long> singerInfo = singersInfo.ElementAt(p);
                    if (singerInfo.Value > totalMoney)
                    {
                        singer = singerInfo.Key;
                        totalMoney = singerInfo.Value;
                    }
                }

                singersInfo.Remove(singer);
                Console.WriteLine($"#  {singer} -> {totalMoney}");
            }
        }
    }
}
