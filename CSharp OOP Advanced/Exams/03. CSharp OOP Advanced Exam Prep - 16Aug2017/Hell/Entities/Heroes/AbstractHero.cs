using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{    
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private IInventory inventory;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; }

    public long Strength => this.strength + this.inventory.TotalStrengthBonus;

    public long Agility => this.agility + this.inventory.TotalAgilityBonus;
    
    public long Intelligence => this.intelligence + this.inventory.TotalIntelligenceBonus;

    public long HitPoints => this.hitPoints + this.inventory.TotalHitPointsBonus; 

    public long Damage => this.damage + this.inventory.TotalDamageBonus; 

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;     

    public long SecondaryStats => this.HitPoints + this.Damage; 

    public ICollection<IItem> Items
    {
        get
        {
            FieldInfo[] fields = this.inventory
                                        .GetType()
                                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                        .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(ItemAttribute)))
                                        .ToArray();

            Dictionary<string, IItem> commonItems = (Dictionary<string, IItem>)fields[0].GetValue(this.inventory);
            return commonItems.Select(ci => ci.Value).ToList().AsReadOnly();
        }
    }

    public void AddCommonItem(IItem commonItem)
    {
        this.inventory.AddCommonItem(commonItem);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine($"Hero: {this.Name}, Class: {this.GetType()}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count == 0)
        {
            result.AppendLine($"Items: None");
        }
        else
        {
            result.AppendLine($"Items:");

            foreach (IItem item in this.Items)
            {
                result.AppendLine(item.ToString());
            }
        }

        return result.ToString().Trim();
    }
}