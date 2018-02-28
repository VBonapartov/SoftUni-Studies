using System;

public abstract class Tyre : ITyre
{
    private const int StartPointsDegradation = 100;

    private double degradation;

    public Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = StartPointsDegradation;
    }

    public abstract string Name { get; }

    public double Hardness { get; private set; }

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