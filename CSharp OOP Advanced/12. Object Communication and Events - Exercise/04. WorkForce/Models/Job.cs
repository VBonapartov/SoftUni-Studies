public delegate void JobDoneEventHandler(object sender, JobEventArgs args);

public class Job : IJob
{
    private int hoursOfWorkRequired;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        this.Name = name;
        this.RequiredHoursOfWork = hoursOfWorkRequired;
        this.Employee = employee;
    }

    public event JobDoneEventHandler JobDone;

    public string Name { get; private set; }

    public int RequiredHoursOfWork
    {
        get
        {
            return this.hoursOfWorkRequired;
        }

        private set
        {
            this.hoursOfWorkRequired = value;
            if (value <= 0)
            {
                this.hoursOfWorkRequired = 0;
                this.OnJobDone();
            }
        }
    }

    public IEmployee Employee { get; private set; }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.RequiredHoursOfWork}";
    }

    public void Update()
    {
        this.RequiredHoursOfWork -= this.Employee.WorkHoursPerWeek;
    }

    private void OnJobDone()
    {
        this.JobDone?.Invoke(this, new JobEventArgs(this));
    }
}
