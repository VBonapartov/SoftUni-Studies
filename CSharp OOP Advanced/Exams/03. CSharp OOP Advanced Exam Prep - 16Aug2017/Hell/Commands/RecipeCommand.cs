using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IEnumerable<string> data, IManager heroManager)
        : base(data, heroManager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroManager.AddRecipeItem(this.Data);
        return result;
    }
}