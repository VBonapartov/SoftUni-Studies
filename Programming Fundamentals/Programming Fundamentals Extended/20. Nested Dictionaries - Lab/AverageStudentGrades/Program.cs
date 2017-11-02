using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for(int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');
                string name = input[0];
                double grade = double.Parse(input[1]);

                if(students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>() { grade });
                }
            }

            foreach(KeyValuePair<string, List<double>> student in students)
            {
                StringBuilder grades = new StringBuilder();
                for(int i = 0; i < student.Value.Count; i++)
                {
                    grades.AppendFormat($"{student.Value[i]:F2} ");
                }

                Console.WriteLine($"{student.Key} -> {grades}(avg: {student.Value.Average():F2})");
            }
        }
    }
}
