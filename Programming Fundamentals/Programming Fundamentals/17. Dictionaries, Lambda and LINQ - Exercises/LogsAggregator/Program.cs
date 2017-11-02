using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, HashSet<string>> logInfo = new SortedDictionary<string, HashSet<string>>();
            SortedDictionary<string, int> logDuration = new SortedDictionary<string, int>();
            for (int i = 1; i <= n; i++)
            {
                string[] info = Console.ReadLine().Trim().Split(' ');

                string ip = info[0];
                string user = info[1];
                int duration = Convert.ToInt32(info[2]);

                if (logInfo.ContainsKey(user))
                {
                    logInfo[user].Add(ip);
                    logDuration[user] += duration;
                }
                else
                {
                    logInfo.Add(user, new HashSet<string>() { ip });
                    logDuration.Add(user, duration);
                }
            }

            PrintLog(logInfo, logDuration);
        }

        static private void PrintLog(SortedDictionary<string, HashSet<string>> logInfo, SortedDictionary<string, int> logDuration)
        {
            foreach(KeyValuePair<string, HashSet<string>> info in logInfo)
            {
                string user = info.Key;
                int duration = logDuration[user];
                string ipAddresses = string.Join(", ", info.Value.OrderBy(x => x));

                Console.WriteLine($"{user}: {duration} [{ipAddresses}]");
            }
        }
    }
}
