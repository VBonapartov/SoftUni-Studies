namespace _01.CubicArtillery
{
    using System;
    using System.Collections.Generic;

    class Program
    { 
        static void Main(string[] args)
        {
            int bunkersMaxCapacity = int.Parse(Console.ReadLine());

            List<Bunker> bunkers = new List<Bunker>();
            ReadAndProcessData(bunkers, bunkersMaxCapacity);
        }

        private static void ReadAndProcessData(List<Bunker> bunkers, int bunkersMaxCapacity)
        {
            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("Bunker Revision"))
            {
                string[] cmdArgs = input.Split(' ');

                foreach(string element in cmdArgs)
                {
                    int weaponCapacity;

                    if (!int.TryParse(element, out weaponCapacity))
                    {
                        bunkers.Add(new Bunker(element));
                        continue;
                    }
                    else if (bunkers.Count == 1 && weaponCapacity <= bunkersMaxCapacity)
                    {
                        bunkers[0].AddWeapon(weaponCapacity);

                        while (bunkers[0].UsedSpace > bunkersMaxCapacity)
                        {
                            bunkers[0].RemoveWeapon();
                        }
                    }
                    else
                    {
                        for(int i = 0; i < bunkers.Count - 1; i++)
                        {
                            if (bunkers[i].UsedSpace + weaponCapacity <= bunkersMaxCapacity)
                            {
                                bunkers[i].AddWeapon(weaponCapacity);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(bunkers[i]);
                                bunkers.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
        }
    }
}
