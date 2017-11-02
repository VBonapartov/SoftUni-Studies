using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesInfo = new Dictionary<string, Dictionary<string, int>>();
            for(int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',');

                if (!clothesInfo.ContainsKey(color))
                {
                    clothesInfo.Add(color, new Dictionary<string, int>() { });
                }

                for (int p = 0; p < clothes.Length; p++)
                {
                    if (clothesInfo[color].ContainsKey(clothes[p]))
                    {
                        clothesInfo[color][clothes[p]]++;
                    }
                    else
                    {
                        clothesInfo[color].Add(clothes[p], 1);
                    }
                }
            }

            string[] searchItem = Console.ReadLine().Trim().Split(' ');

            foreach(KeyValuePair<string, Dictionary < string, int>> clothes in clothesInfo)
            {
                Console.WriteLine($"{clothes.Key} clothes:");                          

                foreach (KeyValuePair<string, int> item in clothes.Value)
                {
                    if ((clothes.Key.Equals(searchItem[0])) && (item.Key.Equals(searchItem[1])))
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }                        
                }
            }
        }
    }
}
