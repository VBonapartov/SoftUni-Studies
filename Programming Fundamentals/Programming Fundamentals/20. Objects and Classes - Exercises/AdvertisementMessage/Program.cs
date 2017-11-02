using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] 
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };


            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            for (int i = 1; i <= n; i++)
            {
                int phrasesIdx = rnd.Next(phrases.Length);
                int eventsIdx = rnd.Next(events.Length);
                int authorsIdx = rnd.Next(authors.Length);
                int citiesIdx = rnd.Next(cities.Length);

                Console.WriteLine($"{phrases[phrasesIdx]} {events[eventsIdx]} {authors[authorsIdx]} – {cities[citiesIdx]}.");
            }                                     
        }
    }
}
