namespace _04.OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                listOfPeople.Add(new Person(name, age));
            }

            PrintAllPeoplesOlderThan30(listOfPeople);
        }

        private static void PrintAllPeoplesOlderThan30(List<Person> listOfPeople)
        {
            foreach (Person person in listOfPeople.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}