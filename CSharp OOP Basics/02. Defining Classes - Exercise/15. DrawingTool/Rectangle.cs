using System.Text;

public class Rectangle : Square
{
    private int length;
    private int width;

    public Rectangle(int length, int width) 
        : base()
    {
        this.length = length;
        this.width = width;
    }

    public int Length
    {
        get { return this.length; }
    }

    public int Width
    {
        get { return this.width; }
    }

    public override string Draw()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("|" + new string('-', this.Length) + "|");

        for (int i = 1; i < this.Width - 1; i++)
        {
            sb.AppendLine("|" + new string(' ', this.Length) + "|");
        }

        if (this.Width > 1)
        {
            sb.AppendLine("|" + new string('-', this.Length) + "|");
        }

        return sb.ToString();
    }
}