using System;
using System.Linq;
using System.Reflection;

public class BehaviorFactory : IBehaviorFactory
{
    public IBehavior CreateBehavior(string behaviorType, IBlob blob)
    {
        Type type = Assembly
                         .GetExecutingAssembly()
                         .GetTypes()
                         .FirstOrDefault(t => t.Name == behaviorType);

        if (type == null)
        {
            throw new ArgumentException("Unknown behavior type.");
        }

        IBehavior behavior = (IBehavior)Activator.CreateInstance(type, blob);

        return behavior;
    }
}
