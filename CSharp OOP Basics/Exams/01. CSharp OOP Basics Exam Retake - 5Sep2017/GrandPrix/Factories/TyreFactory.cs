using System;

public static class TyreFactory
{
    public static Tyre Create(string tyreType, double tyreHardness, double grip)
    {
        switch (tyreType)
        {
            case "Ultrasoft":
                return new UltrasoftTyre(tyreHardness, grip);

            case "Hard":
                return new HardTyre(tyreHardness);

            default:
                throw new ArgumentException();
        }
    }
}
