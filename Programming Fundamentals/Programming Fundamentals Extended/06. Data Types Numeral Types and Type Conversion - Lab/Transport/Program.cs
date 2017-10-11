using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            int totalCapacity = 24;
            int courses = (int)Math.Ceiling((double)numberOfPeople / totalCapacity);
            Console.WriteLine($"{courses}");                
        }
    }
}
