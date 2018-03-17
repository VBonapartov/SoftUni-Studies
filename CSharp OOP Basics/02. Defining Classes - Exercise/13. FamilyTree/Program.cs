namespace _13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<string> peopleInfo = new List<string>();
        private static List<string> relationships = new List<string>();

        static void Main(string[] args)
        {
            string searchedPersonParam = Console.ReadLine();

            ReadTreeInfo();
            List<Person> people = GetAllPeople();
            SaveParentsAndChildren(people);

            PrintPersonInfo(people, searchedPersonParam);
        }

        private static void ReadTreeInfo()
        {
            string input = string.Empty; ;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                if (input.Contains(" - "))
                {
                    relationships.Add(input);
                }
                else
                {
                    peopleInfo.Add(input);
                }
            }
        }

        private static List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleInfo.Count; i++)
            {
                string[] tokens = peopleInfo[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0] + " " + tokens[1];
                string birthday = tokens[2];

                people.Add(new Person(name, birthday));
            }

            return people;
        }

        private static void SaveParentsAndChildren(List<Person> people)
        {
            for (int j = 0; j < relationships.Count; j++)
            {
                Person parent = null;
                Person child = null;

                string[] tokens = relationships[j]
                                    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim())
                                    .ToArray();

                if (Char.IsDigit(tokens[0][0]))
                {
                    parent = people.First(p => p.Birthday.Equals(tokens[0]));
                }
                else
                {
                    parent = people.First(p => p.Name.Equals(tokens[0]));
                }

                if (Char.IsDigit(tokens[1][0]))
                {
                    child = people.First(p => p.Birthday.Equals(tokens[1]));
                }
                else
                {
                    child = people.First(p => p.Name.Equals(tokens[1]));
                }

                parent.AddChild(child);
                child.AddParent(parent);
            }
        }

        private static void PrintPersonInfo(List<Person> people, string searchedPersonParam)
        {
            Person target = null;

            if (Char.IsDigit(searchedPersonParam[0]))
            {
                target = people.First(p => p.Birthday.Equals(searchedPersonParam));
            }
            else
            {
                target = people.First(p => p.Name.Equals(searchedPersonParam));
            }

            Console.WriteLine(target);
        }
    }
}