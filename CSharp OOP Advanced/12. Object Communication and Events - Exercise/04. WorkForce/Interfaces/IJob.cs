public interface IJob
{
    event JobDoneEventHandler JobDone;

    string Name { get; }

    int RequiredHoursOfWork { get; }

    void Update();
}
