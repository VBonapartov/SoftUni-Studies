namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listOfEmployees = ReadEmployeeData();
            PrintHighestAverageSalaryDepartment(listOfEmployees);
        }

        private static List<Employee> ReadEmployeeData()
        {
            List<Employee> listOfEmployees = new List<Employee>();

            int numberOfEmployees = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string name = cmdArgs[0];
                decimal salary = decimal.Parse(cmdArgs[1]);
                string position = cmdArgs[2];
                string department = cmdArgs[3];

                string email = string.Empty;
                int age = 0;
                if (cmdArgs.Length == 6)
                {
                    email = cmdArgs[4];
                    age = int.Parse(cmdArgs[5]);

                    listOfEmployees.Add(new Employee(name, salary, position, department, email, age));
                }
                else if (cmdArgs.Length == 5)
                {
                    if (int.TryParse(cmdArgs[4], out age))
                    {
                        listOfEmployees.Add(new Employee(name, salary, position, department, age));
                    }
                    else
                    {
                        listOfEmployees.Add(new Employee(name, salary, position, department, cmdArgs[4]));
                    }
                }
                else
                {
                    listOfEmployees.Add(new Employee(name, salary, position, department));
                }
            }

            return listOfEmployees;
        }

        private static void PrintHighestAverageSalaryDepartment(List<Employee> listOfEmployees)
        {
            string highestAverageSalaryDept = listOfEmployees
                                                .Select(e => e.Department)
                                                .OrderByDescending(d => listOfEmployees.Where(empl => empl.Department.Equals(d)).Average(empl => empl.Salary))
                                                .First();

            List<Employee> employeesInDept = listOfEmployees
                                                .Where(d => d.Department.Equals(highestAverageSalaryDept))
                                                .OrderByDescending(d => d.Salary)
                                                .ToList();

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDept}");
            foreach (Employee employee in employeesInDept)
            {
                Console.WriteLine(employee);
            }
        }
    }
}