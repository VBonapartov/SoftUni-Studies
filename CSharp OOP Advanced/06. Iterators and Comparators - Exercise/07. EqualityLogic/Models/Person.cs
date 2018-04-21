using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        private set { this.age = value; }
    }

    public int CompareTo(Person otherPerson)
    {
        int result = this.name.CompareTo(otherPerson.name);

        if (result != 0)
        {
            return result;
        }

        return this.age.CompareTo(otherPerson.age);
    }

    //public override bool Equals(object obj)
    //{
    //    if (obj == null || this.GetType() != obj.GetType())
    //        return false;

    //    Person person = obj as Person;

    //    return this.Name == person.Name && this.Age == person.Age;
    //}

    //public override int GetHashCode()
    //{
    //    int hash = 13;

    //    hash = hash * 7 + this.Name.GetHashCode();
    //    hash = hash * 7 + this.Age.GetHashCode();

    //    return hash;
    //}
}