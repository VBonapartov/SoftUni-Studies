using System;
using System.Linq;
using System.Reflection;

public class AttackFactory : IAttackFactory
{
    public IAttack CreateAttack(string attackType, IBlob blob)
    {
        Type type = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == attackType);

        if (type == null)
        {
            throw new ArgumentException("Unknown attack type.");
        }

        IAttack attack = (IAttack)Activator.CreateInstance(type, blob);

        return attack;
    }
}
