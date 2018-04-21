public class MachineGun : Ammunition
{
    public const double WeightValue = 10.6;

    public MachineGun(string name)
        : base(name, WeightValue)
    {
    }
}