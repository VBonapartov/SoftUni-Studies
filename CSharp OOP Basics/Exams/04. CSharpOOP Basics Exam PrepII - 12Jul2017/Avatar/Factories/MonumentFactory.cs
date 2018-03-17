using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class MonumentFactory
{
    public static IMonument GetMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0] + "Monument";
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        object[] parametersForConstruction = new object[] { name, affinity };

        Type typeOfCommand = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(type));

        if (typeOfCommand == null)
        {
            throw new ArgumentException("Invalid input!");
        }

        IMonument monument = (Monument)Activator.CreateInstance(typeOfCommand, parametersForConstruction);
        return monument;
    }
}
