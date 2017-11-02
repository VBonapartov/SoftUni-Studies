using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spyfer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int index = 0;
            while(index <= arr.Count - 1)
            {
                int prevIndex = index - 1;
                int nextIndex = index + 1;

                int prevElement = (prevIndex < 0) ? 0 : arr[prevIndex];
                int nextElement = (nextIndex > arr.Count - 1) ? 0 : arr[nextIndex];

                if (arr[index] == prevElement + nextElement)
                {
                    if (nextIndex <= arr.Count - 1)
                    {
                        arr.RemoveAt(nextIndex);
                    }

                    if (prevIndex >= 0)
                    {
                        arr.RemoveAt(prevIndex);
                    }

                    index = 0;
                }

                index++;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
