using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUnit
{
    class Method
    {
        public string Name { get; set; }
        public List<string> UnitTests { get; set; }

        public int GetNumberOfTests()
        {
            return UnitTests.Count();
        }
    }

    class Class
    {
        public string Name { get; set; }
        public List<Method> Methods { get; set; }

        public override string ToString()
        {
            List<Method> sortedMethods = this.Methods
                                                    .OrderByDescending(m => m.GetNumberOfTests())
                                                    .ThenBy(m => m.Name)
                                                    .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.Name}:");
            foreach(Method method in sortedMethods)
            {
                if (sb.Length > 0)
                    sb.Append(Environment.NewLine);

                sb.AppendFormat($"##{method.Name}");              

                foreach(string unitTest in method.UnitTests.OrderBy(u => u.Length).ThenBy(u => u))
                {
                    if (sb.Length > 0)
                        sb.Append(Environment.NewLine);

                    sb.AppendFormat($"####{unitTest}");
                }
            }

            return sb.ToString();
        }

        public int GetNumberOfMethods()
        {
            return Methods.Count();
        }

        public int GetTotalNumberOfTests()
        {
            return Methods.Sum(m => m.GetNumberOfTests());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 90/ 100

            List<Class> classes = ReadClasses();
            PrintClasses(classes);
        }

        private static List<Class> ReadClasses()
        {
            List<Class> classes = new List<Class>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("It's testing time!"))
            {
                string[] commandArgs = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                string className = string.Empty;
                string methodName = string.Empty;
                string unitTestName = string.Empty;

                if (!ValidateParameters(commandArgs, out className, out methodName, out unitTestName))
                    continue;

                if (!classes.Exists(c => c.Name.Equals(className)))
                {
                    Class newClass = new Class
                    {
                        Name = className,
                        Methods = new List<Method> { }
                    };

                    classes.Add(newClass);
                }

                Class currentClass = classes.Where(c => c.Name.Equals(className)).First();
                if(!currentClass.Methods.Exists(m => m.Name.Equals(methodName)))
                {
                    Method newMethod = new Method
                    {
                        Name = methodName,
                        UnitTests = new List<string> { unitTestName }
                    };

                    currentClass.Methods.Add(newMethod);
                }
                else
                {
                    Method currentMethod = currentClass.Methods.Where(m => m.Name.Equals(methodName)).First();
                    if (!currentMethod.UnitTests.Contains(unitTestName))
                    {
                        currentMethod.UnitTests.Add(unitTestName);
                    }
                }
            }

            return classes;
        }

        private static bool ValidateParameters(string[] commandArgs, out string className, out string methodName, out string unitTestName)
        {
            className = string.Empty;
            methodName = string.Empty;
            unitTestName = string.Empty;

            if (commandArgs.Length != 3)
                return false;
             
            className = commandArgs[0];
            methodName = commandArgs[1];
            unitTestName = commandArgs[2];

            string pattern = @"^[A-Z][A-Za-z0-9]+$";
            bool isValidClassName = Regex.IsMatch(className, pattern);
            bool isValidMethodName = Regex.IsMatch(methodName, pattern);
            bool isValidUnitTestName = Regex.IsMatch(unitTestName, pattern);

            return (isValidClassName && isValidMethodName && isValidUnitTestName);
        }

        private static void PrintClasses(List<Class> classes)
        {
            //List<Class> sortedClasses = classes
            //                                .OrderByDescending(c => c.Methods.Sum(m => m.UnitTests.Count))
            //                                .ThenBy(c => c.Methods.Count)
            //                                .ThenBy(c => c.Name)
            //                                .ToList();

            List<Class> sortedClasses = classes
                                .OrderByDescending(c => c.GetTotalNumberOfTests())
                                .ThenBy(c => c.GetNumberOfMethods())
                                .ThenBy(c => c.Name)
                                .ToList();

            foreach (Class currentClass in sortedClasses)
            {
                Console.WriteLine(currentClass);
            }
        }
    }
}
