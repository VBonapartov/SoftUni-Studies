using System;

public class Gem
{
    private const int RubyStrength = 7;
    private const int RubyAgility = 2;
    private const int RubyVitality = 5;

    private const int EmeraldStrength = 1;
    private const int EmeraldAgility = 4;
    private const int EmeraldVitality = 9;

    private const int AmethystStrength = 2;
    private const int AmethystAgility = 8;
    private const int AmethystVitality = 4;

    private string gemType;
    private int strength;
    private int agility;
    private int vitality;
    private GemClarity levelOfClarity;

    public Gem(string gemType, string levelOfClarity)
    {
        this.gemType = gemType;
        this.levelOfClarity = (GemClarity)Enum.Parse(typeof(GemClarity), levelOfClarity);

        this.SetBaseStats();
    }

    public int Strength => this.strength;

    public int Agility => this.agility;

    public int Vitality => this.vitality;

    private void SetBaseStats()
    {
        switch (this.gemType)
        {
            case "Ruby":
                this.strength = RubyStrength;
                this.agility = RubyAgility;
                this.vitality = RubyVitality;
                break;

            case "Emerald":
                this.strength = EmeraldStrength;
                this.agility = EmeraldAgility;
                this.vitality = EmeraldVitality;
                break;

            case "Amethyst":
                this.strength = AmethystStrength;
                this.agility = AmethystAgility;
                this.vitality = AmethystVitality;
                break;
        }
    }

    public void CalculateGemStats()
    {
        this.strength += (int)this.levelOfClarity;
        this.agility += (int)this.levelOfClarity;
        this.vitality += (int)this.levelOfClarity;
    }
}