using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IEnumerable<string> data, IManager heroManager)
        : base(data, heroManager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroManager.Quit();
        return result;
    }
}