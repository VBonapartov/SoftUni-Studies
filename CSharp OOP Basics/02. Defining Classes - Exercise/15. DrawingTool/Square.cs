using System.Text;

public class Square
{
    private int squareSide;

    public Square()
    {
    }

    public Square(int squareSide)
    {
        this.squareSide = squareSide;
    }

    public int SquareSide
    {
        get { return this.squareSide; }
    }

    public virtual string Draw()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("|" + new string('-', this.SquareSide) + "|");

        for (int i = 1; i < this.SquareSide - 1; i++)
        {
            sb.AppendLine("|" + new string(' ', this.SquareSide) + "|");
        }

        if (this.SquareSide > 1)
        {
            sb.AppendLine("|" + new string('-', this.SquareSide) + "|");
        }

        return sb.ToString();
    }
}