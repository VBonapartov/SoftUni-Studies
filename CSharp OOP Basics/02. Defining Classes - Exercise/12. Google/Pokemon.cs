public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public string Name
    {
        get { return this.name; }
    }

    public string Type
    {
        get { return this.type; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}