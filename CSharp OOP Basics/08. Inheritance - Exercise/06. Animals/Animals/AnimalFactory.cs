namespace _06._Animals.Animals
{
    using System;    
    using System.Linq;
    using System.Reflection;

    public class AnimalFactory
    {
        public static Animal GetAnimal(string animalKind, string name, int age, string gender)
        {
            object[] parametersForConstruction = new object[] { name, age, gender };

            Type typeOfCommand = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(type => type.Name.Equals(animalKind));

            if (typeOfCommand == null)
            {
                throw new ArgumentException("Invalid input!");
            }

            Animal animal = (Animal)Activator.CreateInstance(typeOfCommand, parametersForConstruction);
            return animal;
        }
    }
}
