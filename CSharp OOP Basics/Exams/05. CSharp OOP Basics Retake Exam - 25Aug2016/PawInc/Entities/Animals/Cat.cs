public class Cat : Animal
{
    private int intelligenceCoefficient;

    public Cat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
        : base(name, age, adoptionCenterName)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient
    {
        get => this.intelligenceCoefficient;
        private set { this.intelligenceCoefficient = value; }
    }
}
