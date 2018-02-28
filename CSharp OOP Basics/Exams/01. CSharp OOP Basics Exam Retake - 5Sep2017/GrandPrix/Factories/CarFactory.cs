public static class CarFactory
{
    public static ICar Create(int hp, double fuelAmount, ITyre tyre)
    {
        return new Car(hp, fuelAmount, tyre);
    }
}