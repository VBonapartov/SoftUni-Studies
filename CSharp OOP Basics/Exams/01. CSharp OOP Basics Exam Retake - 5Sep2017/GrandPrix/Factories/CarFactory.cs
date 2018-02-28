public static class CarFactory
{
    public static Car Create(int hp, double fuelAmount, Tyre tyre)
    {
        return new Car(hp, fuelAmount, tyre);
    }
}