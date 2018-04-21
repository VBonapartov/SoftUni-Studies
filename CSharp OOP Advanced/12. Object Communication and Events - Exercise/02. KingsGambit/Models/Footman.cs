using System;

public class Footman : Soldier
{
    public Footman(string name, IWriter writer)
        : base(name, writer)
    {
    }

    public override void KingUnderAttack(object sender, EventArgs e)
    {
        this.Writer.WriteLine($"Footman {this.Name} is panicking!");
    }
}
