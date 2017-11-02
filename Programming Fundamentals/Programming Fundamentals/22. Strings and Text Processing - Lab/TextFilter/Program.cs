using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for(int i = 0; i < banList.Length; i++)
            {
                string pattern = banList[i];
                text = text.Replace(pattern, new string('*', pattern.Length));
            }

            Console.WriteLine(text);
        }
    }
}
