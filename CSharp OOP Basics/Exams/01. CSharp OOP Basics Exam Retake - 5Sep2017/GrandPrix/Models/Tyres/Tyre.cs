using System;

public abstract class Tyre
{
    private const int StartPointsDegradation = 100;

    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = StartPointsDegradation;
    }

    public virtual string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        protected set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get
        {
            return this.degradation;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}