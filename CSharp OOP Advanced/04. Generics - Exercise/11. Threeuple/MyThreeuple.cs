public class MyThreeuple<T, U, V>
{
    private T item1;
    private U item2;
    private V item3;

    public MyThreeuple(T item1, U item2, V item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
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

    public V Item3
    {
        get { return this.item3; }
        private set { this.item3 = value; }
    }
}