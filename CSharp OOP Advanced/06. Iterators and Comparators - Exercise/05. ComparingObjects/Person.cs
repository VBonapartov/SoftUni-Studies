using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    public int CompareTo(Person otherPerson)
    {
        int result = this.name.CompareTo(otherPerson.name);

        if (result != 0)
        {
            return result;
        }

        result = this.age.CompareTo(otherPerson.age);
        if (result != 0)
        {
            return result;
        }

        return this.town.CompareTo(otherPerson.town);
    }
}