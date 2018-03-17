using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps, IEnumerable<IRepair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<IRepair>(repairs);
    }

    public IReadOnlyList<IRepair> Repairs { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Repairs:")
            .Append(string.Join($"  {Environment.NewLine}", this.Repairs.Select(r => $"  {r.ToString()}")));

        return sb.ToString().Trim();
    }
}