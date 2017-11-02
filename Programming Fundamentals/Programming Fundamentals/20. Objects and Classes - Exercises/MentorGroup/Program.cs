using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorGroup
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Student> students = ReadStudents(out input);
            ReadComments(students, out input);

            PrintStudents(students);
        }

        private static Dictionary<string, Student> ReadStudents(out string input)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
                        
            while (!(input = Console.ReadLine().Trim()).Equals("end of dates"))
            {
                string[] command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student
                {
                    Name = command[0],
                    Comments = new List<string>(),
                    Dates = new List<DateTime>()
                };

                if (command.Length > 1)
                {
                    student.Dates = command[1]
                                        .Split(',')
                                        .Select(s => DateTime.ParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                        .ToList();
                }

                if (!students.ContainsKey(command[0]))
                {
                    students.Add(command[0], student);
                }
                else
                {
                    students[command[0]].Dates.AddRange(student.Dates);
                }
            }

            return students;
        }

        private static void ReadComments(Dictionary<string, Student> students, out string input)
        {
            while (!(input = Console.ReadLine().Trim()).Equals("end of comments"))
            {
                string[] command = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string studentName = command[0];              

                if ((!students.ContainsKey(studentName)) || (command.Length <= 1))
                    continue;

                string comment = command[1];
                students[studentName].Comments.Add(comment);
            }
        }

        private static void PrintStudents(Dictionary<string, Student> students)
        {
             students = students
                            .OrderBy(s => s.Key)
                            .ToDictionary(s => s.Key, s => s.Value);

            foreach(KeyValuePair<string, Student> student in students)
            {
                Student studentInfo = student.Value;
                studentInfo.Dates.Sort();
                studentInfo.Dates.Distinct();

                Console.WriteLine($"{studentInfo.Name}");

                Console.WriteLine("Comments:");
                foreach(string comment in studentInfo.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");
                foreach (DateTime date in studentInfo.Dates)
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
                }
            }
        }
    }
}
