using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine(string.Format(Constants.SystemShutdown))
            .AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced))
            .AppendLine(string.Format(Constants.TotalMinedOre, this.harvesterController.OreProduced));

        return result.ToString().Trim();
    }
}
