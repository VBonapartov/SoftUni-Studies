﻿using System.Text;

public class CommonItem : IItem
{
    private string name;
    private int strengthBonus;
    private int agilityBonus;
    private int intelligenceBonus;
    private int hitPointsBonus;
    private int damageBonus;

    public CommonItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        this.name = name;
        this.strengthBonus = strengthBonus;
        this.agilityBonus = agilityBonus;
        this.intelligenceBonus = intelligenceBonus;
        this.hitPointsBonus = hitPointsBonus;
        this.damageBonus = damageBonus;
    }

    public string Name => this.name;

    public int StrengthBonus => this.strengthBonus;

    public int AgilityBonus => this.agilityBonus;

    public int IntelligenceBonus => this.intelligenceBonus;

    public int HitPointsBonus => this.hitPointsBonus;

    public int DamageBonus => this.damageBonus;

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine($"###Item: {this.Name}")
            .AppendLine($"###+{this.StrengthBonus} Strength")
            .AppendLine($"###+{this.AgilityBonus} Agility")
            .AppendLine($"###+{this.IntelligenceBonus} Intelligence")
            .AppendLine($"###+{this.HitPointsBonus} HitPoints")
            .AppendLine($"###+{this.DamageBonus} Damage");

        return result.ToString().Trim();
    }
}