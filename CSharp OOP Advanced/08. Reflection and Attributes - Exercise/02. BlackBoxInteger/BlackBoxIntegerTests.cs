using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class BlackBoxIntegerTests
{
    private StringBuilder sb;

    public BlackBoxIntegerTests()
    {
        this.sb = new StringBuilder();
    }

    public string Run()
    {
        Type classType = Type.GetType("BlackBoxInt");

        BlackBoxInt blackBoxInstance = (BlackBoxInt)Activator.CreateInstance(classType, true);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        string input = string.Empty;
        while (!(input = Console.ReadLine()).Equals("END"))
        {
            string[] cmdArgs = input.Split('_');
            string command = cmdArgs[0];
            int number = int.Parse(cmdArgs[1]);

            MethodInfo currentMethod = classMethods.FirstOrDefault(m => m.Name.Equals(command));

            if (currentMethod != null)
            {
                currentMethod.Invoke(blackBoxInstance, new object[] { number });
            }

            foreach (FieldInfo field in classFields)
            {
                this.sb.AppendLine(field.GetValue(blackBoxInstance).ToString());
            }
        }

        return this.sb.ToString().Trim();
    }
}
