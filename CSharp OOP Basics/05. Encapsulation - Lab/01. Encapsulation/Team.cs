﻿using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly(); }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return this.reserveTeam.AsReadOnly(); }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        return $"First team have {this.FirstTeam.Count} players\nReserve team have {this.ReserveTeam.Count} players";
    }
}