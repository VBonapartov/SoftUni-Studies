using System;
using System.Linq;

public class Sorter
{
    public static MyList<T> Sort<T>(MyList<T> myList)
        where T : IComparable<T>
    {
        var temp = myList.Elements.OrderBy(x => x);
        return new MyList<T>(temp);
    }
}