using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camping
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> rvs = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string nameOfThePerson = command[0];
                string camperModel = command[1];
                int timeToStay = int.Parse(command[2]);

                if(rvs.ContainsKey(nameOfThePerson))
                {
                    if(!rvs[nameOfThePerson].ContainsKey(camperModel))
                    {
                        rvs[nameOfThePerson].Add(camperModel, timeToStay);
                    }
                }
                else
                {
                    rvs.Add(nameOfThePerson,
                            new Dictionary<string, int>
                            {
                                { camperModel, timeToStay }
                            }
                           );
                }
            }

            rvs = rvs
                    .OrderByDescending(s => s.Value.Count())
                    .ThenBy(s => s.Key.Length)
                    .ToDictionary(s => s.Key, s => s.Value);

            foreach(KeyValuePair<string, Dictionary<string, int>> person in rvs)
            {
                int countOfCampers = person.Value.Count();
                Console.WriteLine($"{person.Key}: {countOfCampers}");

                foreach(KeyValuePair<string, int> van in person.Value)
                {
                    Console.WriteLine($"***{van.Key}");
                }

                int countOfNights = person.Value.Select(s => s.Value).ToList().Sum();
                Console.WriteLine($"Total stay: {countOfNights} nights");
            }

   
        }
    }
}
