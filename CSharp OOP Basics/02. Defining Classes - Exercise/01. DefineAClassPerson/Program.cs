namespace _01.DefineAClassPerson
{
    using System;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Pesho";
            person1.Age = 20;

            Person person2 = new Person("Gosho", 18);
            Person person3 = new Person("Stamat", 43);

            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}
