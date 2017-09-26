using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int bpm = int.Parse(Console.ReadLine());
            int numberOfBPM = int.Parse(Console.ReadLine());

            double bars = Math.Round(numberOfBPM / 4.0, 1);
            int minutes = numberOfBPM / bpm;

            double floatNumber = numberOfBPM / (double)bpm;
            floatNumber -= Math.Truncate(floatNumber);
            int seconds = (int)Math.Truncate(floatNumber * 60);

            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
