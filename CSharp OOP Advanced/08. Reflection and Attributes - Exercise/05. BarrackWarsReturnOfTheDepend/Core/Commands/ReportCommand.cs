public class ReportCommand : Command
{
    [Inject]
    private IRepository repository;

    public ReportCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        return this.repository.Statistics;
    }
}
