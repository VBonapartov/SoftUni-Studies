namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<Department> departments;
        private static List<Doctor> doctors;

        static void Main(string[] args)
        {
            ReadInput();
            PrintInfo();
        }

        private static void ReadInput()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Output"))
            {
                string[] cmdArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = cmdArgs[0];
                string doctor = cmdArgs[1] + " " + cmdArgs[2];
                string patient = cmdArgs[3];

                Department currentDepartment = departments.Where(d => d.Name.Equals(department)).FirstOrDefault();

                if (currentDepartment == null)
                {
                    currentDepartment = new Department(department);
                    departments.Add(currentDepartment);
                }

                if(currentDepartment.AddPatient(patient))
                {
                    Doctor currentDoctor = doctors.Where(d => d.Name.Equals(doctor)).FirstOrDefault();

                    if (currentDoctor == null)
                    {
                        currentDoctor = new Doctor(doctor);
                        doctors.Add(currentDoctor);
                    }
                    
                    currentDoctor.AddPatient(patient);
                }
            }
        }

        private static void PrintInfo()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length < 1 || cmdArgs.Length > 2)
                    continue;

                // Department
                if(cmdArgs.Length == 1)
                {
                    string department = cmdArgs[0];

                    Department currentDepartment = departments.Where(d => d.Name.Equals(department)).FirstOrDefault();

                    if (currentDepartment != null)
                    {                        
                        Console.WriteLine(string.Join(Environment.NewLine, currentDepartment.GetAllPatients()));
                    }  
                }
                // Department Room
                else if (Char.IsDigit(cmdArgs[1][0]))
                {
                    string department = cmdArgs[0];
                    int room = int.Parse(cmdArgs[1]);

                    Department currentDepartment = departments.Where(d => d.Name.Equals(department)).FirstOrDefault();

                    if (currentDepartment != null)
                    {                        
                        Console.WriteLine(string.Join(Environment.NewLine, currentDepartment.GetPatientsInRoom(room)));
                    }
                }
                // Doctor
                else
                {
                    string doctor = cmdArgs[0] + " " + cmdArgs[1];

                    Doctor currentDoctor = doctors.Where(d => d.Name.Equals(doctor)).FirstOrDefault();

                    if (currentDoctor != null)
                    {                        
                        Console.WriteLine(string.Join(Environment.NewLine, currentDoctor.GetAllPatients()));
                    }
                }
            }
        }
    }
}
