using System;

public class PriceCalculator
{
    private decimal pricePerNight;
    private int nights;
    private SeasonsMultiplier seasonsMultiplier;
    private Discounts discount;

    public PriceCalculator(string command)
    {
        string[] splitCommand = command.Split(" ");

        this.pricePerNight = decimal.Parse(splitCommand[0]);
        this.nights = int.Parse(splitCommand[1]);
        this.seasonsMultiplier = Enum.Parse<SeasonsMultiplier>(splitCommand[2]);
        this.discount = Discounts.None;

        if (splitCommand.Length > 3)
        {
            this.discount = Enum.Parse<Discounts>(splitCommand[3]);
        }
    }

    public string CalculatePrice()
    {
        decimal tempTotal = this.pricePerNight * this.nights * (int)this.seasonsMultiplier;
        decimal discountPercentage = ((decimal)100 - (int)this.discount) / 100;
        decimal totalPrice = tempTotal * discountPercentage;

        return totalPrice.ToString("F2");
    }
}