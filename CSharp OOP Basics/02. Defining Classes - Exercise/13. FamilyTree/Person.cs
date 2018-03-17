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
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
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

    private List<Person> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    private List<Person> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public void AddParent(Person parent)
    {
        this.Parents.Add(parent);
    }

    public void AddChild(Person child)
    {
        this.Children.Add(child);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.Birthday}");

        sb.AppendLine("Parents:");
        if (this.Parents.Count > 0)
        {
            foreach (Person parent in this.Parents)
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
        }

        sb.AppendLine("Children:");
        if (this.Children.Count > 0)
        {
            foreach (Person child in this.Children)
                sb.AppendLine($"{child.Name} {child.Birthday}");
        }

        return sb.ToString();
    }
}