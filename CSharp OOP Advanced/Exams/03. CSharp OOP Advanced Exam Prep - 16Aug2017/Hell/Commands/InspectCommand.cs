using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IEnumerable<string> data, IManager heroManager)
        : base(data, heroManager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroManager.Inspect(this.Data);
        return result;
    }
}
