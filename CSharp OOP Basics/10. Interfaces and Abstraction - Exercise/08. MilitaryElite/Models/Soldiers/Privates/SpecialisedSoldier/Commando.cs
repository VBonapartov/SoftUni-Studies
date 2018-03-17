using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, IEnumerable<IMission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<IMission>(missions);
    }

    public IReadOnlyList<IMission> Missions { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Missions:")
            .Append("  ")
            .Append(string.Join($"  {Environment.NewLine}", this.Missions.Select(m => $"  {m.ToString()}")));

        return sb.ToString().Trim();
    }
}