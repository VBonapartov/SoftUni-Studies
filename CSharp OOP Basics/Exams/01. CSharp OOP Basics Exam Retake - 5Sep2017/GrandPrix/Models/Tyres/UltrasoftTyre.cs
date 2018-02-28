using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftTyreName = "Ultrasoft";

    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }
        
    public override double Degradation
    {
        get
        {
            return this.degradation;
        }

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public override string Name => UltrasoftTyreName;

    private double Grip { get; }

    public override void ReduceDegradation()
    {
        double sum = this.Hardness + this.Grip;
        this.Degradation -= sum;
    }
}