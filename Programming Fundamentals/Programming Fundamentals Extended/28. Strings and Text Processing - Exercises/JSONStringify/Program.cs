using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONStringify
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = ReadStudents();
            PrintStudents(students);
        }

        private static List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();

            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("stringify"))
            {                
                students.Add(ReadStudent(input));
            }

            return students;
        }

        private static Student ReadStudent(string input)
        {
            string[] tokens = input.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
            string[] attr = tokens[1].Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            int age = Convert.ToInt32(attr[0].Trim());
            List<int> grades = new List<int>();

            if (attr.Length > 1)
            {
                grades = attr[1]
                             .Trim()
                             .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();
            }

            Student student = new Student
            {
                Name = name,
                Age = age,
                Grades = grades
            };

            return student;
        }

        private static void PrintStudents(List<Student> students)
        {
            StringBuilder output = new StringBuilder();
            output.Append("[");
            foreach (Student student in students)
            {
                if (output.Length > 1)
                    output.Append(",");

                output.Append("{name:\"" + student.Name + "\",age:" + student.Age + ",grades:[" + string.Join(", ", student.Grades) + "]}");               
            };
            output.Append("]");

            Console.WriteLine(output);
        }
    }
}
