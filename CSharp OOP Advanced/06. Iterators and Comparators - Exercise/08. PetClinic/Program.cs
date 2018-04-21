namespace _08._PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Pet> pets;
        private static List<Clinic> clinics;

        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            pets = new List<Pet>();
            clinics = new List<Clinic>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            CreatePetOrClinic(cmdArgs);
                            break;

                        case "Add":
                            Console.WriteLine(AddPetToClinic(cmdArgs) ? "True" : "False");
                            break;

                        case "Release":
                            Console.WriteLine(ReleasePetFromClinic(cmdArgs) ? "True" : "False");
                            break;

                        case "HasEmptyRooms":
                            Console.WriteLine(CheckForEmptyRooms(cmdArgs) ? "True" : "False");
                            break;

                        case "Print":
                            Print(cmdArgs);
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void CreatePetOrClinic(string[] cmdArgs)
        {
            if (cmdArgs[1].Equals("Pet"))
            {
                Pet pet = new Pet(cmdArgs[2], int.Parse(cmdArgs[3]), cmdArgs[4]);
                pets.Add(pet);
            }
            else if (cmdArgs[1].Equals("Clinic"))
            {
                Clinic clinic = new Clinic(cmdArgs[2], int.Parse(cmdArgs[3]));
                clinics.Add(clinic);
            }
        }

        private static bool AddPetToClinic(string[] cmdArgs)
        {
            Pet pet = GetPetByName(cmdArgs[1]);
            if (GetClinicByName(cmdArgs[2]).TryAddPet(pet))
            {
                pets.Remove(pet);
                return true;
            }

            return false;
        }

        private static bool ReleasePetFromClinic(string[] cmdArgs)
        {
            string clinicName = cmdArgs[1];
            return GetClinicByName(clinicName).TryReleasePet();
        }

        private static bool CheckForEmptyRooms(string[] cmdArgs)
        {
            string clinicName = cmdArgs[1];
            return GetClinicByName(clinicName).HasEmptyRooms();
        }

        private static void Print(string[] cmdArgs)
        {
            string clinicName = cmdArgs[1];

            Clinic clinic = GetClinicByName(clinicName);

            string result = null;

            if (cmdArgs.Length == 2)
            {
                result = clinic.Print();
            }
            else if (cmdArgs.Length == 3)
            {
                int roomIndex = int.Parse(cmdArgs[2]) - 1;
                result = clinic.Print(roomIndex);
            }

            Console.WriteLine(result);
        }

        private static Clinic GetClinicByName(string clinicName)
        {
            Clinic clinic = clinics.FirstOrDefault(c => c.ClinicName.Equals(clinicName));

            if (clinic == null)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return clinic;
        }

        private static Pet GetPetByName(string petName)
        {
            Pet pet = pets.FirstOrDefault(p => p.PetName.Equals(petName));

            if (pet == null)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return pet;
        }
    }
}
