using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {            
            Dictionary<string, Dictionary<string, long>> dataSetsInfo = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("thetinggoesskrra"))
            {
                string[] commandArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                AddDataSetInfo(dataSetsInfo, cache, commandArgs);
            }

            PrintDataSets(dataSetsInfo);
        }

        private static void AddDataSetInfo(Dictionary<string, Dictionary<string, long>> dataSetsInfo, Dictionary<string, Dictionary<string, long>> cache, string[] commandArgs)
        {
            if (commandArgs.Length == 1)
            {
                string dataSet = commandArgs[0];

                if (!dataSetsInfo.ContainsKey(dataSet))
                {
                    dataSetsInfo.Add(dataSet, new Dictionary<string, long> { });
                    AddKeysAndValuesFromCacheIfExists(dataSetsInfo, cache, dataSet);
                }

            }
            else if (commandArgs.Length == 2)
            {
                string[] tokens = commandArgs[1].Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                string dataSet = tokens[1];
                string dataKey = commandArgs[0];
                int dataSize = int.Parse(tokens[0]);

                if (dataSetsInfo.ContainsKey(dataSet))
                {
                    if (!dataSetsInfo[dataSet].ContainsKey(dataKey))
                    {
                        dataSetsInfo[dataSet].Add(dataKey, dataSize);
                    }
                }
                else
                {
                    AddKeyAndValueToCache(cache, dataSet, dataKey, dataSize);
                }
            }
        }

        private static void AddKeysAndValuesFromCacheIfExists(Dictionary<string, Dictionary<string, long>> dataSetsInfo, Dictionary<string, Dictionary<string, long>> cache, string dataSet)
        {
            if (cache.ContainsKey(dataSet))
            {
                foreach (KeyValuePair<string, long> keyAndSize in cache[dataSet])
                {
                    dataSetsInfo[dataSet].Add(keyAndSize.Key, keyAndSize.Value);
                }

                cache.Remove(dataSet);
            }
        }

        private static void AddKeyAndValueToCache(Dictionary<string, Dictionary<string, long>> cache, string dataSet, string dataKey, int dataSize)
        {
            if (!cache.ContainsKey(dataSet))
            {
                cache.Add(dataSet, new Dictionary<string, long> { });
            }

            if (!cache[dataSet].ContainsKey(dataKey))
            {
                cache[dataSet].Add(dataKey, dataSize);
            }
        }

        private static void PrintDataSets(Dictionary<string, Dictionary<string, long>> dataSetsInfo)
        {
            if (dataSetsInfo.Count == 0)
            {
                return;
            }

            Dictionary<string, Dictionary<string, long>> dataSetWithHighestDataSize = dataSetsInfo
                                                                                 .OrderByDescending(s => s.Value.Sum(k => k.Value))
                                                                                 .Take(1)
                                                                                 .ToDictionary(s => s.Key, s => s.Value);

            string dataSet = dataSetWithHighestDataSize.Select(s => s.Key).First();
            long sumOfAllDataSizes = dataSetWithHighestDataSize.Select(s => s.Value.Sum(k => k.Value)).First();

            Console.WriteLine($"Data Set: {dataSet}, Total Size: {sumOfAllDataSizes}");
            foreach(KeyValuePair<string, long> dataKey in dataSetWithHighestDataSize[dataSet])
            {
                Console.WriteLine($"$.{dataKey.Key}");
            }
        }
    }
}
