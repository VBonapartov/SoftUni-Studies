using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type typeOfAmmunition = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(ammunitionName));

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(typeOfAmmunition, new object[] { ammunitionName });
        return ammunition;
    }
}