using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            string hours = Console.ReadLine();
            string minutes = Console.ReadLine();

            string time = string.Format($"{hours}:{minutes}");
            string format = "H:mm";
            DateTime myDateTime = DateTime.ParseExact(time, format,
                                       System.Globalization.CultureInfo.InvariantCulture);

            myDateTime = myDateTime.AddMinutes(30);
            Console.WriteLine(myDateTime.ToString("H:mm"));
        }
    }
}
