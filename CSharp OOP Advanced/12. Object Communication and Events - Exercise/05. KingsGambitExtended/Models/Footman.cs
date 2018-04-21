using System;

public class Footman : Soldier
{
    private const int DefaultHits = 2;

    public Footman(string name, IWriter writer)
        : base(name, DefaultHits, writer)
    {
    }

    public override void KingUnderAttack(object sender, EventArgs e)
    {
        this.Writer.WriteLine($"Footman {this.Name} is panicking!");
    }
}
