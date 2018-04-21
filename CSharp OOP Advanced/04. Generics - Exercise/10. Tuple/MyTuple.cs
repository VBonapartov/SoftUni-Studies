public class MyTuple<T, U>
{
    private T item1;
    private U item2;

    public MyTuple(T item1, U item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public T Item1
    {
        get { return this.item1; }
        private set { this.item1 = value; }
    }

    public U Item2
    {
        get { return this.item2; }
        private set { this.item2 = value; }
    }
}