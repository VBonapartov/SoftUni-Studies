public class Citizen : IPerson
{
    private string id;

    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
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
        get { return this.id; }
        private set { this.id = value; }
    }
}