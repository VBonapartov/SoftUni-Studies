namespace _03._Mankind
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Student student = GetStudent();
                Worker worker = GetWorker();

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static Student GetStudent()
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            string firstName = cmdArgs[0];
            string lastName = cmdArgs[1];
            string facultyNumber = cmdArgs[2];

            return new Student(firstName, lastName, facultyNumber);
        }

        private static Worker GetWorker()
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            string firstName = cmdArgs[0];
            string lastName = cmdArgs[1];
            decimal weekSalary = decimal.Parse(cmdArgs[2]);
            double workHoursPerDay = double.Parse(cmdArgs[3]);

            return new Worker(firstName, lastName, weekSalary, workHoursPerDay);
        }
    }
}
