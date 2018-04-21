using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{
    private StringBuilder sb;

    public HarvestingFieldsTest()
    {
        this.sb = new StringBuilder();
    }

    public string Run()
    {
        Type classType = Type.GetType("HarvestingFields");

        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        string command = string.Empty;
        while (!(command = Console.ReadLine()).Equals("HARVEST"))
        {
            Func<FieldInfo, bool> fieldsChecker = (FieldInfo fi) => false;

            switch (command)
            {
                case "private":
                    fieldsChecker = (FieldInfo fi) => fi.IsPrivate;
                    break;

                case "protected":
                    fieldsChecker = (FieldInfo fi) => fi.IsFamily;
                    break;

                case "public":
                    fieldsChecker = (FieldInfo fi) => fi.IsPublic;
                    break;

                case "all":
                    fieldsChecker = (FieldInfo fi) => true;
                    break;

                default:
                    break;
            }

            this.SaveFieldsInfo(classFields, fieldsChecker);
        }

        return this.sb.ToString().Trim();
    }

    public void SaveFieldsInfo(FieldInfo[] classFields, Func<FieldInfo, bool> fieldsChecker)
    {
        foreach (FieldInfo field in classFields.Where(fieldsChecker))
        {
            string accessModifier = field.Attributes.ToString().ToLower();
            accessModifier = accessModifier.Equals("family") ? "protected" : accessModifier;

            this.sb.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
        }
    }
}
