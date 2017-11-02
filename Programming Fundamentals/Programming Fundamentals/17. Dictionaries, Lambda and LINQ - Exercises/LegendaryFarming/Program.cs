using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>() { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();

            bool isWinRace = false;
            string winMaterial = string.Empty;
            while (!isWinRace)
            {
                string[] input = Console.ReadLine().Trim().ToLower().Split(' ');

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];

                    if (material.Equals("shards") || material.Equals("fragments") || material.Equals("motes"))
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] = keyMaterials[material] - 250;

                            isWinRace = true;
                            winMaterial = material;

                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }

            PrintObtainedItem(winMaterial);
            PrintKeyMaterials(keyMaterials);
            PrintJunkMaterials(junkMaterials);
        }

        static private void PrintObtainedItem(string winMaterial)
        {
            string winner = string.Empty;
            switch (winMaterial)
            {
                case "shards":
                    winner = "Shadowmourne";
                    break;
                case "fragments":
                    winner = "Valanyr";
                    break;
                case "motes":
                    winner = "Dragonwrath";
                    break;
            }

            Console.WriteLine($"{winner} obtained!");
        }

        static private void PrintKeyMaterials(SortedDictionary<string, int> keyMaterials)
        {
            while (keyMaterials.Count > 0)
            {
                KeyValuePair<string, int> currentMaterialInfo = keyMaterials.ElementAt(0);

                string material = currentMaterialInfo.Key;
                int quantity = currentMaterialInfo.Value;

                for (int p = 0; p < keyMaterials.Count; p++)
                {
                    KeyValuePair<string, int> materialInfo = keyMaterials.ElementAt(p);
                    if (materialInfo.Value > quantity)
                    {
                        material = materialInfo.Key;
                        quantity = materialInfo.Value;
                    }
                }

                keyMaterials.Remove(material);
                Console.WriteLine($"{material}: {quantity}");
            }
        }

        static private void PrintJunkMaterials(SortedDictionary<string, int> junkMaterials)
        {
            foreach(KeyValuePair<string, int> junkMaterialInfo in junkMaterials)
            {
                Console.WriteLine($"{junkMaterialInfo.Key}: {junkMaterialInfo.Value}");
            }            
        }
    }
}
