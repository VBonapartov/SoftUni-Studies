public abstract class Food
{
    private int quantity;

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity
    {
        get { return this.quantity; }
        private set { this.quantity = value; }
    }
}