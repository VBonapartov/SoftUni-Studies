using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<string, HashSet<string>>> events = new Dictionary<int, Dictionary<string, HashSet<string>>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Time for Code"))
            {
                string[] eventArgs = input
                                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => s.Trim())
                                        .ToArray();

                bool isValidEventArgs = CheckEventArgs(eventArgs);
                if (!isValidEventArgs)
                    continue;

                int id = Convert.ToInt32(eventArgs[0]);
                string eventName = eventArgs[1];
                List<string> participants = eventArgs.Where((s, index) => index > 1).ToList();

                if (!events.ContainsKey(id))
                {
                    events.Add(id,
                                new Dictionary<string, HashSet<string>>
                                {
                                    { eventName, new HashSet<string>{} }
                                }
                               );
                }

                if (events[id].ContainsKey(eventName))
                    events[id][eventName].UnionWith(participants);
            }

            PrintEvents(events);
        }

        private static bool CheckEventArgs(string[] eventArgs)
        {
            if (eventArgs.Length < 2)
                return false;

            if (!eventArgs[1][0].ToString().Equals("#"))
                return false;

            for(int i = 2; i < eventArgs.Length; i++)
            {
                if (!eventArgs[i][0].ToString().Equals("@"))
                    return false;
            }

            return true;
        }

        private static void PrintEvents(Dictionary<int, Dictionary<string, HashSet<string>>> events)
        {
            Dictionary<int, Dictionary<string, HashSet<string>>> sortedEvents = events
                                                                                    .OrderByDescending(e => e.Value.Values.Sum(p => p.Count))
                                                                                    .ThenBy(e => e.Key)
                                                                                    .ToDictionary(e => e.Key, e => e.Value);

            foreach(KeyValuePair<int, Dictionary<string, HashSet<string>>> eventInfo in sortedEvents)
            {
                foreach (KeyValuePair<string, HashSet<string>> ev in eventInfo.Value)
                {
                    int numberOfParticipants = ev.Value.Count();
                    Console.WriteLine($"{ev.Key.Substring(1)} - {numberOfParticipants}");

                    if (numberOfParticipants > 0)
                    {
                        List<string> sortedParticipants = ev.Value.OrderBy(e => e).ToList();
                        Console.WriteLine(string.Join(Environment.NewLine, sortedParticipants));
                    }
                }
            }
        }
    }
}
