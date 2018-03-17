public class Citizen : IPerson
{
    private string id;

    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
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

    public string Birthday
    {
        get;
        private set;
    }
}