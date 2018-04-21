using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private IList<string> data;
    private IManager heroManager;

    protected AbstractCommand(IEnumerable<string> data, IManager heroManager)
    {
        this.data = new List<string>(data);
        this.heroManager = heroManager;
    }

    protected IList<string> Data => this.data;

    protected IManager HeroManager => this.heroManager;

    public abstract string Execute();
}
