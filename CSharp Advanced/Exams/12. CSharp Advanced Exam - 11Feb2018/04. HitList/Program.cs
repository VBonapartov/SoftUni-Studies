namespace _04._HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static int targetInfoIndex;

        static void Main(string[] args)
        {
            targetInfoIndex = int.Parse(Console.ReadLine());
            List<Person> persons = ReadInputData();
            PrintInfoByPerson(persons);
        }

        private static List<Person> ReadInputData()
        {
            List<Person> persons = new List<Person>();

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("end transmissions"))
            {
                string[] cmdArgs = input.Split('=');
                string[] keyValueInfo = cmdArgs[1].Split(';');

                string name = cmdArgs[0];
                Person person = persons.FirstOrDefault(p => p.Name.Equals(name));

                if (person == null)
                {
                    person = new Person(name, targetInfoIndex);
                    persons.Add(person);
                }

                foreach (string keyValuePair in keyValueInfo)
                {
                    string[] keyValue = keyValuePair.Split(':');
                    person.AddKeyValuePair(keyValue[0], keyValue[1]);
                }
            }

            return persons;
        }

        private static void PrintInfoByPerson(List<Person> persons)
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            string name = cmdArgs[1];

            Person person = persons.FirstOrDefault(p => p.Name.Equals(name));

            if (person != null)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        private int targetInfoIndex;
        private List<string[]> keyValuePairs;

        public Person(string name, int targetInfoIndex)
        {
            this.Name = name;
            this.targetInfoIndex = targetInfoIndex;
            this.keyValuePairs = new List<string[]>();
        }

        public string Name { get; private set; }

        public void AddKeyValuePair(string key, string value)
        {
            string[] keyValuePair = this.keyValuePairs.FirstOrDefault(kv => kv[0].Equals(key));

            if (keyValuePair != null)
            {
                keyValuePair[1] = value;
                return;
            }

            this.keyValuePairs.Add(new string[] { key, value });
        }

        private int CalculateInfoIndex()
        {
            return this.keyValuePairs.Select(p => p[0].Length).Sum() + this.keyValuePairs.Select(p => p[1].Length).Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Info on {this.Name}:");

            foreach (string[] keyValue in this.keyValuePairs.OrderBy(p => p[0]))
            {
                sb.AppendLine($"---{keyValue[0]}: {keyValue[1]}");
            }

            int infoIndex = this.CalculateInfoIndex();
            sb.AppendLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                sb.Append("Proceed");
            }
            else
            {
                sb.AppendLine($"Need {targetInfoIndex - infoIndex} more info.");
            }

            return sb.ToString().Trim();
        }
    }
}
