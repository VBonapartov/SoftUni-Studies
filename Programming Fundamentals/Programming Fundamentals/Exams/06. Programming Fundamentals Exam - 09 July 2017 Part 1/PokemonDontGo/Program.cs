using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> distances = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            long sumRemovedElements = 0;
            while (distances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                long removedElement = RemoveElement(distances, index);
                sumRemovedElements += removedElement;
                distances = IncreaseOrDecreaseElements(distances, removedElement);                
            }

            Console.WriteLine(sumRemovedElements);
        }

        private static long RemoveElement(List<long> distances, int index)
        {
            long removedElement = 0;
            if (index < 0)
            {
                long lastElement = distances[distances.Count - 1];
                removedElement = distances[0];
                distances.RemoveAt(0);
                distances.Insert(0, lastElement);
            }
            else if (index > distances.Count - 1)
            {
                long firstElement = distances[0];
                removedElement = distances[distances.Count - 1];
                distances.RemoveAt(distances.Count - 1);
                distances.Add(firstElement);
            }
            else
            {
                removedElement = distances[index];
                distances.RemoveAt(index);
            }

            return removedElement;
        }

        private static List<long> IncreaseOrDecreaseElements(List<long> distances, long value)
        {
            return distances
                            .Select(i =>
                                        {
                                            if(i <= value)
                                                return i + value;
                                            else
                                                return i - value;
                                         }
                                    )
                             .ToList();
        }
    }
}
