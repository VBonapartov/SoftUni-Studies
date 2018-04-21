using System;

public abstract class Soldier
{
    private int hitsTaken;

    public Soldier(string name, int hitsTaken, IWriter writer)
    {
        this.Name = name;
        this.hitsTaken = hitsTaken;
        this.Writer = writer;
    }

    public event EventHandler<KillEventArgs> SoldierKilled;

    public string Name { get; private set; }

    protected IWriter Writer { get; private set; }

    public abstract void KingUnderAttack(object sender, EventArgs e);

    public void TakeAttack()
    {
        this.hitsTaken--;

        if (this.hitsTaken <= 0)
        {
            this.OnSoldierKilled();
        }
    }

    private void OnSoldierKilled()
    {
        this.SoldierKilled?.Invoke(this, new KillEventArgs(this));
    }
}
