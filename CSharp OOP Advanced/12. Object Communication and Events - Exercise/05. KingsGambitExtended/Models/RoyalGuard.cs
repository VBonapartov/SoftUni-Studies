using System;

public class RoyalGuard : Soldier
{
    private const int DefaultHits = 3;

    public RoyalGuard(string name, IWriter writer)
        : base(name, DefaultHits, writer)
    {
    }

    public override void KingUnderAttack(object sender, EventArgs e)
    {
        this.Writer.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
