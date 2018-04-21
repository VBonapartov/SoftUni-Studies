public class Gun : Ammunition
{
    public const double WeightValue = 1.4;

    public Gun(string name)
        : base(name, WeightValue)
    {
    }
}