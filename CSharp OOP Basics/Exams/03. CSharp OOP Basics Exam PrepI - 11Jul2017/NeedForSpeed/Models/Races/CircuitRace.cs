﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    private int Laps
    {
        get { return this.laps; }
        set { this.laps = value; }
    }

    public override int GetPerformancePoints(Car car)
    {
        return (car.Horsepower / car.Acceleration) + car.Suspension + car.Durability;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (this.AreThereAnyParticipants())
        {
            sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

            foreach(Car car in this.Participants)
            {
                car.Durability -= (this.Laps * (this.Length * this.Length));
            }

            List<Car> winners = this.Participants.OrderByDescending(p => this.GetPerformancePoints(p)).Take(4).ToList();

            int prize = 0;

            for (int i = 0; i < winners.Count; i++)
            {
                if (i == 0)
                {
                    prize = this.PrizePool * 40 / 100;
                }
                else if (i == 1)
                {
                    prize = this.PrizePool * 30 / 100;
                }
                else if (i == 2)
                {
                    prize = this.PrizePool * 20 / 100;
                }
                else if (i == 3)
                {
                    prize = this.PrizePool * 10 / 100;
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
}
