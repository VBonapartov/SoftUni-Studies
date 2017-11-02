using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime timeSinoLeavesSoftUni = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            double numberOfSteps = double.Parse(Console.ReadLine()) % 86400;
            double timeForEachStepInSeconds = double.Parse(Console.ReadLine()) % 86400;

            double totalSecondsForAllSteps = numberOfSteps * timeForEachStepInSeconds;           
            DateTime timeOfArrival = timeSinoLeavesSoftUni.AddSeconds(totalSecondsForAllSteps);

            Console.WriteLine($"Time Arrival: {timeOfArrival.ToString("HH:mm:ss")}");
        }
    }
}
