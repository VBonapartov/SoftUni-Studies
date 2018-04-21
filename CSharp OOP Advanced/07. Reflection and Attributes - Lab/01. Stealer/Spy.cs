using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfTheClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(nameOfTheClass);

        Object classInstance = Activator.CreateInstance(classType);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {nameOfTheClass}");

        foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}