using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParse
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
            string json = Console.ReadLine().Trim();

            List<Student> students = JSONParse(json);
            PrintStudents(students);
        }

        private static List<Student> JSONParse(string json)
        {
            List<Student> students = new List<Student>();

            json = json.Substring(1, json.Length - 2);

            int index = 0;
            while ((index = json.IndexOf("}")) != -1)
            {
                string studentsInfo = json.Substring(0, index + 1);            
                students.Add(ParseStudent(studentsInfo));

                json = json.Substring(index + 1).Trim(',');
            }
            
            return students;
        }

        private static Student ParseStudent(string studentInfo)
        {
            string name = string.Empty;
            int age = 0;
            List<int> grades = new List<int>();

            studentInfo = studentInfo.Substring(1, studentInfo.Length - 2);
            studentInfo = studentInfo.Replace("name:", ""); 
            studentInfo = studentInfo.Replace("age:", "");
            studentInfo = studentInfo.Replace("grades:", "");

            string[] attr = studentInfo.Split('[');
            attr[0] = attr[0].Trim(',');
            attr[1] = attr[1].Trim(']');

            string[] nameAndAge = attr[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            name = nameAndAge[0].Trim('"');
            age = Convert.ToInt32(nameAndAge[1]);

            if (attr[1].Length > 0)
            {
                grades = attr[1]
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
            foreach(Student student in students)
            {
                string grades = "None";
                if (student.Grades.Count > 0)
                    grades = string.Join(", ", student.Grades);

                Console.WriteLine($"{student.Name} : {student.Age} -> {grades}");
            }
        }
    }
}
