using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {   
        Type classType = Type.GetType($"{unitType}");

        if (classType == null)
        {
            throw new ArgumentException($"Invalid Unit type!");
        }

        if (!typeof(IUnit).IsAssignableFrom(classType))
        {
            throw new ArgumentException($"{unitType} is not a Unit type!");
        }

        return (IUnit)Activator.CreateInstance(classType);
    }
}
