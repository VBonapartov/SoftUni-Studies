using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nacepin
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal priceUS = decimal.Parse(Console.ReadLine());
            long boxWeightInKilogramsUS = long.Parse(Console.ReadLine());
            decimal priceUK = decimal.Parse(Console.ReadLine());
            long boxWeightInKilogramsUK = long.Parse(Console.ReadLine());
            decimal priceChinese = decimal.Parse(Console.ReadLine());
            long boxWeightInKilogramsChinese = long.Parse(Console.ReadLine());

            // 1 BGN = 0.58 USD
            // 1 BGN = 0.41 GBP
            // 0.27 BGN = 1 CNY

            // US store 
            decimal bgnPerKiloUSStore = (priceUS / 0.58m) / boxWeightInKilogramsUS;

            // UK store            
            decimal bgnPerKiloUKStore = (priceUK / 0.41m) / boxWeightInKilogramsUK;

            // Chinese store            
            decimal bgnPerKiloChineseStore = (priceChinese * 0.27m) / boxWeightInKilogramsChinese;

            decimal lowestPrice = Math.Min(Math.Min(bgnPerKiloUSStore, bgnPerKiloUKStore), bgnPerKiloChineseStore);
            decimal highestPrice = Math.Max(Math.Max(bgnPerKiloUSStore, bgnPerKiloUKStore), bgnPerKiloChineseStore);
            decimal diff = highestPrice - lowestPrice;

            string country = "Chinese";
            if(lowestPrice == bgnPerKiloUSStore)
            {
                country = "US";
            }
            else if(lowestPrice == bgnPerKiloUKStore)
            {
                country = "UK";
            }

            Console.WriteLine($"{country} store. {lowestPrice:F2} lv/kg");
            Console.WriteLine($"Difference {diff:F2} lv/kg");
        }
    }
}
