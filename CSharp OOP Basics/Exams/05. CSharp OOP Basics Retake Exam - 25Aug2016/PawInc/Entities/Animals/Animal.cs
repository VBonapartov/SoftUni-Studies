public abstract class Animal : IAnimal
{
    private string name;
    private int age;
    private string adoptionCenterName;
    private bool cleansingStatus;
    private bool castrationStatus;

    protected Animal(string name, int age, string adoptionCenterName)
    {
        this.Name = name;
        this.Age = age;
        this.CenterName = adoptionCenterName;
        this.CleansingStatus = false;
        this.CastrationStatus = false;
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

    public int Age
    {
        get => this.age;
        private set { this.age = value; }
    }

    public string CenterName
    {
        get => this.adoptionCenterName; 
        protected set { this.adoptionCenterName = value; }
    }

    public bool CleansingStatus
    {
        get => this.cleansingStatus;
        set { this.cleansingStatus = value; }
    }

    public bool CastrationStatus
    {
        get => this.castrationStatus;
        set { this.castrationStatus = value; }
    }
}
