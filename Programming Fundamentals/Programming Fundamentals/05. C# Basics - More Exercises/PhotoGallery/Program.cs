using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            // First line – the photo’s number – an integer in the range [0…9999]
            // Second, third, fourth line – the day, month and year the photo was taken – integers forming valid dates in the range[01 / 01 / 1990…31 / 12 / 2020]
            // Fifth, sixth line – the hours and minutes the photo was taken – integers in the range[0…23]
            // Seventh line – the photo’s size in bytes – integer in the range[0…999000000]
            // Eighth, ninth line – the photo’s resolution(width and height) in pixels – integers in the range[1…10000]

            int photoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string photoName = "DSC_" + photoNumber.ToString().PadLeft(4, '0') + ".jpg";

            DateTime photoDate = new DateTime(year, month, day, hours, minutes, 0);

            string photoSize = string.Empty;
            if (size < 1000)
            {
                photoSize = string.Format($"{size}B");
            }
            else if(size < 1000000)
            {
                photoSize = string.Format($"{size / 1000}KB");
            }
            else
            {
                photoSize = string.Format($"{Math.Round(size / 1000000.0, 1)}MB");
            }

            string photoOrientation = string.Empty;
            if (width < height)
            {
                photoOrientation = "portrait";
            }
            else if(width == height)
            {
                photoOrientation = "square";
            }
            else
            {
                photoOrientation = "landscape";
            }
            
            Console.WriteLine($"Name: {photoName}");
            Console.WriteLine($"Date Taken: {photoDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Size: {photoSize}");
            Console.WriteLine($"Resolution: {width}x{height} ({photoOrientation})");
        }
    }
}
