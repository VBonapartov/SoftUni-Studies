using System.Collections.Generic;

public class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.CompareTo(y) == 0;
    }

    public int GetHashCode(Person person)
    {
        int hash = 13;

        hash = (hash * 7) + person.Name.GetHashCode();
        hash = (hash * 7) + person.Age.GetHashCode();

        return hash;
    }
}