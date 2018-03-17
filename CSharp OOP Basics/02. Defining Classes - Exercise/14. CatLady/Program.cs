namespace _14.CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = GetCats();
            string catName = Console.ReadLine();
            PrintCatInfo(cats, catName);
        }

        private static List<Cat> GetCats()
        {
            List<Cat> cats = new List<Cat>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                switch (cmdArgs[0])
                {
                    case "Siamese":
                        cats.Add(new Siamese(cmdArgs[1], int.Parse(cmdArgs[2])));
                        break;

                    case "Cymric":
                        cats.Add(new Cymric(cmdArgs[1], double.Parse(cmdArgs[2])));
                        break;

                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(cmdArgs[1], int.Parse(cmdArgs[2])));
                        break;
                }
            }

            return cats;
        }

        private static void PrintCatInfo(List<Cat> cats, string catName)
        {
            Cat cat = cats.FirstOrDefault(c => c.Name.Equals(catName));
            Console.WriteLine(cat);
        }
    }
}