using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    public AddCollection()
    {
        this.Data = new List<T>();
    }

    protected List<T> Data { get; set; }

    // add an item to the end of the collection
    public virtual int Add(T element)
    {
        this.Data.Add(element);
        return this.Data.Count - 1;
    }
}