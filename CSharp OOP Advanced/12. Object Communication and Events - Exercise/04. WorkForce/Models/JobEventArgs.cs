using System;

public class JobEventArgs : EventArgs
{
    public JobEventArgs(IJob job)
    {
        this.Job = job;
    }

    public IJob Job { get; }
}
