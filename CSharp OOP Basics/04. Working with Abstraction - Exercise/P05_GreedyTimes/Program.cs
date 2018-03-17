namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<string[]> items;
        private static Dictionary<string, Dictionary<string, long>> bag;

        private static long bagCapacity;

        public static void Main(string[] args)
        {   
            InitializeBag();
            GetInputItems();
            PutItemsInBag();
            PrintBag();
        }

        private static void InitializeBag()
        {
            bagCapacity = long.Parse(Console.ReadLine());
            bag = new Dictionary<string, Dictionary<string, long>>();
        }

        private static List<string[]> GetInputItems()
        {
            items = new List<string[]>();

            string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cmdArgs.Length; i += 2)
            {
                string item = cmdArgs[i];
                string quantity = cmdArgs[i + 1];

                if (item.ToLower().Equals("gold") || item.Length == 3 || (item.Length >= 4 && item.ToLower().EndsWith("gem")))
                {
                    items.Add(new string[] { item, quantity });
                }
            }

            return items;
        }

        private static void PutItemsInBag()
        {
            long currentBag = 0;

            long gold = PutGoldItemsInBag(currentBag);
            currentBag += gold;

            long gem = PutGemItemsInBag(gold, currentBag);
            currentBag += gem;

            PutCashItemsInBag(gem, currentBag);
        }

        private static long PutGoldItemsInBag(long currentBag)
        {
            List<string[]> goldItems = items.Where(i => i[0].ToLower().Equals("gold")).ToList();

            foreach (string[] item in goldItems.OrderByDescending(i => int.Parse(i[1])))
            {
                int quantity = int.Parse(item[1]);

                if (quantity + currentBag <= bagCapacity)
                {
                    AddItemToBag("Gold", item[0], quantity);

                    currentBag += quantity;
                }
            }

            return currentBag;
        }

        private static long PutGemItemsInBag(long gold, long currentBag)
        {
            List<string[]> gemItems = items.Where(i => i[0].Length >= 4 && i[0].ToLower().EndsWith("gem")).ToList();

            long totalGem = 0;

            foreach (string[] item in gemItems.OrderByDescending(i => int.Parse(i[1])))
            {
                int quantity = int.Parse(item[1]);

                if ((quantity + currentBag <= bagCapacity) && (totalGem + quantity <= gold))
                {
                    AddItemToBag("Gem", item[0], quantity);

                    currentBag += quantity;
                    totalGem += quantity;
                }
            }

            return totalGem;
        }

        private static long PutCashItemsInBag(long gem, long currentBag)
        {
            List<string[]> cashItems = items.Where(i => i[0].Length == 3).ToList();

            long totalCash = 0;

            foreach (string[] item in cashItems.OrderByDescending(i => int.Parse(i[1])))
            {
                int quantity = int.Parse(item[1]);

                if ((quantity + currentBag <= bagCapacity) && (totalCash + quantity <= gem))
                {
                    AddItemToBag("Cash", item[0], quantity);

                    currentBag += quantity;
                    totalCash += quantity;
                }
            }

            return totalCash;
        }

        private static void AddItemToBag(string itemType, string itemName, int quantity)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag.Add(itemType, new Dictionary<string, long>());
            }

            if (!bag[itemType].ContainsKey(itemName))
            {
                bag[itemType].Add(itemName, 0);
            }

            bag[itemType][itemName] += quantity;
        }

        private static void PrintBag()
        {
            foreach (var item in bag.OrderByDescending(i => i.Value.Sum(t => t.Value)))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(t => t.Value)}");

                foreach (var itemDetails in item.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    Console.WriteLine($"##{itemDetails.Key} - {itemDetails.Value}");
                }
            }
        }
    }
}