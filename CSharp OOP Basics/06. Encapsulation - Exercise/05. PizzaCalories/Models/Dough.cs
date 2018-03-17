using System;

public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const int DEFAULT_MULTIPLIER = 2;

    private string flourType;
    private string technique;
    private int weight;

    public Dough(string flourType, string technique, int weight)
    {
        this.FlourType = flourType;
        this.Technique = technique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get
        {
            return this.flourType;
        }

        set
        {
            if ((!value.ToLower().Equals("white") && !value.ToLower().Equals("wholegrain")) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string Technique
    {
        get
        {
            return this.technique;
        }

        set
        {
            if ((!value.ToLower().Equals("crispy") && !value.ToLower().Equals("chewy") && !value.ToLower().Equals("homemade")) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.technique = value;
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
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }

            this.weight = value;
        }
    }

    public double CalculateCalories()
    {
        double modifier = 0;

        double result = DEFAULT_MULTIPLIER * this.Weight;
        switch (this.FlourType.ToLower())
        {
            case "white":
                modifier = 1.5;
                break;

            case "wholegrain":
                modifier = 1.0;
                break;
        }

        result *= modifier;

        switch (this.Technique.ToLower())
        {
            case "crispy":
                modifier = 0.9;
                break;

            case "chewy":
                modifier = 1.1;
                break;

            case "homemade":
                modifier = 1.0;
                break;
        }

        result *= modifier;

        return result;
    }
}