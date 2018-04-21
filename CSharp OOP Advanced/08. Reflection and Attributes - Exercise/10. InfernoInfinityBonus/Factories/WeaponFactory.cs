using System;

public class WeaponFactory
{
    public Weapon Create(string weaponType, string weaponName, string weaponRarity)
    {
        if (!Enum.TryParse(weaponRarity, out WeaponRarity levelOfRarity))
        {
            return null;
        }

        switch (weaponType)
        {
            case "Axe":
                return new Axe(weaponName, levelOfRarity);

            case "Knife":
                return new Knife(weaponName, levelOfRarity);

            case "Sword":
                return new Sword(weaponName, levelOfRarity);

            default:
                throw new ArgumentException($"Invalid weapon type!");
        }
    }
}