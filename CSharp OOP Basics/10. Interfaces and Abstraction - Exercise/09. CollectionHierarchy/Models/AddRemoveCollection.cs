using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    public AddRemoveCollection()
    {
        this.Data = new List<T>();
    }

    // add an item to the start of the collection
    public override int Add(T element)
    {
        this.Data.Insert(0, element);
        return 0;
    }

    // removes the last element in the collection
    public virtual T Remove()
    {
        T lastElement = this.Data.Last();
        this.Data.RemoveAt(this.Data.Count - 1);

        return lastElement;
    }
}