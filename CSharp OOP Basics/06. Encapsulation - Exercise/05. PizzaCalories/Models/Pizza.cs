using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;
    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;

    private string name;
    private Dough dough;
    private IList<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.");
            }

            this.name = value;
        }
    }

    private Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    private IList<Topping> Toppings
    {
        get { return this.toppings; }
        set { this.toppings = value; }
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count < MIN_TOPPINGS || this.Toppings.Count > MAX_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS}..{MAX_TOPPINGS}].");
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories():F2} Calories.";
    }

    private double TotalCalories()
    {
        double totalCalories = this.Dough.CalculateCalories() + this.Toppings.Sum(t => t.CalculateCalories());
        return totalCalories;
    }
}