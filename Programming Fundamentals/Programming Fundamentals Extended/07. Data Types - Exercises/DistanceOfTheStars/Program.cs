using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceOfTheStars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal fromEarthToNearestStar = 4.22m * 9450000000000m;
            decimal fromEarthToTheCenterOfOurGalaxy = 26000m * 9450000000000m;
            decimal diameterOfTheMilkyWay = 100000m * 9450000000000m;
            decimal fromEarthToTheEdgeOfTheObservableUniverse = 46500000000m * 9450000000000m;

            Console.WriteLine(fromEarthToNearestStar.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(fromEarthToTheCenterOfOurGalaxy.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(diameterOfTheMilkyWay.ToString("e2", CultureInfo.InvariantCulture));
            Console.WriteLine(fromEarthToTheEdgeOfTheObservableUniverse.ToString("e2", CultureInfo.InvariantCulture));
        }
    }
}
