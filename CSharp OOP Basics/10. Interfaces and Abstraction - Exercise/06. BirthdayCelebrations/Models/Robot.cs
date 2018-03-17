public class Robot : IRobot
{
    private string id;

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get;
        private set;
    }

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }
}