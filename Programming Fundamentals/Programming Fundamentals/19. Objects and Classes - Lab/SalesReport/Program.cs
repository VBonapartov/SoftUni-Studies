using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Sale> listOfSales = ReadAllSales();

            Dictionary<string, decimal> salesByTown = CalculateSalesByTown(listOfSales);
            PrintSalesByTown(salesByTown);
        }

        static private List<Sale> ReadAllSales()
        {
            List<Sale> listOfSales = new List<Sale>();

            int count = int.Parse(Console.ReadLine());
            for(int i = 0; i < count; i++)
                listOfSales.Add(ReadSale());

            return listOfSales;
        }

        static private Sale ReadSale()
        {
            string[] inputLine = Console.ReadLine().Trim().Split(' ');

            Sale sale = new Sale
            {
                Town = inputLine[0],
                Product = inputLine[1],
                Price = decimal.Parse(inputLine[2]),
                Quantity = decimal.Parse(inputLine[3])
            };

            return sale;
        }

        static private Dictionary<string, decimal> CalculateSalesByTown(List<Sale> listOfSales)
        {
            Dictionary<string, decimal> salesByTown = new Dictionary<string, decimal>();

            // Variant 1
            salesByTown = listOfSales
                            .Select(s => new { town = s.Town, totalSales = s.Quantity * s.Price })
                            .GroupBy(s => s.town)
                            .OrderBy(s => s.Key)
                            .ToDictionary(s => s.Key, s => s.Sum(p => p.totalSales));

            // Variant 2
            //for (int i = 0; i < listOfSales.Count; i++)
            //{
            //    Sale sale = listOfSales[i];
            //    if (!salesByTown.ContainsKey(sale.Town))
            //        salesByTown.Add(sale.Town, 0.0m);

            //    salesByTown[sale.Town] += sale.Quantity * sale.Price;
            //}

            return salesByTown;
        }

        static private void PrintSalesByTown(Dictionary<string, decimal> salesByTown)
        {
            List<string> salesForPrint = salesByTown
                                            .OrderBy(s => s.Key)
                                            .Select(s => s.Key + " -> " + string.Format($"{s.Value:F2}"))
                                            .ToList();
            Console.WriteLine($"{string.Join(Environment.NewLine, salesForPrint)}");
        }
    }
}
