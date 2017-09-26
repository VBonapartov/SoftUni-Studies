using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Name – as per the input
            // Volume – integer, suffixed by “ml” (e.g. “220ml”)
            // Energy content – integer, suffixed by “kcal” (e.g. “500kcal”)
            // Sugar content – integer, suffixed by “g” (e.g. “30g”) 

            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());

            double energy = (volume / 100.00) * energyContent;
            double sugar = (volume / 100.00) * sugarContent;

            string output = string.Format($"{volume}ml {name}:\n{energy}kcal, {sugar}g sugars");
            Console.WriteLine(output);
        }
    }
}
