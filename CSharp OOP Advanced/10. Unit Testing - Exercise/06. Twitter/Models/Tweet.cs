using System;

public class Tweet : ITweet
{
    public Tweet(IClient client)
    {
        this.Client = client;
    }

    private IClient Client { get; set; }

    public void Message(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException();
        }

        if (message.Length > 255)
        {
            throw new ArgumentOutOfRangeException();
        }

        this.Client.WriteTweet(message);
        this.Client.SendToServer(message);
    }
}
