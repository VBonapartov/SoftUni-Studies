using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> blacklistedWords = Console.ReadLine().Trim().Split(' ').ToList();

            List<string> result = new List<string>();
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                bool IgnoreTrack = false;
                foreach (string blacklistedWord in blacklistedWords)
                {
                    if(input.Contains(blacklistedWord))
                    {
                        IgnoreTrack = true;
                        break;
                    }
                }

                if(!IgnoreTrack)
                {
                    result.Add(input);
                }
            }

            result.Sort();
            foreach (string track in result)
                Console.WriteLine(track);
        }
    }
}
