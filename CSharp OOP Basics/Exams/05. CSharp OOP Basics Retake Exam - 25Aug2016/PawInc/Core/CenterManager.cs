using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CenterManager
{
    private List<CleansingCenter> cleansingCenters;
    private List<AdoptionCenter> adoptionCenters;
    private List<CastrationCenter> castrationCenters;

    private List<string> cleansedAnimalNames;
    private List<string> adoptedAnimalNames;
    private List<string> castratedAnimalNames;

    public CenterManager()
    {
        this.cleansingCenters = new List<CleansingCenter>();
        this.adoptionCenters = new List<AdoptionCenter>();
        this.castrationCenters = new List<CastrationCenter>();

        this.cleansedAnimalNames = new List<string>();
        this.adoptedAnimalNames = new List<string>();
        this.castratedAnimalNames = new List<string>();
    }

    public void RegisterCleansingCenter(List<string> commands)
    {
        string name = commands[0];

        CleansingCenter cleansingCenter = new CleansingCenter(name);
        this.cleansingCenters.Add(cleansingCenter);
    }

    public void RegisterAdoptionCenter(List<string> commands)
    {
        string name = commands[0];

        AdoptionCenter adoptionCenter = new AdoptionCenter(name);
        this.adoptionCenters.Add(adoptionCenter);
    }

    public void RegisterCastrationCenter(List<string> commands)
    {
        string name = commands[0];

        CastrationCenter castrationCenter = new CastrationCenter(name);
        this.castrationCenters.Add(castrationCenter);
    }

    public void RegisterDog(List<string> commands)
    {
        string name = commands[0];
        int age = int.Parse(commands[1]);
        int learnedCommands = int.Parse(commands[2]);
        string adoptionCenterName = commands[3];

        IAnimal animal = new Dog(name, age, learnedCommands, adoptionCenterName);

        AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
        adoptionCenter.RegisterAnimal(animal);
    }

    public void RegisterCat(List<string> commands)
    {
        string name = commands[0];
        int age = int.Parse(commands[1]);
        int learnedCommands = int.Parse(commands[2]);
        string adoptionCenterName = commands[3];

        IAnimal animal = new Cat(name, age, learnedCommands, adoptionCenterName);

        AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
        adoptionCenter.RegisterAnimal(animal);
    }

    public void SendForCleansing(List<string> commands)
    {
        string adoptionCenterName = commands[0];
        string cleansingCenterName = commands[1];

        AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
        CleansingCenter cleansingCenter = this.cleansingCenters.FirstOrDefault(cc => cc.CenterName.Equals(cleansingCenterName));

        List<IAnimal> uncleansedAnimals = adoptionCenter.GetUncleansedAnimals();
        adoptionCenter.RemoveUncleansedAnimals();

        cleansingCenter.RegisterUncleansedAnimals(uncleansedAnimals);        
    }

    public void Cleanse(List<string> commands)
    {
        string cleansingCenterName = commands[0];

        CleansingCenter cleansingCenter = this.cleansingCenters.FirstOrDefault(cc => cc.CenterName.Equals(cleansingCenterName));

        List<IAnimal> cleansedAnimals = cleansingCenter.Cleanse();

        this.cleansedAnimalNames.AddRange(cleansedAnimals.Select(a => a.Name));

        foreach (IAnimal animal in cleansedAnimals)
        {
            string adoptionCenterName = animal.CenterName;

            AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
            adoptionCenter.RegisterAnimal(animal);
        }
    }

    public void Adopt(List<string> commands)
    {
        string adoptionCenterName = commands[0];

        AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
        List<string> adoptedAnimalNames = adoptionCenter.Adopt();

        this.adoptedAnimalNames.AddRange(adoptedAnimalNames);
    }

    public void SendForCastration(List<string> commands)
    {
        string adoptionCenterName = commands[0];
        string castrationCenterName = commands[1];

        AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
        CastrationCenter castrationCenter = this.castrationCenters.FirstOrDefault(cc => cc.CenterName.Equals(castrationCenterName));

        List<IAnimal> animalsForCastration = adoptionCenter.GetAnimalsForCastration();
        adoptionCenter.RemoveAnimalsForCastration();

        castrationCenter.RegisterAnimalsForCastration(animalsForCastration);
    }

    public void Castrate(List<string> commands)
    {
        string castrationCenterName = commands[0];

        CastrationCenter castrationCenter = this.castrationCenters.FirstOrDefault(cc => cc.CenterName.Equals(castrationCenterName));

        List<IAnimal> castratedAnimals = castrationCenter.Castrate();

        this.castratedAnimalNames.AddRange(castratedAnimals.Select(a => a.Name));

        foreach (IAnimal animal in castratedAnimals)
        {
            string adoptionCenterName = animal.CenterName;

            AdoptionCenter adoptionCenter = this.adoptionCenters.FirstOrDefault(ac => ac.CenterName.Equals(adoptionCenterName));
            adoptionCenter.RegisterAnimal(animal);
        }
    }

    public string CastrationStatistics()
    {
        StringBuilder result = new StringBuilder();

        string castratedAnimals = this.castratedAnimalNames.Count > 0
                                  ? string.Join(", ", this.castratedAnimalNames.OrderBy(n => n))
                                  : "None";

        result
            .AppendLine("Paw Inc. Regular Castration Statistics")
            .AppendLine($"Castration Centers: {this.castrationCenters.Count}")
            .AppendLine($"Castrated Animals: {castratedAnimals}");

        return result.ToString().Trim();
    }

    public string PrintStatistics()
    {
        StringBuilder result = new StringBuilder();

        string adoptedAnimals = this.adoptedAnimalNames.Count > 0 
                                ? string.Join(", ", this.adoptedAnimalNames.OrderBy(n => n)) 
                                : "None";
            
        string cleansedAnimals = this.cleansedAnimalNames.Count > 0
                                 ? string.Join(", ", this.cleansedAnimalNames.OrderBy(n => n))
                                 : "None";

        int animalsAwaitingAdoption = this.adoptionCenters.Sum(ac => ac.CountAnimalsAwaitingAdoption());
        int animalsAwaitingCleansing = this.cleansingCenters.Sum(ac => ac.CountAnimalsAwaitingCleansing());

        result
            .AppendLine("Paw Incorporative Regular Statistics")
            .AppendLine($"Adoption Centers: {this.adoptionCenters.Count}")
            .AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}")
            .AppendLine($"Adopted Animals: {adoptedAnimals}")
            .AppendLine($"Cleansed Animals: {cleansedAnimals}")
            .AppendLine($"Animals Awaiting Adoption: {animalsAwaitingAdoption}")
            .AppendLine($"Animals Awaiting Cleansing: {animalsAwaitingCleansing}");

        return result.ToString().Trim();
    }
}
