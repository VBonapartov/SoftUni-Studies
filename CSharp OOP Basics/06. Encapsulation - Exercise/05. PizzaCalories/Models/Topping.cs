using System;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int DEFAULT_MULTIPLIER = 2;

    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }

        set
        {
            if ((!value.ToLower().Equals("meat") && !value.ToLower().Equals("veggies") && !value.ToLower().Equals("cheese") && !value.ToLower().Equals("sauce")) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }

            this.weight = value;
        }
    }

    public double CalculateCalories()
    {
        double modifier = 0;

        double result = DEFAULT_MULTIPLIER * this.Weight;
        switch (this.Type.ToLower())
        {
            case "meat":
                modifier = 1.2;
                break;

            case "veggies":
                modifier = 0.8;
                break;

            case "cheese":
                modifier = 1.1;
                break;

            case "sauce":
                modifier = 0.9;
                break;
        }

        result *= modifier;

        return result;
    }
}