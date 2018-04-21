using System;

public class King
{
    private IWriter writer;

    public King(string name, IWriter writer)
    {
        this.Name = name;
        this.writer = writer;
    }

    public event EventHandler UnderAttack;

    public string Name { get; private set; }

    public void OnUnderAttack()
    {
        this.writer.WriteLine($"King {this.Name} is under attack!");
        this.UnderAttack?.Invoke(this, new EventArgs());
    }
}
