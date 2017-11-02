using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniMessages
{
    class Program
    {
        static void Main(string[] args)
        {    
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Decrypt!"))
            {
                string length = Console.ReadLine();
                string pattern = @"^(\d{1,})(?<message>[A-Za-z]{" + length + @"})[^A-Za-z]*?(\d{1,})[^A-Za-z]*?$";

                Match msgMatch = Regex.Match(input, pattern);
                if(msgMatch.Success)
                {
                    string encryptedMessage = msgMatch.Groups["message"].Value;
                    string indices = Regex.Replace(msgMatch.Value, @"[^0-9]+", "");

                    StringBuilder verificationCode = new StringBuilder();
                    for(int i = 0; i < indices.Length; i++)
                    {
                        int index = Convert.ToInt32(indices[i].ToString());
                        if (index >= encryptedMessage.Length)
                            continue;

                        verificationCode.Append(encryptedMessage[index]);
                    }

                    Console.WriteLine($"{encryptedMessage} = {verificationCode}");
                }
            }
        }
    }
}
