public class Rebel : Buyer
{
    private string group;

    public Rebel(string name, int age, string group)
        : base(name, age, "Unknown", "Unknown")
    {    
        this.Group = group;
    }

    public string Group
    {
        get { return this.group; }
        private set { this.group = value; }
    }

    public override void BuyFood()
    {
        this.Food += 5;
    }
}