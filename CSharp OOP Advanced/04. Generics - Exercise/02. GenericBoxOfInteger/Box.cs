public class Box<T>
{
    public Box(T item)
    {
        this.Data = item;
    }

    private T Data { get; set; }

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}
