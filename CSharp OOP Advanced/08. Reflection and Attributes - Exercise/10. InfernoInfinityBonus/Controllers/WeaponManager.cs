using System.Collections.Generic;
using System.Linq;

public class WeaponManager
{
    private IList<Weapon> weapons;
    private WeaponFactory weaponFactory;

    public WeaponManager()
    {
        this.weapons = new List<Weapon>();
        this.weaponFactory = new WeaponFactory();
    }

    public void CreateWeapon(string weaponType, string weaponName, string weaponRarity)
    {
        Weapon weapon = this.weaponFactory.Create(weaponType, weaponName, weaponRarity);

        if (weapon != null)
        {
            this.weapons.Add(weapon);
        }
    }

    public Weapon GetWeapon(string weaponName)
    {
        return this.weapons.FirstOrDefault(w => w.WeaponName.Equals(weaponName));
    }

    public void AddGemToWeapon(string weaponName, int socketNumber, Gem gem)
    {
        Weapon weapon = this.GetWeapon(weaponName);

        if (weapon != null)
        {
            weapon.AddGem(gem, socketNumber);
        }
    }

    public void RemoveGemFromWeapon(string weaponName, int socketNumber)
    {
        Weapon weapon = this.GetWeapon(weaponName);

        if (weapon != null)
        {
            weapon.RemoveGem(socketNumber);
        }
    }
}