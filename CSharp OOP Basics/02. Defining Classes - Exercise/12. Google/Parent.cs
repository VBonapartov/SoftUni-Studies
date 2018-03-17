public class Parent
{
    private string name;
    private string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public string Name
    {
        get { return this.name; }
    }

    public string Birthday
    {
        get { return this.birthday; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}