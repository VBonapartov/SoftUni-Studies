using System.Collections.Generic;

public class TweeterClient : IClient
{
    private IWriter writer;

    public TweeterClient(IWriter writer)
    {
        this.writer = writer;
        this.Tweets = new List<string>();
    }

    public IList<string> Tweets { get; private set; }

    public void SendToServer(string message)
    {
        this.Tweets.Add(message);
    }

    public void WriteTweet(string message)
    {
        this.writer.WriteLine(message);
    }
}
