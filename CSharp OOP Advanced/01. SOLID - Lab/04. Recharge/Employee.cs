using System;

public class Employee : Worker
{
    public Employee(string id) : base(id)
    {
    }

    public override void Sleep()
    {
        // sleep...
    }

    public override void Recharge()
    {
        throw new InvalidOperationException("Employees cannot recharge");
    }
}