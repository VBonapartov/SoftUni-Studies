public class Citizen : Buyer
{
    public Citizen(string name, int age, string id, string birthDate) 
        : base(name, age, id, birthDate)
    {
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}