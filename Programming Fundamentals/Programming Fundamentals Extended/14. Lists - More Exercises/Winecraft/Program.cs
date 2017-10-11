using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winecraft
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> grapes = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int growthDays = int.Parse(Console.ReadLine());

            // ...until our list contains less than N grapes with value more than N
            do
            {
                for (int round = 1; round <= growthDays; round++)
                {
                    HashSet<int> indexOfChangeGrapes = new HashSet<int>();
                    for (int i = 1; i < grapes.Count - 1; i++)   // exclude first and last element
                    {
                        // Find grapes which value is greater than the grape to its left and right
                        if (grapes[i - 1] < grapes[i] && grapes[i] > grapes[i + 1])
                        {
                            grapes[i]++;

                            if (grapes[i - 1] > 0)
                            {
                                grapes[i]++;
                                grapes[i - 1]--;
                            }

                            if (grapes[i + 1] > 0)
                            {
                                grapes[i]++;
                                grapes[i + 1]--;
                            }

                            // Аdding the indexes that have already been modified
                            indexOfChangeGrapes.Add(i - 1);
                            indexOfChangeGrapes.Add(i);
                            indexOfChangeGrapes.Add(i + 1);
                        }
                    }

                    // Increment the remaining items(> 0)
                    for (int i = 0; i < grapes.Count; i++)
                    {
                        if ((!indexOfChangeGrapes.Contains(i)) && (grapes[i] > 0))
                        {
                            grapes[i]++;
                        }
                    }
                }

                // Remove grapes less or equal to growthDays
                grapes = grapes.Select(x => { if (x < growthDays) return 0; return x; }).ToList();

            } while (grapes.Count(x => x > growthDays) >= growthDays);

            // Print result
            Console.WriteLine(string.Join(" ", grapes.Where(x => x > growthDays)));
        }
    }
}
