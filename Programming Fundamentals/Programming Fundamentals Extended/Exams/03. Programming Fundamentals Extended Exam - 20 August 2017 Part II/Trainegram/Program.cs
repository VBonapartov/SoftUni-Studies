using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainegram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> validTrains = new List<string>();

            string message = string.Empty;
            while (!(message = Console.ReadLine()).Equals("Traincode!"))
            {
                string trainPattern = @"^<\[[^A-Za-z0-9]*?\]\.(\.\[[A-Za-z0-9]*\]\.)*$";

                bool isValidTrain = Regex.IsMatch(message, trainPattern);
                if (isValidTrain)
                {
                    validTrains.Add(message);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validTrains));
        }
    }
}
