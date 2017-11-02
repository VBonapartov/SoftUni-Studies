using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpyGram
{
    class Program
    {
        static void Main(string[] args)
        {
            string privateKey = Console.ReadLine();

            Dictionary<string, List<string>> pendingMessages = new Dictionary<string, List<string>>();

            string message = string.Empty;
            while(!(message = Console.ReadLine()).Equals("END"))
            {
                Match matchMessage = Regex.Match(message, @"TO: (?<sender>[A-Z]+); MESSAGE: .*?;");
                if(matchMessage.Success)
                {
                    string sender = matchMessage.Groups["sender"].Value;
                    if(!pendingMessages.ContainsKey(sender))
                    {
                        pendingMessages.Add(sender, new List<string> { });
                    }

                    pendingMessages[sender].Add(message);
                }
            }

            foreach (KeyValuePair<string, List<string>> sender in pendingMessages.OrderBy(s => s.Key))
            {
                foreach (string msg in sender.Value)
                { 
                    Console.WriteLine(EncryptMessage(msg, privateKey));
                }
            }
        }

        private static string EncryptMessage(string message, string privateKey)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            int idxPrivateKey = 0;
            for(int i = 0; i < message.Length; i++)
            {
                int currentChar = message[i];
                currentChar += Convert.ToInt32(privateKey[idxPrivateKey].ToString());
                encryptedMessage.Append((char)currentChar);

                idxPrivateKey = (idxPrivateKey == privateKey.Length - 1) ? 0 : ++idxPrivateKey;
            }

            return encryptedMessage.ToString();
        }
    }
}
