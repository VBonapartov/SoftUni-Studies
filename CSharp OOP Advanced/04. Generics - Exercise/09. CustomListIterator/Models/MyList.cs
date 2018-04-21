using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IMyList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private readonly IList<T> elements;

    public MyList() : this(Enumerable.Empty<T>())
    {
    }

    public MyList(IEnumerable<T> collection)
    {
        this.elements = new List<T>(collection);
    }

    public IList<T> Elements
    {
        get { return this.elements; }
    }

    public void Add(T element)
    {
        this.Elements.Add(element);
    }

    public T Remove(int index)
    {
        if (index >= this.Elements.Count || index < 0 || this.Elements.Count == 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.Elements[index];
        this.Elements.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        return this.Elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        int dataCount = this.Elements.Count;

        if (dataCount == 0
            || index1 >= dataCount || index2 >= dataCount
            || index1 < 0 || index2 < 0)
        {
            return;
        }

        T temp = this.Elements[index1];
        this.Elements[index1] = this.Elements[index2];
        this.Elements[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.Elements.Count(e => e.CompareTo(element) == 1);
    }

    public T Min()
    {
        if (this.Elements.Count == 0)
        {
            throw new ArgumentException("Empty collection");
        }

        return this.Elements.Min();
    }

    public T Max()
    {
        if (this.Elements.Count == 0)
        {
            throw new ArgumentException("Empty collection");
        }

        return this.Elements.Max();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Elements.GetEnumerator();
    }
}