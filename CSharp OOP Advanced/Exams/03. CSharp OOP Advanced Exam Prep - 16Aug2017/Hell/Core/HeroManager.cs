using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type typeOfHero = Type.GetType(heroType);
            ConstructorInfo[] constructors = typeOfHero.GetConstructors();
            object[] heroParams = new object[] { heroName };

            IHero hero = (IHero)constructors[0].Invoke(heroParams);

            this.heroes[hero.Name] = hero;
            result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddCommonItem(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        try
        {
            Type commonItemType = typeof(CommonItem);
            object[] commonItemParams = new object[] { itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus };

            IItem commonItem = (IItem)Activator.CreateInstance(commonItemType, commonItemParams);
            this.heroes[heroName].AddCommonItem(commonItem);

            result = string.Format(Constants.ItemCreateMessage, commonItem.Name, heroName);          
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddRecipeItem(IList<string> arguments)
    {
        string result = null;

        string recipeName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        var requiredItems = arguments.Skip(7).ToList();

        try
        {
            IRecipe recipe = new RecipeItem(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
            this.heroes[heroName].AddRecipe(recipe);

            result = string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        if (!this.heroes.ContainsKey(heroName))
        {
            return string.Empty;
        }

        return this.heroes[heroName].ToString();
    }

    public string Quit()
    {
        List<IHero> sortedHeroes = this.heroes
                                            .Select(h => h.Value)
                                            .OrderByDescending(h => h.PrimaryStats)
                                            .ThenByDescending(h => h.SecondaryStats)
                                            .ToList();

        StringBuilder result = new StringBuilder();

        int counter = 1;
        foreach (IHero hero in sortedHeroes)
        {
            string items = "None";

            if (hero.Items.Count != 0)
            {
                items = string.Join(", ", hero.Items.Select(i => i.Name));
            }

            result
                .AppendLine($"{counter++}. {hero.GetType()}: {hero.Name}")
                .AppendLine($"###HitPoints: {hero.HitPoints}")
                .AppendLine($"###Damage: {hero.Damage}")
                .AppendLine($"###Strength: {hero.Strength}")
                .AppendLine($"###Agility: {hero.Agility}")
                .AppendLine($"###Intelligence: {hero.Intelligence}")
                .AppendLine($"###Items: {items}");
        }

        return result.ToString().Trim();
    }  
}