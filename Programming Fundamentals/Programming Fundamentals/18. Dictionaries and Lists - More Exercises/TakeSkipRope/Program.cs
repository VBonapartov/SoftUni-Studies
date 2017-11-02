using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMsg = Console.ReadLine().Trim();

            List<int> numbersList = encryptedMsg.Where(x => Char.IsDigit(x)).Select(x => Convert.ToInt32(x.ToString())).ToList();
            List<int> takeList = numbersList.Where((item, index) => index % 2 == 0).ToList();
            List<int> skipList = numbersList.Where((item, index) => index % 2 != 0).ToList();

            List<char> nonNumbersList = encryptedMsg.Where(x => !Char.IsDigit(x)).ToList();
            string messageStr = new string(nonNumbersList.ToArray());
            
            int totalSkips = 0;
            StringBuilder decryptedMsg = new StringBuilder();
            for (int i = 0; i < takeList.Count; i++)
            {
                int skip = skipList[i];
                int take = takeList[i];
                
                if(totalSkips + take > messageStr.Length)
                    take = messageStr.Length - totalSkips;

                decryptedMsg.Append(messageStr.Substring(totalSkips, take));

                totalSkips += take + skip;
            }

            Console.WriteLine(decryptedMsg);
        }
    }
}
