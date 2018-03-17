namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<string> people = new List<string>();
        private static List<string> relationships = new List<string>();

        public static void Main(string[] args)
        {
            string searchedPerson = Console.ReadLine();

            ReadFamilyTree();
            List<Person> allPeople = GetAllPeople();
            SaveParentsAndChildren(allPeople);

            PrintPersonInfo(allPeople, searchedPerson);
        }

        private static void ReadFamilyTree()
        {
            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("End"))
            {
                if (input.Contains(" - "))
                {
                    relationships.Add(input);
                }
                else
                {
                    people.Add(input);
                }
            }
        }

        private static List<Person> GetAllPeople()
        {
            List<Person> allPeople = new List<Person>();

            for (int i = 0; i < people.Count; i++)
            {
                string[] tokens = people[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0] + " " + tokens[1];
                string birthday = tokens[2];

                allPeople.Add(new Person(name, birthday));
            }

            return allPeople;
        }

        private static void SaveParentsAndChildren(List<Person> allPeople)
        {
            for (int j = 0; j < relationships.Count; j++)
            {
                string[] tokens = relationships[j]
                                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim())
                                    .ToArray();

                Person parent = char.IsDigit(tokens[0][0])
                         ? allPeople.First(p => p.Birthday.Equals(tokens[0]))
                         : allPeople.First(p => p.Name.Equals(tokens[0]));

                Person child = char.IsDigit(tokens[1][0])
                        ? allPeople.First(p => p.Birthday.Equals(tokens[1]))
                        : allPeople.First(p => p.Name.Equals(tokens[1]));

                parent.AddChild(child);
                child.AddParent(parent);
            }
        }

        private static void PrintPersonInfo(List<Person> allPeople, string searchedPerson)
        {
            Person target = char.IsDigit(searchedPerson[0])
                            ? allPeople.First(p => p.Birthday.Equals(searchedPerson))
                            : allPeople.First(p => p.Name.Equals(searchedPerson));

            Console.WriteLine(target);
        }
    }
}
