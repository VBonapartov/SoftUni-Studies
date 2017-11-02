using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfTheMarathon = int.Parse(Console.ReadLine());
            int numberOfRunners = int.Parse(Console.ReadLine());
            int avgNumberOfLapsByRunner = int.Parse(Console.ReadLine());
            int lengthOfTheTrack = int.Parse(Console.ReadLine());
            int capacityOfTheTrack = int.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            long maxRunners = lengthOfTheMarathon * capacityOfTheTrack;
            long runners = (maxRunners < numberOfRunners) ? maxRunners : numberOfRunners;

            long totalMeters = runners * avgNumberOfLapsByRunner * lengthOfTheTrack;
            long totalKilometers = totalMeters / 1000;

            decimal moneyRaisedForTheMarathon = totalKilometers * moneyPerKilometer;
            Console.WriteLine($"Money raised: {moneyRaisedForTheMarathon:F2}");
        }
    }
}
