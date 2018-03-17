using System;

public abstract class Animal
{
    private string animalName;
    private double animalWeight;
    private int foodEaten;

    protected Animal(string animalName, double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = 0;
    }

    protected virtual double WeightIncreaseMultiplier => 1;

    protected virtual Type[] PreferredFoods => new Type[] { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

    protected string AnimalName
    {
        get { return this.animalName; }
        private set { this.animalName = value; }
    }

    protected double AnimalWeight
    {
        get { return this.animalWeight; }
        set { this.animalWeight = value; }
    }

    protected int FoodEaten
    {
        get { return this.foodEaten; }
        set { this.foodEaten = value; }
    }

    public abstract string MakeSound();

    public void TryEatFood(Food food)
    {
        int pos = Array.IndexOf(this.PreferredFoods, food.GetType());

        if (pos > -1)
        {
            this.FoodEaten += food.Quantity;
            this.AnimalWeight += food.Quantity * this.WeightIncreaseMultiplier;
        }
        else
        {
            throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}