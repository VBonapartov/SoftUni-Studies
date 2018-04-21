using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        object[] parametersForConstruction = new object[] { name, age, experience, endurance };

        Type typeOfSoldier = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(soldierTypeName));

        ISoldier soldier = (ISoldier)Activator.CreateInstance(typeOfSoldier, parametersForConstruction);
        return soldier;
    }
}