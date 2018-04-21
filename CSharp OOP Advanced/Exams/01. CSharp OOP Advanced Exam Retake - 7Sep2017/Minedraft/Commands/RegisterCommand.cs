using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        if (this.Arguments[0].Equals("Harvester"))
        {
            return this.RegisterHarvester();
        }
        else if (this.Arguments[0].Equals("Provider"))
        {
            return this.RegisterProvider();
        }

        // Invalid Entity to Register
        return string.Empty;
    }

    private string RegisterHarvester()
    {
        string result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        return result;
    }

    private string RegisterProvider()
    {
        string result = this.providerController.Register(this.Arguments.Skip(1).ToList());
        return result;
    }
}
