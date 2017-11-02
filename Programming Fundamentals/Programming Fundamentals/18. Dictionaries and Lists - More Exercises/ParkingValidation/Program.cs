using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingValidation = new Dictionary<string, string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Trim().Split(' ');

                switch(command[0])
                {
                    case "register":
                        Register(parkingValidation, command);
                        break;
                    case "unregister":
                        Unregister(parkingValidation, command);
                        break;
                }
            }

            PrintLicenseInfo(parkingValidation);
        }

        static private void Register(Dictionary<string, string> parkingValidation, string[] command)
        {
            string username = command[1];
            string licensePlateNumber = command[2];

            if(parkingValidation.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {parkingValidation[username]}");
            }
            else if(!isValidLicensePlate(licensePlateNumber))
            {
                Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
            }
            else if(parkingValidation.ContainsValue(licensePlateNumber))
            {
                Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");                
            }
            else
            {
                parkingValidation.Add(username, licensePlateNumber);
                Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
            }
        }

        static private void Unregister(Dictionary<string, string> parkingValidation, string[] command)
        {
            string username = command[1];

            if (!parkingValidation.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                parkingValidation.Remove(username);
                Console.WriteLine($"user {username} unregistered successfully");
            }
        }

        static private bool isValidLicensePlate(string licensePlateNumber)
        {
            string first2Chars = licensePlateNumber.Substring(0, 2);
            string middlePart = licensePlateNumber.Substring(2, 4);
            string last2Chars = licensePlateNumber.Substring(licensePlateNumber.Length - 2);

            bool isUpper = first2Chars.All(x => Char.IsUpper(x)) && last2Chars.All(x => Char.IsUpper(x));
            bool isDigit = middlePart.All(x => Char.IsDigit(x));

            return isUpper && isDigit;
        }

        static private void PrintLicenseInfo(Dictionary<string, string> parkingValidation)
        {
            foreach(KeyValuePair<string, string> license in parkingValidation)
            {
                Console.WriteLine($"{license.Key} => {license.Value}");
            }
        }
    }
}
