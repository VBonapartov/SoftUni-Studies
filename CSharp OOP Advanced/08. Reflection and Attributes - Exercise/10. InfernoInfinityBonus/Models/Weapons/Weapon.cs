using System.Linq;

public abstract class Weapon
{
    protected Weapon(string weaponName, WeaponRarity levelOfRarity, int minDamage, int maxDamage, int numberOfSockets)
    {
        this.WeaponName = weaponName;
        this.LevelOfRarity = levelOfRarity;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.Gems = new Gem[numberOfSockets];
    }

    public string WeaponName { get; private set; }

    public WeaponRarity LevelOfRarity { get; private set; }

    public int MinDamage { get; private set; }

    public int MaxDamage { get; private set; }

    public Gem[] Gems { get; private set; }
    
    public void AddGem(Gem gem, int socketNumber)
    {
        if (socketNumber < 0 || socketNumber > this.Gems.Length - 1)
        {
            return;
        }

        this.Gems[socketNumber] = gem;
    }

    public void RemoveGem(int socketNumber)
    {
        if (socketNumber < 0 || socketNumber > this.Gems.Length - 1)
        {
            return;
        }

        this.Gems[socketNumber] = null;
    }

    public override string ToString()
    {
        int strength = this.Gems.Where(g => g != null).Sum(g => g.Strength);
        int agility = this.Gems.Where(g => g != null).Sum(g => g.Agility);
        int vitality = this.Gems.Where(g => g != null).Sum(g => g.Vitality);

        this.MinDamage = (this.MinDamage * (int)this.LevelOfRarity) + (strength * 2) + agility;
        this.MaxDamage = (this.MaxDamage * (int)this.LevelOfRarity) + (strength * 3) + (agility * 4);

        return $"{this.WeaponName}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}