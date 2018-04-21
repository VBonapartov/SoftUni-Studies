using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IMyList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    public MyList()
    {
        this.Data = new List<T>();
    }

    private IList<T> Data { get; set; }

    public void Add(T element)
    {
        this.Data.Add(element);
    }

    public T Remove(int index)
    {
        if (index >= this.Data.Count || index < 0 || this.Data.Count == 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.Data[index];
        this.Data.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        return this.Data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        int dataCount = this.Data.Count;

        if (dataCount == 0
            || index1 >= dataCount || index2 >= dataCount
            || index1 < 0 || index2 < 0)
        {
            return;
        }

        T temp = this.Data[index1];
        this.Data[index1] = this.Data[index2];
        this.Data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.Data.Count(e => e.CompareTo(element) == 1);
    }

    public T Min()
    {
        if (this.Data.Count == 0)
        {
            throw new ArgumentException("Empty collection");
        }

        return this.Data.Min();
    }

    public T Max()
    {
        if (this.Data.Count == 0)
        {
            throw new ArgumentException("Empty collection");
        }

        return this.Data.Max();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Data.GetEnumerator();
    }
}