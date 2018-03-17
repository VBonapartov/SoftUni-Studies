using System.Linq;

public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    public int Used
    {
        get => this.Data.Count;
    }

    // removes the first element in the collection
    public override T Remove()
    {
        T firstElement = this.Data.First();
        this.Data.RemoveAt(0);

        return firstElement;
    }
}