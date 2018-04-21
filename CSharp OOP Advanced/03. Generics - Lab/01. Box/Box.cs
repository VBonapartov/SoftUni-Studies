using System.Collections.Generic;
using System.Linq;

public class Box<T> : IBox<T>
{
    public Box()
    {
        this.Data = new List<T>();
    }

    private IList<T> Data { get; set; }

    public int Count
    {
        get
        {
            return this.Data.Count;
        }
    }

    public void Add(T element)
    {
        this.Data.Add(element);
    }

    public T Remove()
    {
        T element = this.Data.LastOrDefault();
        this.Data.RemoveAt(this.Count - 1);

        return element;
    }
}