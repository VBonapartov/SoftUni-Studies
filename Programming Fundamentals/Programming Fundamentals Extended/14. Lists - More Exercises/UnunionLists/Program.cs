using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnunionLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primalList = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                List<int> currentNums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

                // Variant 1
                //result = primalList.Where(x => !currentNums.Contains(x)).ToList();
                //currentNums.RemoveAll(x => primalList.Contains(x));
                //result.AddRange(currentNums);

                //primalList.Clear();
                //primalList.AddRange(result);
                //result.Clear();

                // Variant 2
                primalList = primalList.Except(currentNums).Union(currentNums.Except(primalList)).ToList();
            }

            primalList.Sort();
            Console.WriteLine(string.Join(" ", primalList));
        }
    }
}
