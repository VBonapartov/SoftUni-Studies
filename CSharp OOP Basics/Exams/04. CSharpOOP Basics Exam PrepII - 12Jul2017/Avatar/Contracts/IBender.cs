public interface IBender
{
    string Name { get; }

    int Power { get; }

    string GetNationType();

    double CalculateTotalPower();

    string ToString();
}
