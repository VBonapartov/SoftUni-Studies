using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadedTime = long.Parse(Console.ReadLine());

            long filteredPictures = (long)Math.Ceiling((numberOfPictures * filterFactor) / 100.00);
            long totalSeconds = (numberOfPictures * filterTime) + (filteredPictures * uploadedTime);

            TimeSpan t = TimeSpan.FromSeconds(totalSeconds);
            string output = string.Format("{0:D0}:{1:D2}:{2:D2}:{3:D2}",
                            t.Days,
                            t.Hours,
                            t.Minutes,
                            t.Seconds);

            Console.WriteLine(output);

            // TimeSpan time = TimeSpan.FromSeconds(totalTime);
            // Console.WriteLine("{0:d\\:hh\\:mm\\:ss}", time);
        }
    }
}
