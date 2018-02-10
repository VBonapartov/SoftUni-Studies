namespace _04.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> events = GetAllEvents();
            List<Event> validEvents = GetValidEvents(events);
            PrintEvents(validEvents);
        }

        private static List<string> GetAllEvents()
        {
            List<string> events = new List<string>();

            int numberOfEvents = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfEvents; i++)
            {
                events.Add(Console.ReadLine());
            }

            return events;
        }

        private static List<Event> GetValidEvents(List<string> events)
        {
            List<Event> validEvents = new List<Event>();

            string validEventPattern = @"^#(?<person>[a-zA-Z]+):\s*@(?<location>[a-zA-Z]+)\s*(?<hours>\d{1,2}):(?<minutes>\d{1,2})$";

            foreach(string @event in events)
            {
                Match eventMatch = Regex.Match(@event, validEventPattern);

                if(!eventMatch.Success)
                {
                    continue;
                }

                string personName = eventMatch.Groups["person"].Value;
                string location = eventMatch.Groups["location"].Value;
                int hours = int.Parse(eventMatch.Groups["hours"].Value);
                int minutes = int.Parse(eventMatch.Groups["minutes"].Value);

                if(hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                {
                    continue;
                }

                string time = eventMatch.Groups["hours"].Value + ":" + eventMatch.Groups["minutes"].Value;

                Event currentEvent = validEvents.FirstOrDefault(e => e.Location.Equals(location));

                if(currentEvent == null)
                {
                    currentEvent = new Event(location);
                    validEvents.Add(currentEvent);
                }

                currentEvent.AddPerson(personName, time);
            }

            return validEvents;
        }

        private static void PrintEvents(List<Event> validEvents)
        {
            List<string> filters = Console.ReadLine().Split(',').OrderBy(n => n).ToList();

            foreach(string filter in filters)
            {
                Event @event = validEvents.FirstOrDefault(e => e.Location.Equals(filter));

                if (@event == null) continue;

                Console.WriteLine(@event);
            }
        }
    }
}
