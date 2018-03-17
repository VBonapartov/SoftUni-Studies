public class GoldenEditionBook : Book
{
    private const decimal PriceIncreaseMultiplier = 1.3m;

    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price)
    {
    }

    protected override decimal Price
    {
        get
        {
            return base.Price * PriceIncreaseMultiplier;
        }
    }
}