using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

[TestFixture]
public class TweeterClientTests
{
    [Test]
    public void SendToServerShouldSendTheMessageToItsServer()
    {
        // Arraneg
        Mock<IWriter> writer = new Mock<IWriter>();
        TweeterClient tweeterClient = new TweeterClient(writer.Object);

        // Act
        tweeterClient.SendToServer("New message");

        // Assert
        Assert.IsTrue(tweeterClient.Tweets.SequenceEqual(new List<string> { "New message" }), "Message is not sent to the server");
    }

    [Test]
    public void WriteTweetShouldInvokeItsWriterWithTweetMessage()
    {
        // Arrange
        Mock<IWriter> writer = new Mock<IWriter>();
        writer.Setup(w => w.WriteLine(It.IsAny<string>()));
        TweeterClient tweeterClient = new TweeterClient(writer.Object);

        // Act 
        tweeterClient.WriteTweet("New message");

        // Assert
        writer.Verify(w => w.WriteLine(It.Is<string>(s => s.Equals("New message"))), $"Tweet is not given to the {typeof(TweeterClient)}'s writer");
    }
}
