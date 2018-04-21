using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type classType = Type.GetType($"{unitType}");

        return (classType == null) ? null : (IUnit)Activator.CreateInstance(classType);
    }
}
