using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private IList<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
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

    private IList<Player> Players
    {
        get { return this.players; }
        set { this.players = value; }
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player player = this.Players.Where(p => p.Name.Equals(playerName)).FirstOrDefault();

        if (player != null)
        {
            this.Players.Remove(player);
        }
        else
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team. ");
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.GetRating()}";
    }

    private int GetRating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }

        return (int)this.players.Average(p => p.GetSkillLevel());
    }
}