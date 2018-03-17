public abstract class Monument : IMonument
{
    private string name;
    private long affinity;

    protected Monument(string name, long affinity)
    {
        this.Name = name;
        this.Affinity = affinity;
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

    public long Affinity
    {
        get => this.affinity;
        private set { this.affinity = value; }
    }

    public string GetMonumentType()
    {
        string type = this.GetType().Name;
        int endIndex = type.IndexOf("Monument");
        type = type.Substring(0, endIndex);

        return type;
    }

    public override string ToString()
    {
        string result = $"###{this.GetMonumentType()} Monument: {this.Name}, {this.GetMonumentType()} Affinity: {this.Affinity}";
        return result;
    }
}
