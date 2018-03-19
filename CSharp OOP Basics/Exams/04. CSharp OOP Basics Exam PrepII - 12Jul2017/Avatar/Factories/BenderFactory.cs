using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class BenderFactory
{
    public static IBender GetBender(List<string> benderArgs)
    {
        string type = benderArgs[0] + "Bender";
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        object[] parametersForConstruction = new object[] { name, power, secondaryParameter };

        Type typeOfCommand = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(type));

        if (typeOfCommand == null)
        {
            throw new ArgumentException("Invalid input!");
        }

        IBender bender = (Bender)Activator.CreateInstance(typeOfCommand, parametersForConstruction);
        return bender;
    }
}
