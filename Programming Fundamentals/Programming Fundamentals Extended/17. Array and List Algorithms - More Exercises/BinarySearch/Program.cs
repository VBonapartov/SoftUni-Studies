using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int element = int.Parse(Console.ReadLine());

            int iterations = 0;
            bool isFound = LinearSearch(nums, element, out iterations);

            Console.WriteLine("{0}", (isFound) ? "Yes" : "No");
            Console.WriteLine($"Linear search made {iterations} iterations");

            SortListAsc(nums);
            isFound = BinarySearch(nums, element, out iterations);
            Console.WriteLine($"Binary search made {iterations} iterations");
        }

        static private bool LinearSearch(List<int> nums, int element, out int iterations)
        {
            int countIterations = 0;
            bool isFound = false;
            foreach(int item in nums)
            {
                countIterations++;
                if (item == element)
                {
                    isFound = true;
                    break;
                }
            }

            iterations = countIterations;
            return isFound;
        }

        static private bool BinarySearch(List<int> nums, int element, out int iterations)
        {
            int countIterations = 0;
            bool isFound = false;

            int min = 0;
            int max = nums.Count() - 1;

            while (min <= max)
            {
                countIterations++;
                int mid = min + (max - min) / 2;
                if (element == nums[mid])
                {
                    isFound = true;
                    break;
                }
                else if (element < nums[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            iterations = countIterations;
            return isFound;
        }

        static private void SortListAsc(List<int> nums)
        {
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        int item = nums[i];
                        nums.RemoveAt(i);
                        nums.Insert(i + 1, item);

                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
