using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChangeAlert
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double threshold = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                double percent = GetPercent(lastPrice, currentPrice);
                bool isSignificantDifference = isDiff(percent, threshold);

                string message = GetMessage(currentPrice, lastPrice, percent, isSignificantDifference);
                Console.WriteLine(message);

                lastPrice = currentPrice;
            }
        }

        private static string GetMessage(double currentPrice, double lastPrice, double percent, bool isSignificantDifference)
        {
            percent *= 100;

            string message = string.Empty;
            if (percent == 0)
            {
                message = string.Format("NO CHANGE: {0}", currentPrice);
            }
            else if (!isSignificantDifference)
            {
                message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percent);
            }
            else if (isSignificantDifference && (percent > 0))
            {
                message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percent);
            }
            else if (isSignificantDifference && (percent < 0))
                message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percent);

            return message;
        }

        private static bool isDiff(double threshold, double isDiff)
        {
            if (Math.Abs(threshold) >= isDiff)
            {
                return true;
            }
            return false;
        }

        private static double GetPercent(double last, double current)
        {
            double result = (current - last) / last;
            return result;
        }
    }
}
