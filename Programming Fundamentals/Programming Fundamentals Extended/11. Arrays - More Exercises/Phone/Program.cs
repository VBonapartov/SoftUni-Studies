using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] names = Console.ReadLine().Split(' ');

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("done"))
            {
                string[] commands = input.Split(' ');
                string phone = GetPhoneNumberByName(phoneNumbers, names, commands[1]);
                string name = GetNameByPhoneNumber(phoneNumbers, names, commands[1]);
                string calledParty = (phone.Length > 0) ? phone : name;
                string calledPartyPhone = (phone.Length > 0) ? phone : commands[1];
                
                switch (commands[0])
                {
                    case "call":                        
                        Console.WriteLine($"calling {calledParty}...");

                        int sumOfTheDigits = GetSumOfTheDigits(calledPartyPhone);
                        string duration = GetDuration(sumOfTheDigits);
                        if (sumOfTheDigits % 2 == 0)
                        {                            
                            Console.WriteLine($"call ended. duration: {duration}");
                        }
                        else
                        {
                            Console.WriteLine("no answer");
                        }

                        break;
                    case "message":
                        Console.WriteLine($"sending sms to {calledParty}...");

                        int diffOfTheDigits = GetDifferenceOfTheDigits(calledPartyPhone);
                        if(diffOfTheDigits % 2 == 0)
                        {
                            Console.WriteLine("meet me there");
                        }
                        else
                        {
                            Console.WriteLine("busy");
                        }

                        break;
                }                
            }
        }

        static private string GetPhoneNumberByName(string[] phones, string[] names, string name)
        {
            for (int i = 0; i < names.GetLength(0); i++)
            {
                if (name.Equals(names[i]))
                {
                    return phones[i];
                }
            }

            return "";
        }


        static private string GetNameByPhoneNumber(string[] phones, string[] names, string phone)
        {
            int index = 0;
            for (int i = 0; i < phones.GetLength(0); i++)
            {
                if (phone.Equals(phones[i]))
                {
                    index = i;
                    break;
                }
            }

            return names[index];
        }

        static private int GetSumOfTheDigits(string number)
        {
            number = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace("+", "").Replace("\\", "").Replace("/", "");
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sum += Convert.ToInt32(number[i].ToString());
            }

            return sum;
        }

        static private int GetDifferenceOfTheDigits(string number)
        {
            number = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace("+", "").Replace("\\", "").Replace("/", "");
            int sum = number[0];
            for (int i = 1; i < number.Length; i++)
            {
                sum -= Convert.ToInt32(number[i]);
            }

            return sum;
        }

        static private string GetDuration(int number)
        {
            int minutes = number / 60;
            int seconds = number % 60;
            string result = minutes.ToString("00") + ":" + seconds.ToString("00");

            return result;
        }
    }
}
