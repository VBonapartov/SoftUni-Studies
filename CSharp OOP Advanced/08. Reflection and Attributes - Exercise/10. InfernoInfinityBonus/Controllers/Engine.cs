using System;

public class Engine
{
    private WeaponManager manager;
    private GemFactory gemFactory;

    public Engine()
    {
        this.manager = new WeaponManager();
        this.gemFactory = new GemFactory();
    }

    public void Run()
    {
        string input = string.Empty;

        while (!(input = Console.ReadLine()).Equals("END"))
        {
            string[] cmdArgs = input.Split(';');
            string command = cmdArgs[0];

            switch (command)
            {
                case "Create":
                    this.CreateWeapon(cmdArgs);
                    break;

                case "Add":
                    this.AddGemToWeapon(cmdArgs);
                    break;

                case "Remove":
                    this.RemoveGemFromWeapon(cmdArgs);
                    break;

                case "Print":
                    this.Print(cmdArgs);
                    break;

                default:
                    break;
            }
        }
    }

    private void CreateWeapon(string[] cmdArgs)
    {
        string weaponName = cmdArgs[2];
        string[] typeAndKind = cmdArgs[1].Split(' ');
        string weaponType = typeAndKind[1];
        string weaponRarity = typeAndKind[0];

        this.manager.CreateWeapon(weaponType, weaponName, weaponRarity);
    }

    private void AddGemToWeapon(string[] cmdArgs)
    {
        string weaponName = cmdArgs[1];
        int socketNumber = int.Parse(cmdArgs[2]);
        string[] typeAndClarity = cmdArgs[3].Split(' ');
        string clarity = typeAndClarity[0];
        string gemType = typeAndClarity[1];

        Gem gem = this.gemFactory.Create(gemType, clarity);

        if (gem == null)
        {
            return;
        }

        this.manager.AddGemToWeapon(weaponName, socketNumber, gem);
    }

    private void RemoveGemFromWeapon(string[] cmdArgs)
    {
        string weaponName = cmdArgs[1];
        int socketNumber = int.Parse(cmdArgs[2]);

        this.manager.RemoveGemFromWeapon(weaponName, socketNumber);
    }

    private void Print(string[] cmdArgs)
    {
        string weaponName = cmdArgs[1];

        Weapon weapon = this.manager.GetWeapon(weaponName);

        Console.WriteLine((weapon != null) ? weapon.ToString() : string.Empty);
    }
}