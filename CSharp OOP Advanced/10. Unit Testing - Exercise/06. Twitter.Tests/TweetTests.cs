using System;
using Moq;
using NUnit.Framework;

[TestFixture]
public class TweetTests
{
    [Test]
    public void TweetEmptyMessageThrowsException()
    {
        // Arrange
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);

        // Assert
        Assert.Throws<ArgumentNullException>(() => tweet.Message(string.Empty));
    }

    [Test]
    public void TweetTooLongMessageThrowsException() // max tweet = 255 symbols
    {
        // Arrange
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);
        string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                         "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                         "Magna sit amet purus gravida quis blandit turpis. " +
                         "Ac ut consequat semper viverra nam libero justo. " +
                         "Faucibus scelerisque eleifend donec pretium. " +
                         "Quam adipiscing vitae proin sagittis nisl.";

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => tweet.Message(message));
    }

    [Test]
    public void WhenReceiveNewMessageClientWriteTheMessage()
    {
        // Arrange
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);

        // Act
        tweet.Message("New message");

        // Assert
        client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to write the message");
    }

    [Test]
    public void WhenReceiveNewMessageClientSendTheMessageToTheServer()
    {
        // Arrange
        Mock<IClient> client = new Mock<IClient>();
        client.Setup(c => c.SendToServer(It.IsAny<string>()));
        Tweet tweet = new Tweet(client.Object);

        // Act
        tweet.Message("New message");

        // Assert
        client.Verify(c => c.SendToServer(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to send the message to the server");
    }
}
