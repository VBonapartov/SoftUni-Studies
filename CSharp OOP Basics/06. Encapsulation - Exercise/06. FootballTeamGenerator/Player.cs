using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private static readonly string[] PlayerStats = { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

    private string name;
    private IList<Stat> stats;

    public Player(string name, List<int> stats)
    {
        this.Name = name;
        this.Stats = this.CreatePlayerStats(stats);
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (value.Equals(string.Empty) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private IList<Stat> Stats
    {
        get { return this.stats; }
        set { this.stats = value; }
    }

    public double GetSkillLevel()
    {
        return Math.Round(this.Stats.Average(stat => stat.StatValue));
    }

    private List<Stat> CreatePlayerStats(List<int> stats)
    {
        List<Stat> playerStats = new List<Stat>();
        for (int i = 0; i < stats.Count; i++)
        {
            Stat stat = new Stat(PlayerStats[i], stats[i]);
            playerStats.Add(stat);
        }

        return playerStats;
    }
}