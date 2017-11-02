using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> trains = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("It's Training Men!"))
            {
                string trainName = string.Empty;
                string wagonName = string.Empty;
                string otherTrainName = string.Empty;
                int wagonPower = 0;
                
                if (input.IndexOf(" -> ") != -1)
                {
                    string[] commandArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    trainName = commandArgs[0];

                    if(commandArgs[1].IndexOf(" : ") != -1)
                    {
                        string[] wagonParams = commandArgs[1].Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                        wagonName = wagonParams[0];
                        wagonPower = Convert.ToInt32(wagonParams[1]);

                        CreateTrain(trains, trainName, wagonName, wagonPower);
                    }
                    else
                    {
                        otherTrainName = commandArgs[1];
                        AddWagonsFromOneToAnotherTrain(trains, trainName, otherTrainName);
                    }
                }
                else if(input.IndexOf(" = ") != -1)
                {
                    string[] commandArgs = input.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                    trainName = commandArgs[0];
                    otherTrainName = commandArgs[1];

                    CopyWagonsFromOneToAnotherTrain(trains, trainName, otherTrainName);
                }
            }

            PrintTrains(trains);
        }

        private static void CreateTrain(Dictionary<string, Dictionary<string, int>> trains, string trainName, string wagonName, int wagonPower)
        {
            if(!trains.ContainsKey(trainName))
            {
                trains.Add(trainName, new Dictionary<string, int> { });
            }

            if(!trains[trainName].ContainsKey(wagonName))
            {
                trains[trainName].Add(wagonName, wagonPower);
            }
        }

        private static void AddWagonsFromOneToAnotherTrain(Dictionary<string, Dictionary<string, int>> trains, string trainName, string otherTrainName)
        {
            if (!trains.ContainsKey(otherTrainName))
            {
                return;
            }

            if (!trains.ContainsKey(trainName))
            {
                trains.Add(trainName, new Dictionary<string, int> { });
            }

            foreach(KeyValuePair<string, int> wagon in trains[otherTrainName])
            {
                if(!trains[trainName].ContainsKey(wagon.Key))
                {
                    trains[trainName].Add(wagon.Key, wagon.Value);
                }
            }

            trains.Remove(otherTrainName);
        }

        private static void CopyWagonsFromOneToAnotherTrain(Dictionary<string, Dictionary<string, int>> trains, string trainName, string otherTrainName)
        {
            if (!trains.ContainsKey(otherTrainName))
            {
                return;
            }

            if (!trains.ContainsKey(trainName))
            {
                trains.Add(trainName, new Dictionary<string, int> { });
            }

            trains[trainName].Clear();
            trains[trainName] = new Dictionary<string, int>(trains[otherTrainName]);
        }

        private static void PrintTrains(Dictionary<string, Dictionary<string, int>> trains)
        {
            Dictionary<string, Dictionary<string, int>> sortedTrains = trains
                                                                            .OrderByDescending(t => t.Value.Values.Sum())
                                                                            .ThenBy(t => t.Value.Count)
                                                                            .ToDictionary(t => t.Key, t => t.Value);

            foreach(KeyValuePair<string, Dictionary<string, int>> train in sortedTrains)
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach(KeyValuePair<string, int> wagon in train.Value.OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
