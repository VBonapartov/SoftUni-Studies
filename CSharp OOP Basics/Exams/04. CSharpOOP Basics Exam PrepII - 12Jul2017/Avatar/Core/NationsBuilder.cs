using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, List<IBender>> nations = new Dictionary<string, List<IBender>>();
    private List<IMonument> monuments = new List<IMonument>();

    private List<string> warsHistory = new List<string>();

    public void AssignBender(List<string> benderArgs)
    {
        IBender bender = BenderFactory.GetBender(benderArgs);

        string nation = bender.GetNationType();

        if (!this.nations.ContainsKey(nation))
        {
            this.nations.Add(nation, new List<IBender>());
        }

        this.nations[nation].Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        IMonument monument = MonumentFactory.GetMonument(monumentArgs);
        this.monuments.Add(monument);
    }

    public string GetStatus(string nation)
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{nation} Nation");            

        if (this.nations.ContainsKey(nation) && this.nations[nation].Count > 0)
        {
            result.AppendLine($"Benders:");

            foreach (IBender bender in this.nations[nation])
            {
                result.AppendLine(bender.ToString());
            }
        }
        else
        {
            result.AppendLine("Benders: None");
            result.AppendLine("Monuments: None");

            return result.ToString().Trim();
        }        

        if (this.monuments.Any(b => b.GetMonumentType().Equals(nation)))
        {
            result.AppendLine($"Monuments:");

            foreach (IMonument monument in this.monuments.Where(b => b.GetMonumentType().Equals(nation)))
            {
                result.AppendLine(monument.ToString());
            }
        }
        else
        {
            result.AppendLine("Monuments: None");
        }

        return result.ToString().Trim();
    }

    public void IssueWar(string nation)
    {          
        var orderedNations = this.nations
                                   .OrderByDescending(n => this.CalculateNationPowerWithBonus(n.Value, n.Key))
                                   .ToDictionary(n => n.Key, n => n.Value);               

        KeyValuePair<string, List<IBender>> winnerNation = orderedNations.FirstOrDefault();
    
        foreach (KeyValuePair<string, List<IBender>> currentNation in this.nations)
        {
            if (!currentNation.Key.Equals(winnerNation.Key))
            {
                this.nations[currentNation.Key].Clear();
                this.monuments.RemoveAll(m => m.GetMonumentType().Equals(currentNation.Key));
            }           
        }

        this.warsHistory.Add(nation);
    }

    public string GetWarsRecord()
    {
        StringBuilder result = new StringBuilder();

        int warCounter = 1;
        foreach (string nation in this.warsHistory)
        {
            result.AppendLine($"War {warCounter++} issued by {nation}");
        }

        return result.ToString().Trim(); 
    }

    private double CalculateNationPowerWithBonus(List<IBender> benders, string monumentType)
    {
        double totalPower = benders.Sum(b => b.CalculateTotalPower());
        long bonusPercent = this.GetMonumentsBonusPercent(monumentType);

        totalPower += totalPower * (bonusPercent / 100.0);
        return totalPower;
    }

    private long GetMonumentsBonusPercent(string monumentType)
    {
        long totalAffinity = this.monuments
                                    .Where(m => m.GetMonumentType().Equals(monumentType))
                                    .Sum(m => m.Affinity);

        return totalAffinity;
    }
}
