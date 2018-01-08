namespace _04.Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = ReadDwarfsData();
            PrintDwarfs(dwarfs);
        }

        private static Dictionary<string, int> ReadDwarfsData()
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Once upon a time"))
            {
                string[] dwarfData = input.Split(new[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = dwarfData[0];
                string dwarfHatColor = dwarfData[1];
                int dwarfPhysics = int.Parse(dwarfData[2]);

                string uniqueDwarf = dwarfName + ":" + dwarfHatColor;

                if (!dwarfs.ContainsKey(uniqueDwarf))
                {
                    dwarfs.Add(uniqueDwarf, dwarfPhysics);
                }
                else
                {
                    dwarfs[uniqueDwarf] = Math.Max(dwarfs[uniqueDwarf], dwarfPhysics);
                }
            }

            return dwarfs;
        }

        private static void PrintDwarfs(Dictionary<string, int> dwarfs)
        {
            var result = dwarfs
                            .OrderByDescending(dw => dw.Value)
                            .ThenByDescending(x => dwarfs
                                                    .Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                                                    .Count()
                                             )
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (KeyValuePair<string, int> dwarf in result)
            {
                string dwarfName = dwarf.Key.Split(':')[0];
                string dwarfHatColor = dwarf.Key.Split(':')[1];

                Console.WriteLine($"({dwarfHatColor}) {dwarfName} <-> {dwarf.Value}");
            }
        }
    }
}
