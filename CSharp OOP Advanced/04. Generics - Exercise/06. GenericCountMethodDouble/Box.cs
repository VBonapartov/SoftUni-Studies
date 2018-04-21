using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>    
{
    public Box(T item)
    {
        this.Data = item;
    }

    private T Data { get; set; }

    public static void Swap<T1>(IList<T1> collection, int firstIndex, int secondIndex)
    {
        T1 temp = collection[firstIndex];
        collection[firstIndex] = collection[secondIndex];
        collection[secondIndex] = temp;
    }

    public static int CompareByValue<T1>(IList<Box<T1>> collection, T1 element) where T1 : IComparable<T1>
    {
        return collection.Where(i => i.Data.CompareTo(element) == 1).Count();
    }

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}
