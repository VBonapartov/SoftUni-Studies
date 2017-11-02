using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrades
        {
            get
            {
                return Grades.Average();
            }
        }       
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();
            for(int i = 0; i < numberOfStudents; i++)      
                listOfStudents.Add(ReadStudent());

            PrintStudents(listOfStudents);
        }

        static private Student ReadStudent()
        {
            string input = Console.ReadLine().Trim();

            int idxFirstSpace = input.IndexOf(' ');
            string[] gradesStr = input.Substring(idxFirstSpace).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Student student = new Student
            {
                Name = input.Substring(0, idxFirstSpace),
                Grades = gradesStr.Select(s => double.Parse(s)).ToList()
            };

            return student;
        }

        static private void PrintStudents(List<Student> listOfStudents)
        {
            List<string> studentsForPrint = listOfStudents
                                                .Where(s => s.AverageGrades >= 5)
                                                .OrderBy(s => s.Name)
                                                .ThenByDescending(s => s.AverageGrades)
                                                .Select(s => s.Name + " -> " + string.Format($"{s.AverageGrades:F2}"))
                                                .ToList();

            Console.WriteLine($"{string.Join(Environment.NewLine, studentsForPrint)}");
        }
    }
}
