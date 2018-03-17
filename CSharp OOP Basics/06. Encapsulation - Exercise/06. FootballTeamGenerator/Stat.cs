using System;

public class Stat
{
    private string name;
    private int statValue;

    public Stat(string name, int statValue)
    {
        this.Name = name;
        this.StatValue = statValue;
    }

    public int StatValue
    {
        get
        {
            return this.statValue;
        }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{this.Name} should be between 0 and 100.");
            }

            this.statValue = value;
        }
    }

    private string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
}