using System;
using System.Collections.Generic;

public class ListIterator
{
    private List<string> collection;
    private int internalIndex;

    public ListIterator(IEnumerable<string> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException();
        }

        this.collection = new List<string>(collection);
        this.internalIndex = 0;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.internalIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return this.internalIndex < this.collection.Count - 1;
    }

    public string Print()
    {
        if (this.collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.collection[this.internalIndex];
    }
}
