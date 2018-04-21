using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IEnumerable<string> data, IManager heroManager)
        : base(data, heroManager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroManager.AddHero(this.Data);
        return result;        
    }
}
