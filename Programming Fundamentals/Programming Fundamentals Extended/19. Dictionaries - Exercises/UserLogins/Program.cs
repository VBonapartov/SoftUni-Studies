using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogins
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> userEntries = new Dictionary<string, string>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("login"))
            {
                string[] userInfo = input.Split(' ');
                AddUserLoginInfo(userEntries, userInfo);
            }

            int countUnsuccessfulLogin = 0;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] userInfo = input.Split(' ');

                if (!CheckUserLogin(userEntries, userInfo))
                    countUnsuccessfulLogin++;
            }

            Console.WriteLine($"unsuccessful login attempts: {countUnsuccessfulLogin}");
        }

        static private void AddUserLoginInfo(Dictionary<string, string> userEntries, string[] userInfo)
        {
            string username = userInfo[0];
            string password = userInfo[2];

            if (userEntries.ContainsKey(username))
            {
                userEntries[username] = password;
            }
            else
            {
                userEntries.Add(username, password);
            }
        }

        static private bool CheckUserLogin(Dictionary<string, string> userEntries, string[] userInfo)
        {
            string username = userInfo[0];
            string password = userInfo[2];

            if ((userEntries.ContainsKey(username)) && (userEntries[username].Equals(password)))
            {
                Console.WriteLine($"{username}: logged in successfully");
                return true;
            }
            else
            {
                Console.WriteLine($"{username}: login failed");
                return false;
            }
        }
    }
}
