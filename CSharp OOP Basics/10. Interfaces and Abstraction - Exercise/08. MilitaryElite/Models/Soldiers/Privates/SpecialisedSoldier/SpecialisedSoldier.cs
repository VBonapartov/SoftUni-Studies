using System;
using System.Linq;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private readonly string[] possibleCorps = new string[] { "Airforces", "Marines" };

    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get
        {
            return this.corps;
        }

        private set
        {
            if (!this.possibleCorps.Contains(value))
            {
                throw new ArgumentException("Invalid Corps");
            }

            this.corps = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps}");

        return sb.ToString().Trim();
    }
}