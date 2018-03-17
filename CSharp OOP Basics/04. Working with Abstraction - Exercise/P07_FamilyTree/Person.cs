using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public Person(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
        this.children = new List<Person>();
        this.parents = new List<Person>();
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public string Birthday
    {
        get { return this.birthday; }
        private set { this.birthday = value; }
    }

    public void AddParent(Person parent)
    {
        this.parents.Add(parent);
    }

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.Birthday}");

        sb.AppendLine("Parents:");
        if (this.parents.Count > 0)
        {
            foreach (Person parent in this.parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
        }

        sb.AppendLine("Children:");
        if (this.children.Count > 0)
        {
            foreach (Person child in this.children)
            {
                sb.AppendLine($"{child.Name} {child.Birthday}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}
