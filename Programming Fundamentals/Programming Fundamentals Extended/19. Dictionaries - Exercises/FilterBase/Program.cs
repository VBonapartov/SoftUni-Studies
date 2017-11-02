using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> employeeAge = new Dictionary<string, int>();
            Dictionary<string, double> employeeSalary = new Dictionary<string, double>();
            Dictionary<string, string> employeePosition = new Dictionary<string, string>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("filter base"))
            {
                string[] employeeInfo = input.Split(' ');

                int age = 0;
                double salary = 0.00d;

                if(int.TryParse(employeeInfo[2], out age))
                {
                    employeeAge.Add(employeeInfo[0], age);
                }
                else if(double.TryParse(employeeInfo[2], out salary))
                {
                    employeeSalary.Add(employeeInfo[0], salary);
                }
                else
                {
                    employeePosition.Add(employeeInfo[0], employeeInfo[2]);
                }
            }

            input = Console.ReadLine();
            switch(input)
            {
                case "Age":
                    PrintNameAndAge(employeeAge);
                    break;
                    
                case "Salary":
                    PrintNameAndSalary(employeeSalary);
                    break;

                case "Position":
                    PrintNameAndPosition(employeePosition);
                    break;
            }
        }

        static private void PrintNameAndAge(Dictionary<string, int> employeeAge)
        {
            foreach (KeyValuePair<string, int> employee in employeeAge)
            {
                Console.WriteLine($"Name: {employee.Key}");
                Console.WriteLine($"Age: {employee.Value}");
                Console.WriteLine("====================");
            }
        }

        static private void PrintNameAndSalary(Dictionary<string, double> employeeSalary)
        {
            foreach (KeyValuePair<string, double> employee in employeeSalary)
            {
                Console.WriteLine($"Name: {employee.Key}");
                Console.WriteLine($"Salary: {employee.Value:F2}");
                Console.WriteLine("====================");
            }
        }

        static private void PrintNameAndPosition(Dictionary<string, string> employeePosition)
        {
            foreach (KeyValuePair<string, string> employee in employeePosition)
            {
                Console.WriteLine($"Name: {employee.Key}");
                Console.WriteLine($"Position: {employee.Value}");
                Console.WriteLine("====================");
            }
        }
    }
}
