namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<Person> persons = new List<Person>();

        static void Main(string[] args)
        {
            GetPersonsInformation();
            PrintInformationForPerson(Console.ReadLine());
        }

        private static void GetPersonsInformation()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string command = cmdArgs[1];

                switch (command)
                {
                    case "company":
                        AddCompany(cmdArgs);
                        break;

                    case "pokemon":
                        AddPokemon(cmdArgs);
                        break;

                    case "parents":
                        AddParent(cmdArgs);
                        break;

                    case "children":
                        AddChildren(cmdArgs);
                        break;

                    case "car":
                        AddCar(cmdArgs);
                        break;
                }
            }
        }

        private static void AddCompany(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            string companyName = cmdArgs[2];
            string department = cmdArgs[3];
            decimal salary = decimal.Parse(cmdArgs[4]);

            Company company = new Company(companyName, department, salary);
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
            {
                person = new Person(name, company);
                persons.Add(person);
            }
            else
            {
                person.Company = company;
            }
        }

        private static void AddPokemon(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            string pokemonName = cmdArgs[2];
            string pokemonType = cmdArgs[3];

            Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
            {
                person = new Person(name, pokemon);
                persons.Add(person);
            }
            else
            {
                person.Pokemons.Add(pokemon);
            }
        }

        private static void AddParent(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            string parentName = cmdArgs[2];
            string parentBirthday = cmdArgs[3];

            Parent parent = new Parent(parentName, parentBirthday);
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
            {
                person = new Person(name, parent);
                persons.Add(person);
            }
            else
            {
                person.Parents.Add(parent);
            }
        }

        private static void AddChildren(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            string childName = cmdArgs[2];
            string childBirthday = cmdArgs[3];

            Child child = new Child(childName, childBirthday);
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
            {
                person = new Person(name, child);
                persons.Add(person);
            }
            else
            {
                person.Children.Add(child);
            }
        }

        private static void AddCar(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            string carModel = cmdArgs[2];
            int carSpeed = int.Parse(cmdArgs[3]);

            Car car = new Car(carModel, carSpeed);
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
            {
                person = new Person(name, car);
                persons.Add(person);
            }
            else
            {
                person.Car = car;
            }
        }

        private static void PrintInformationForPerson(string name)
        {
            Person person = persons.Where(p => p.Name.Equals(name)).FirstOrDefault();

            if (person == null)
                return;

            Console.WriteLine(person);
        }
    }
}