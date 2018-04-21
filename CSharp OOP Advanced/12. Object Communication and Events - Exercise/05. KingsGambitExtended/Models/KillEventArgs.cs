using System;

public class KillEventArgs : EventArgs
{
    public KillEventArgs(Soldier soldier)
    {
        this.Soldier = soldier;
    }

    public Soldier Soldier { get; }
}
