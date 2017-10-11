using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number1 = ulong.Parse(Console.ReadLine());
            ulong number2 = ulong.Parse(Console.ReadLine());

            ulong min = Math.Min(number1, number2);
            ulong max = Math.Max(number1, number2);
            int overflow = 0;

            string minType = string.Empty;
            if(min >= byte.MinValue && min <= byte.MaxValue)
            {
                minType = "byte";
                overflow = (int)Math.Round((double)max / byte.MaxValue);
            }
            else if(min >= ushort.MinValue && min <= ushort.MaxValue)
            {
                minType = "ushort";
                overflow = (int)Math.Round((double)max / ushort.MaxValue);
            }
            else if (min >= uint.MinValue && min <= uint.MaxValue)
            {
                minType = "uint";
                overflow = (int)Math.Round((double)max / uint.MaxValue);
            }
            else if (min >= ulong.MinValue && min <= ulong.MaxValue)
            {
                minType = "ulong";
                overflow = (int)Math.Round((double)max / ulong.MaxValue);
            }


            string maxType = string.Empty;
            if (max >= byte.MinValue && max <= byte.MaxValue)
            {
                maxType = "byte";
            }
            else if (max >= ushort.MinValue && max <= ushort.MaxValue)
            {
                maxType = "ushort";
            }
            else if (max >= uint.MinValue && max <= uint.MaxValue)
            {
                maxType = "uint";
            }
            else if (max >= ulong.MinValue && max <= ulong.MaxValue)
            {
                maxType = "ulong";
            }

            Console.WriteLine($"bigger type: {maxType}");
            Console.WriteLine($"smaller type: {minType}");
            Console.WriteLine($"{max} can overflow {minType} {overflow} times");
        }
    }
}
