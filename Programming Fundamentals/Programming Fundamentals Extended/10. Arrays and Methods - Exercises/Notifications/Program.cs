using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                string result = Console.ReadLine();

                string operation = string.Empty;
                switch (result)
                {
                    case "success":
                        operation = Console.ReadLine();
                        string message = Console.ReadLine();
                        ShowSuccess(operation, message);
                        break;
                    case "error":
                        operation = Console.ReadLine();
                        int code = int.Parse(Console.ReadLine());
                        ShowError(operation, code);
                        break;
                }
            }
        }

        static private void ShowSuccess(string operation, string message)
        {
            Console.WriteLine($"Successfully executed {operation}.");
            Console.WriteLine("==============================");
            Console.WriteLine($"Message: {message}.");
        }

        static private void ShowError(string operation, int code)
        {
            string reason = (code >= 0) ? "Invalid Client Data" : "Internal System Failure";
            Console.WriteLine($"Error: Failed to execute {operation}.");
            Console.WriteLine("==============================");
            Console.WriteLine($"Error Code: {code}.");
            Console.WriteLine($"Reason: {reason}.");
        }
    }
}
