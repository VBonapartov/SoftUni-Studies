public abstract class Buyer : IPerson, IBuyer
{
    public Buyer(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
        this.Food = 0;
    }

    public string Name
    {
        get;
        private set;
    }

    public int Age
    {
        get;
        private set;
    }

    public string Id
    {
        get;
        private set;
    }

    public string BirthDate
    {
        get;
        private set;
    }

    public int Food { get; protected set; }

    public abstract void BuyFood();
}