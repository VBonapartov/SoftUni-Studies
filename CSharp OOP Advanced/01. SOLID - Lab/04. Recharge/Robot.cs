﻿using System;

public class Robot : Worker
{
    private int capacity;
    private int currentPower;

    public Robot(string id, int capacity) : base(id)
    {
        this.capacity = capacity;
    }

    public int Capacity
    {
        get { return this.capacity; }
    }

    public int CurrentPower
    {
        get { return this.currentPower; }
        set { this.currentPower = value; }
    }

    public void Work(int hours)
    {
        if (hours > this.currentPower)
        {
            hours = this.currentPower;
        }

        base.Work(hours);
        this.currentPower -= hours;
    }

    public override void Recharge()
    {
        this.currentPower = this.capacity;
    }

    public override void Sleep()
    {
        throw new InvalidOperationException("Robots cannot sleep");
    }
}