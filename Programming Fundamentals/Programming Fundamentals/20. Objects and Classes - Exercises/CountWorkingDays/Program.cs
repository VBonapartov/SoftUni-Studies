using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate1 = Console.ReadLine();
            string inputDate2 = Console.ReadLine();

            DateTime[] nonWorkingDays = new DateTime[11];
            nonWorkingDays[0] = DateTime.ParseExact("01-01", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[1] = DateTime.ParseExact("03-03", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[2] = DateTime.ParseExact("01-05", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[3] = DateTime.ParseExact("06-05", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[4] = DateTime.ParseExact("24-05", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[5] = DateTime.ParseExact("06-09", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[6] = DateTime.ParseExact("22-09", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[7] = DateTime.ParseExact("01-11", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[8] = DateTime.ParseExact("24-12", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[9] = DateTime.ParseExact("25-12", "d-M", CultureInfo.InvariantCulture);
            nonWorkingDays[10] = DateTime.ParseExact("26-12", "d-M", CultureInfo.InvariantCulture);

            DateTime startDate = DateTime.ParseExact(inputDate1, "d-M-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(inputDate2, "d-M-yyyy", CultureInfo.InvariantCulture);

            int countWorkingDays = 0;
            for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {
                if (currentDay.DayOfWeek == DayOfWeek.Saturday || currentDay.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                bool isNonWorkingDay = nonWorkingDays
                                            .Select(d => new { d.Day, d.Month })
                                            .Where(d => d.Day == currentDay.Day && d.Month == currentDay.Month)
                                            .Any();

                if (isNonWorkingDay)
                    continue;

                countWorkingDays++;
            }

            Console.WriteLine(countWorkingDays);
        }
    }
}
