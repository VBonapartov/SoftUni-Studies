using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IEnumerable<string> data, IManager heroManager)
        : base(data, heroManager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroManager.AddCommonItem(this.Data);
        return result;
    }
}
