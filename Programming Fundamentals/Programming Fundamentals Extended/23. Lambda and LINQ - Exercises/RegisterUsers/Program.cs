using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, DateTime> userInfo = new Dictionary<string, DateTime>();

            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries );
                string username = command[0];
                DateTime date = DateTime.ParseExact(command[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                userInfo.Add(username, date);
            }

            var lastReisteredUsers = userInfo
                .Reverse()
                .OrderBy(u => u.Value)
                .Take(5)
                .OrderByDescending(u => u.Value)
                .Select(u => u.Key);

            Console.WriteLine($"{string.Join(Environment.NewLine, lastReisteredUsers)}");
        }
    }
}
