using System.Collections.Generic;

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

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}
