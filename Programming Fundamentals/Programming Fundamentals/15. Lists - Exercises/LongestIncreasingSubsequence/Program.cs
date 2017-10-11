using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            int[] len = new int[sequence.Count];
            int[] prev = new int[sequence.Count];

            int maxLen = 0;
            int lastIndex = -1;
            for(int x = 0; x < sequence.Count; x++)
            {
                len[x] = 1;
                prev[x] = -1;
                for(int i = 0; i <= x - 1; i++)
                {
                    if (sequence[i] < sequence[x] && len[i] + 1 > len[x])
                    {
                        len[x] = 1 + len[i];
                        prev[x] = i;
                    }
                }

                if(len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            List<int> longestSeq = RestoreLIS(sequence, prev, lastIndex);
            Console.WriteLine(string.Join(" ", longestSeq));
        }

        static private List<int> RestoreLIS(List<int> sequence, int[] prev, int lastIndex)
        {
            List<int> longestSeq = new List<int>();

            while(lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();
            return longestSeq;
        }
    }
}
