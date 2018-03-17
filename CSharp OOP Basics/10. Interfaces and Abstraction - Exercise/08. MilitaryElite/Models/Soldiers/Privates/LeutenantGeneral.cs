using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, IEnumerable<IPrivate> privateSoldiers)
        : base(id, firstName, lastName, salary)
    {
        this.PrivateSoldiers = new List<IPrivate>(privateSoldiers);
    }

    public IReadOnlyList<IPrivate> PrivateSoldiers { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Privates:")
            .Append(string.Join($"  {Environment.NewLine}", this.PrivateSoldiers.Select(s => $"  {s.ToString()}")));

        return sb.ToString().Trim();
    }
}