using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly AmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitionQuantites;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionQuantites = new Dictionary<string, int>();        
    }

    public void AddAmmunitions(string name, int quantity)
    {
        if (!this.ammunitionQuantites.ContainsKey(name))
        {
            this.ammunitionQuantites[name] = 0;
        }

        this.ammunitionQuantites[name] += quantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquipped = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        foreach (string weaponName in missingWeapons)
        {
            if (this.ammunitionQuantites.ContainsKey(weaponName) && this.ammunitionQuantites[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitionQuantites[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}