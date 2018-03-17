using System;
using System.Globalization;

public class DateModifier
{
    public static int GetDaysBetweenDates(string date1, string date2)
    {
        DateTime dt1 = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime dt2 = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

        TimeSpan duration = (dt2 > dt1) ? dt2 - dt1 : dt1 - dt2;

        return duration.Days;
    }
}