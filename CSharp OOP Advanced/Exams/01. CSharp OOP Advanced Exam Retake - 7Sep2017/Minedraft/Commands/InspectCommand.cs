using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);

        StringBuilder result = new StringBuilder();

        List<IEntity> entities = this.GetProviders();
        IEntity entity = entities.FirstOrDefault(e => e.ID == id);

        if (entity == null)
        {
            entities = this.GetHarvesters();
            entity = entities.FirstOrDefault(e => e.ID == id);
        }

        if (entity != null)
        {
            return entity.ToString();
        }
        else
        {
            return string.Format(Constants.NoEntityFound, id);
        }
    }

    private List<IEntity> GetHarvesters()
    {
        List<IEntity> entities = new List<IEntity>();

        var harvesterEntitites = this.harvesterController
                                            .GetType()
                                            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                            .FirstOrDefault(t => t.Name == "Entities");

        var harvesters = (IReadOnlyCollection<IEntity>)harvesterEntitites.GetValue(this.harvesterController);

        entities.AddRange(harvesters);
        return entities;
    }

    private List<IEntity> GetProviders()
    {
        List<IEntity> entities = new List<IEntity>();

        var providerEntitites = this.providerController
                                                .GetType()
                                                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                .FirstOrDefault(t => t.Name == "Entities");

        var providers = (IReadOnlyCollection<IEntity>)providerEntitites.GetValue(this.providerController);

        entities.AddRange(providers);
        return entities;
    }
}
