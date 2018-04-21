using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        object[] parametersForConstruction = new object[] { neededPoints };

        Type typeOfMission = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name.Equals(difficultyLevel));

        IMission mission = (IMission)Activator.CreateInstance(typeOfMission, parametersForConstruction);
        return mission;
    }
}
