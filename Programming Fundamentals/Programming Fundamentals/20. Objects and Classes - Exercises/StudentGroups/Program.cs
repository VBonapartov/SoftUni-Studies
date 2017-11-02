using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate  { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public string Town { get; set; }
        public List<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();
   
            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("End"))
            {
                if (input.IndexOf("=>") != -1)
                {
                    towns.Add(ReadTown(input));
                }
                else
                {
                    Student student = ReadStudent(input);
                    towns[towns.Count - 1].Students.Add(student);                    
                }
            }

            List<Group> groups = CalculateGroups(towns);
            PrintGroups(groups);
        }

        private static Town ReadTown(string input)
        {
            string[] line = input.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
            string townName = line[0];
            int seats = int.Parse(line[1].Split(' ')[0]);
            
            Town town = new Town
            {
                Name = townName,
                Seats = seats,
                Students = new List<Student>()
            };
            
            return town;
        }

        private static Student ReadStudent(string input)
        {
            string[] line = input.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            string studentname = line[0].Trim();
            string email = line[1].Trim();
            DateTime registrationDate = DateTime.ParseExact(line[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

            Student student = new Student
            {
                Name = studentname,
                Email = email,
                RegistrationDate = registrationDate
            };

            return student;
        }

        private static List<Group> CalculateGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();
            
            foreach(Town town in towns)
            {
                List<Student> sortedStudents = town.Students
                                                        .OrderBy(s => s.RegistrationDate)
                                                        .ThenBy(s => s.Name)
                                                        .ThenBy(s => s.Email)
                                                        .ToList();

                int numberOfSeats = town.Seats;
                int numberOfGroups = (int)Math.Ceiling(town.Students.Count / (double)town.Seats);
                for (int currentGroup = 0; currentGroup < numberOfGroups; currentGroup++)
                {
                    Group group = new Group
                    {
                        Town = town.Name,
                        Students = sortedStudents
                                        .Skip(currentGroup * numberOfSeats)
                                        .Take(numberOfSeats)
                                        .Select(s => s)
                                        .ToList()
                    };

                    groups.Add(group);
                }
            }
            
            return groups;
        }

        private static void PrintGroups(List<Group> groups)
        {
            int numberOfGroups = groups.Count;
            int numberOfTowns = groups.Select(g => g.Town).Distinct().Count();
                        
            List<string> studentsGroups = groups
                                            .OrderBy(g => g.Town)
                                            .Select(g =>    g.Town + 
                                                            " => " + 
                                                            string.Join(", ", g.Students
                                                                                   .Select(s => s.Email)
                                                                                   .ToList()
                                                                       )
                                                   ).ToList();

            Console.WriteLine($"Created {numberOfGroups} groups in {numberOfTowns} towns:");
            Console.WriteLine(string.Join(Environment.NewLine, studentsGroups));
        }
    }
}
