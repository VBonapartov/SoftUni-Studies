using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = ReadPersons();
            PrintPersons(persons);
        }

        private static List<Person> ReadPersons()
        {
            List<Person> persons = new List<Person>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("End"))
            {
                string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string personName = command[0];
                string personID = command[1];
                int personAge = int.Parse(command[2]);

                Person person = new Person
                {
                    Name = personName,
                    ID = personID,
                    Age = personAge
                };

                persons.Add(person);
            }

            return persons;
        }

        private static void PrintPersons(List<Person> persons)
        {
            persons = persons.OrderBy(p => p.Age).ToList();

            foreach(Person person in persons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
