using System.Collections.Generic;

public class PersonNameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length - y.Name.Length;
        if (result != 0)
        {
            return result;
        }

        return char.ToLower(x.Name[0]) - char.ToLower(y.Name[0]);
    }
}