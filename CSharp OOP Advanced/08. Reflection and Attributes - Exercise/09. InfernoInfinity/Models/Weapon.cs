using System;
using System.Linq;

public class Weapon
{
    private const int AxeMinDamage = 5;
    private const int AxeMaxDamage = 10;
    private const int AxeSockets = 4;

    private const int SwordMinDamage = 4;
    private const int SwordMaxDamage = 6;
    private const int SwordSockets = 3;

    private const int KnifeMinDamage = 3;
    private const int KnifeMaxDamage = 4;
    private const int KnifeSockets = 2;

    private string weaponName;
    private string weaponType;
    private int minDamage;
    private int maxDamage;
    private Gem[] gems;
    private WeaponRarity levelOfRarity;

    public Weapon(string weaponName, string weaponType, string levelOfRarity)
    {
        this.weaponName = weaponName;
        this.weaponType = weaponType;
        this.levelOfRarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), levelOfRarity);

        this.SetBaseStats();
    }

    public string WeaponName => this.weaponName;

    public void AddGem(string gemType, string levelOfQuality, int socketNumber)
    {
        if (socketNumber < 0 || socketNumber > this.gems.Length - 1)
        {
            return;
        }

        Gem gem = new Gem(gemType, levelOfQuality);
        this.gems[socketNumber] = gem;
    }

    public void RemoveGem(int socketNumber)
    {
        if (socketNumber < 0 || socketNumber > this.gems.Length - 1)
        {
            return;
        }

        this.gems[socketNumber] = null;
    }

    public override string ToString()
    {
        this.CalculateWeaponStats();

        int strength = this.gems.Where(g => g != null).Sum(g => g.Strength);
        int agility = this.gems.Where(g => g != null).Sum(g => g.Agility);
        int vitality = this.gems.Where(g => g != null).Sum(g => g.Vitality);

        return $"{this.weaponName}: {this.minDamage}-{this.maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }

    private void SetBaseStats()
    {
        switch (this.weaponType)
        {
            case "Axe":
                this.minDamage = AxeMinDamage;
                this.maxDamage = AxeMaxDamage;
                this.gems = new Gem[AxeSockets];
                break;

            case "Sword":
                this.minDamage = SwordMinDamage;
                this.maxDamage = SwordMaxDamage;
                this.gems = new Gem[SwordSockets];
                break;

            case "Knife":
                this.minDamage = KnifeMinDamage;
                this.maxDamage = KnifeMaxDamage;
                this.gems = new Gem[KnifeSockets];
                break;
        }
    }

    private void CalculateWeaponStats()
    {
        this.minDamage *= (int)this.levelOfRarity;
        this.maxDamage *= (int)this.levelOfRarity;

        foreach (Gem gem in this.gems.Where(g => g != null))
        {
            gem.CalculateGemStats();

            this.minDamage += (gem.Strength * 2) + (gem.Agility * 1);
            this.maxDamage += (gem.Strength * 3) + (gem.Agility * 4);
        }
    }
}