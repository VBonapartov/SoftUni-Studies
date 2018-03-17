using System.Text;

public class Seat : ICar
{
    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model
    {
        get;
        private set;
    }

    public string Color
    {
        get;
        private set;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();        
        sb.AppendLine($"{this.Color} Seat {this.Model}");
        sb.AppendLine(this.Start());
        sb.Append(this.Stop());

        return sb.ToString();
    }
}