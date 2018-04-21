using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly IList<T> elements;
    private int currentIndex;

    public ListyIterator() : this(Enumerable.Empty<T>())
    {
    }

    public ListyIterator(IEnumerable<T> elements)
    {
        this.elements = new List<T>(elements);
    }

    private IList<T> Elements
    {
        get { return this.elements; }
    }

    public bool Move()
    {
        if (this.currentIndex < this.Elements.Count - 1)
        {
            this.currentIndex++;
        }
        else
        {
            return false;
        }

        return true;
    }

    public bool HasNext()
    {
        return this.currentIndex < this.Elements.Count - 1;
    }

    public T Print()
    {
        if (this.Elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return this.Elements[this.currentIndex];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Elements.Count; i++)
        {
            yield return this.Elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
