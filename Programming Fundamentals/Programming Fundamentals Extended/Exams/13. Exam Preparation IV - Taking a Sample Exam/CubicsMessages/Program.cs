using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicsMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Over!"))
            {
                int num = int.Parse(Console.ReadLine());

                string pattern = @"^(?<leftDigits>\d+)(?<message>[A-Za-z]{" + num + @"})(?<rightPart>[^A-Za-z]*)$";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string message = match.Groups["message"].Value;
                    string indexes = match.Groups["leftDigits"].Value + Regex.Match(match.Groups["rightPart"].Value, @"[0-9]+");

                    StringBuilder verificationCode = new StringBuilder(indexes.Length);
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        int index = Convert.ToInt32(indexes[i].ToString());
                        if (index < message.Length)
                        {
                            verificationCode.Append(message[index]);
                        }
                        else
                        {
                            verificationCode.Append(" ");
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }
            }
        }
    }
}
