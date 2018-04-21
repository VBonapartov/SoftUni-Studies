using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const string FullMode = "Full";
    private const string HalfMode = "Half";
    private const string EnergyMode = "Energy";
    private const double FullRatio = 1.0;
    private const double HalfRatio = 0.5;
    private const double EnergyRatio = 0.2;

    private const int MinDurability = 0;

    private IList<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;

    private string mode;
    private double oreProduced;

    public HarvesterController(IHarvesterFactory harvesterFactory, IList<IHarvester> harvesters, IEnergyRepository energyRepository)
    {
        this.harvesterFactory = harvesterFactory;
        this.harvesters = harvesters;
        this.energyRepository = energyRepository;

        this.mode = FullMode;
        this.oreProduced = 0;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.ToList().AsReadOnly();

    public double OreProduced => this.oreProduced;

    public string ChangeMode(string mode)
    {       
        this.mode = mode;

        List<IHarvester> brokenHarvesters = new List<IHarvester>();

        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                brokenHarvesters.Add(harvester);
            }
        }

        foreach (IHarvester entity in brokenHarvesters)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        double neededEnergy = this.CalculateNeededEnergy();

        double oreOutput = 0d;

        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            oreOutput = this.CalculateOreOutput();
            this.oreProduced += oreOutput;
        }

        return string.Format(Constants.OreOutputToday, oreOutput);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);

        if (harvester != null)
        {
            this.harvesters.Add(harvester);
            return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
        }

        return null;
    }

    private double CalculateOreOutput()
    {
        var oreOutput = this.harvesters.Sum(h => h.Produce());

        switch (this.mode)
        {
            case HalfMode:
                oreOutput *= HalfRatio;
                break;
            case EnergyMode:
                oreOutput *= EnergyRatio;
                break;
            case FullMode:
                oreOutput *= FullRatio;
                break;
            default:
                break;
        }

        return oreOutput;
    }

    private double CalculateNeededEnergy()
    {
        var neededEnergy = this.harvesters.Sum(h => h.EnergyRequirement);

        switch (this.mode)
        {
            case HalfMode:
                neededEnergy *= HalfRatio;
                break;
            case EnergyMode:
                neededEnergy *= EnergyRatio;
                break;
            case FullMode:
                neededEnergy *= FullRatio;
                break;
            default:
                break;
        }

        return neededEnergy;
    }
}
