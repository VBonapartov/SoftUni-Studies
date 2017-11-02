using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            string afterShakeOff = string.Empty;
            while (!string.IsNullOrEmpty(pattern) && ShakeOff(input, pattern, out afterShakeOff))
            {
                input = afterShakeOff;
                int index = pattern.Length / 2;
                pattern = pattern.Substring(0, index) + pattern.Substring(index + 1);

                Console.WriteLine("Shaked it.");
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }

        private static bool ShakeOff(string input, string pattern, out string afterShakeOff)
        {
            afterShakeOff = string.Empty;
            int index = input.IndexOf(pattern);

            if (index != -1)
            {
                input = input.Substring(0, index) + input.Substring(index + pattern.Length);
                index = input.LastIndexOf(pattern);
                if (index != -1)
                {
                    afterShakeOff = input.Substring(0, index) + input.Substring(index + pattern.Length);
                    return true;
                }
            }

            return false;
        }
    }
}
