namespace _03.OldestFamilyMember
{
    using System;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family listOfPeople = new Family();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                listOfPeople.AddMember(new Person(name, age));
            }

            Person oldestmember = listOfPeople.GetOldestMember();
            Console.WriteLine($"{oldestmember.Name} {oldestmember.Age}");
        }
    }
}