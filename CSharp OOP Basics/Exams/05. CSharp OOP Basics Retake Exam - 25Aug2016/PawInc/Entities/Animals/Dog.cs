public class Dog : Animal
{
    private int amountOfCommands;

    public Dog(string name, int age, int amountOfCommands, string adoptionCenterName)
        : base(name, age, adoptionCenterName)
    {
        this.AmountOfCommands = amountOfCommands;
    }

    public int AmountOfCommands
    {
        get => this.amountOfCommands;
        private set { this.amountOfCommands = value; }
    }
}
