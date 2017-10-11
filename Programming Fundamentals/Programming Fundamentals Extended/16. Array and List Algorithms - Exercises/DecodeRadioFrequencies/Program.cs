using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeRadioFrequencies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Trim().Split(' ').ToArray();

            List<string> result = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                string[] numberStr = nums[i].Split('.');

                if(!numberStr[0].Equals("0"))
                {
                    char leftPartASCII = (char)(int.Parse(numberStr[0]));
                    result.Insert(i, leftPartASCII.ToString());
                }

                if (!numberStr[1].Equals("0"))
                {
                    result.Reverse();

                    char rightPartASCII = (char)(int.Parse(numberStr[1]));
                    result.Insert(i, rightPartASCII.ToString());
                     
                    result.Reverse();
                }                                      
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
