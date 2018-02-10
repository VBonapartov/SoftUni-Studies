namespace _18.PINValidation
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            ReadInputData();
        }

        private static void ReadInputData()
        {
            string name = Console.ReadLine();
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();

            ValidateData(name, gender, pin);
        }

        private static void ValidateData(string name, string gender, string pin)
        {
            if (!IsNameValid(name) || !IsPINValid(pin, gender))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
            }
            else
            {
                Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, pin);
            }
        }

        private static bool IsNameValid(string name)
        {
            string[] firstLastName = name.Split(' ');

            if (firstLastName.Length != 2 ||
                !Char.IsUpper(firstLastName[0][0]) ||
                !Char.IsUpper(firstLastName[1][0]))
            {
                return false;
            }

            return true;
        }

        private static bool IsPINValid(string pin, string gender)
        {
            int year = int.Parse(pin.Substring(0, 2));
            int month = int.Parse(pin.Substring(2, 2));
            int day = int.Parse(pin.Substring(4, 2));
            int genderDigit = int.Parse(pin[8].ToString());
            int checksum = int.Parse(pin.Substring(pin.Length - 1));

            if (!ValidateMonthAndYear(ref year, ref month) ||
                !ValidateDays(day, month, year) ||
                !GenderValidation(gender, genderDigit) ||
                !ChecksumValidation(pin, checksum))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateDays(int day, int month, int year)
        {
            return (day >= 1 && day <= DateTime.DaysInMonth(year, month));
        }

        private static bool ValidateMonthAndYear(ref int year, ref int month)
        {
            if (month >= 1 && month <= 12)
            {
                year += 1900;
            }
            else if (month >= 20 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 40 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool GenderValidation(string gender, int genderDigit)
        {
            if(genderDigit % 2 == 0 && gender.Equals("male"))
            {
                return true;
            }
            else if(genderDigit % 2 != 0 && gender.Equals("female"))
            {
                return true;
            }

            return false;
        }

        private static bool ChecksumValidation(string pin, int lastDigit)
        {
            int sum = 0;
            int[] digits = pin.ToCharArray().Select(x => x - '0').ToArray();

            int[] factors = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

            for (int i = 0; i < factors.Length; i++)
            {
                sum += digits[i] * factors[i];
            }

            int checksum = sum % 11;
            checksum = checksum < 10 ? checksum : 0;

            return (checksum == lastDigit);
        }
    }
}
