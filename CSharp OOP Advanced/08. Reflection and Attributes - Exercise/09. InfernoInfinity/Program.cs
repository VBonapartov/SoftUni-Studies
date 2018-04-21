namespace _09._InfernoInfinity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Weapon> weapons;

        public static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            weapons = new List<Weapon>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(';');
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Create":
                        CreateNewWeapon(cmdArgs);
                        break;

                    case "Add":
                        AddGem(cmdArgs);
                        break;

                    case "Remove":
                        RemoveGem(cmdArgs);
                        break;

                    case "Print":
                        Print(cmdArgs);
                        break;
                }
            }
        }

        private static void CreateNewWeapon(string[] cmdArgs)
        {
            string weaponName = cmdArgs[2];

            if (weapons.Exists(w => w.WeaponName.Equals(weaponName)))
            {
                return;
            }

            string[] typeAndRarity = cmdArgs[1].Split(' ');
            string weaponType = typeAndRarity[1];
            string levelOfRarity = typeAndRarity[0];

            Weapon weapon = new Weapon(weaponName, weaponType, levelOfRarity);
            weapons.Add(weapon);
        }

        private static void AddGem(string[] cmdArgs)
        {
            string weaponName = cmdArgs[1];

            Weapon weapon = weapons.Where(w => w.WeaponName.Equals(weaponName)).FirstOrDefault();

            if (weapon == null)
            {
                return;
            }

            int socketNumber = int.Parse(cmdArgs[2]);
            string[] typeAndClarity = cmdArgs[3].Split(' ');
            string gemType = typeAndClarity[1];
            string levelOfClarity = typeAndClarity[0];

            weapon.AddGem(gemType, levelOfClarity, socketNumber);
        }

        private static void RemoveGem(string[] cmdArgs)
        {
            string weaponName = cmdArgs[1];
            int socketNumber = int.Parse(cmdArgs[2]);

            Weapon weapon = weapons.Where(w => w.WeaponName.Equals(weaponName)).FirstOrDefault();

            if (weapon == null)
            {
                return;
            }

            weapon.RemoveGem(socketNumber);
        }

        private static void Print(string[] cmdArgs)
        {
            string weaponName = cmdArgs[1];

            Weapon weapon = weapons.Where(w => w.WeaponName.Equals(weaponName)).FirstOrDefault();

            if (weapon == null)
            {
                return;
            }

            Console.WriteLine(weapon);
        }
    }
}
