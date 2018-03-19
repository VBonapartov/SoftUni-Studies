using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private IList<Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length
    {
        get => this.length;
        private set { this.length = value; }
    }

    public string Route
    {
        get => this.route;
        private set { this.route = value; }
    }

    public int PrizePool
    {
        get => this.prizePool;
        private set { this.prizePool = value; }
    }

    protected  IList<Car> Participants
    {
        get => this.participants;
        set { this.participants = value; }
    }

    public bool IsCarIsInRace(Car car)
    {
        return this.Participants.Contains(car);
    }

    public void AddParticipants(Car car)
    {
        this.Participants.Add(car);
    }

    public bool AreThereAnyParticipants()
    {
        return this.Participants.Count > 0;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (this.AreThereAnyParticipants())
        {
            sb.AppendLine($"{this.Route} - {this.Length}");
            List<Car> winners = this.Participants.OrderByDescending(p => this.GetPerformancePoints(p)).Take(3).ToList();

            int prize = 0;

            for (int i = 0; i < winners.Count; i++)
            {
                if (i == 0)
                {
                    prize = this.PrizePool * 50 / 100;
                }
                else if (i == 1)
                {
                    prize = this.PrizePool * 30 / 100;
                }
                else if (i == 2)
                {
                    prize = this.PrizePool * 20 / 100;
                }

                sb.AppendLine($"{i + 1}. {winners[i].Brand} {winners[i].Model} {this.GetPerformancePoints(winners[i])}PP - ${prize}");
            }
        }
        else
        {
            sb.AppendLine($"Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }

    public abstract int GetPerformancePoints(Car car);
}
