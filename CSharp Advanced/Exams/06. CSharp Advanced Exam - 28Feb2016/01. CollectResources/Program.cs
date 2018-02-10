namespace _01.CollectResources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[] ValidResources = new string[] { "stone", "gold", "wood", "food" };

        static void Main(string[] args)
        {
            string[] resourceField = GetResourceFiled();
            CollectResources(resourceField);
        }

        private static string[] GetResourceFiled()
        {
            return Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void CollectResources(string[] resourceField)
        {
            int numberOfCollectionPaths = int.Parse(Console.ReadLine());

            int maxQuantity = int.MinValue;            

            for(int i = 0; i < numberOfCollectionPaths; i++)
            {
                int[] cmdArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int index = cmdArgs[0];
                int step = cmdArgs[1];

                int totalQuantity = 0;
                List<int> collectedResourcesIndices = new List<int>();

                while (!collectedResourcesIndices.Contains(index))
                {  
                    string[] resourceParams = resourceField[index].Split('_');
                    string resourceName = resourceParams[0];
                    int quantity = 1;

                    if (resourceParams.Length == 2)
                    {
                        quantity = int.Parse(resourceParams[1]);
                    }                                       

                    if (IsResourceValid(resourceName))
                    {
                        totalQuantity += quantity;
                        collectedResourcesIndices.Add(index);
                    }

                    index = (index + step) % resourceField.Length;
                }

                if(totalQuantity > maxQuantity)
                {
                    maxQuantity = totalQuantity;
                }
            }

            Console.WriteLine(maxQuantity);
        }

        private static bool IsResourceValid(string resourceName)
        {
            return ValidResources.Contains(resourceName);
        }
    }
}
