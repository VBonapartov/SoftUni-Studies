using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Log information -> Username: {IP Address1, IP Address2 ...}
            SortedDictionary<string, List<string>> logInfo = new SortedDictionary<string, List<string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] inputInfo = input.Split(' ');

                string ipAddress = inputInfo[0].Substring(3);
                string username = inputInfo[2].Substring(5);

                // Save username and IP address
                if(logInfo.ContainsKey(username))
                {
                    logInfo[username].Add(ipAddress);
                }
                else
                {
                    logInfo.Add(username, new List<string>() {ipAddress});
                }
            }

            PrintLogInformation(logInfo);
        }

        static private void PrintLogInformation(SortedDictionary<string, List<string>> logInfo)
        {
            foreach (KeyValuePair<string, List<string>> user in logInfo)
            {      
                // Print username
                Console.WriteLine($"{user.Key}: ");

                List<string> ipAddresses = user.Value.Distinct().ToList();

                // Print IP addresses and count messages sent with the corresponding IP
                // Note: number of IP addresses == number of messages
                StringBuilder output = new StringBuilder();
                foreach (string ipAddress in ipAddresses)
                {
                    if (output.Length > 0)
                        output.Append(", ");

                    output.AppendFormat($"{ipAddress} => {user.Value.Count(x => x.Equals(ipAddress))}");
                }

                output.Append(".");
                Console.WriteLine(output);
            }
        }
    }
}
