using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (!input.Equals("print"))
            {
                string[] commands = input.Split(' ');
                switch (commands[0])
                {
                    case "add":
                        Add(listNumbers, Convert.ToInt32(commands[1]), Convert.ToInt32(commands[2]));
                        break;
                    case "addMany":
                        AddMany(listNumbers, commands);
                        break;
                    case "contains":
                        Contains(listNumbers, Convert.ToInt32(commands[1]));
                        break;
                    case "remove":
                        Remove(listNumbers, Convert.ToInt32(commands[1]));
                        break;
                    case "shift":
                        Shift(listNumbers, Convert.ToInt32(commands[1]));
                        break;
                    case "sumPairs":
                        SumPairs(listNumbers);
                        break;
                }

                input = Console.ReadLine();
            }

            PrintList(listNumbers);
        }

        static private void Add(List<int> nums, int index, int element)
        {
            nums.Insert(index, element);
        }

        static private void AddMany(List<int> nums, string[] commands)
        {
            int index = int.Parse(commands[1]);
            for (int i = commands.Length - 1; i >= 2; i--)
            {
                int element = int.Parse(commands[i]);
                nums.Insert(index, element);
            }
        }

        static private void Contains(List<int> nums, int element)
        {
            int index = nums.IndexOf(element);
            Console.WriteLine(index);
        }

        static private void Remove(List<int> nums, int index)
        {
            nums.RemoveAt(index);
        }

        static private void Shift(List<int> nums, int positions)
        {
            while (positions > 0)
            {
                int first = nums[0];
                nums.RemoveAt(0);
                nums.Add(first);
                positions--;
            }
        }

        static private void SumPairs(List<int> nums)
        {
            List<int> result = new List<int>();
            
            for(int i = 0; i < nums.Count - 1; i += 2)
            {
                int sum = nums[i] + nums[i + 1];
                result.Add(sum);
            }

            if (nums.Count % 2 != 0)
                result.Add(nums[nums.Count - 1]);

            nums.Clear();
            nums.AddRange(result);
        }

        static private void PrintList(List<int> nums)
        {
            Console.WriteLine("[" + string.Join(", ", nums) + "]");
        }
    }
}
