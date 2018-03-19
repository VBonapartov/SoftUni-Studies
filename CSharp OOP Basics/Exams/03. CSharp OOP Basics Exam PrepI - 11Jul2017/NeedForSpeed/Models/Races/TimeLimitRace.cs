using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;
    private int prizeMoney;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    private int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }

    public override int GetPerformancePoints(Car car)
    {
        return this.Length * ((car.Horsepower / 100) * car.Acceleration);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (this.AreThereAnyParticipants())
        {
            sb.AppendLine($"{this.Route} - {this.Length}");
            Car winner = this.Participants.FirstOrDefault();
            sb.AppendLine($"{winner.Brand} {winner.Model} - {GetPerformancePoints(winner)} s.");
            sb.AppendLine($"{GetTimeType(GetPerformancePoints(winner))} Time, ${this.prizeMoney}.");
        }
        else
        {
            sb.AppendLine($"Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }

    private string GetTimeType(int timePoints)
    {
        if (timePoints <= this.GoldTime)
        {
            this.prizeMoney = this.PrizePool;
            return "Gold";
        }
        else if (timePoints <= this.GoldTime + 15)
        {
            this.prizeMoney = (this.PrizePool * 50) / 100;
            return "Silver";
        }
        else
        {
            this.prizeMoney = (this.PrizePool * 30) / 100;
            return "Bronze";
        }
    }
}
