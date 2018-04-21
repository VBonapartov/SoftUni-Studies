public abstract class Logger : IHandler
{
    private IHandler successor;

    public void SetSuccessor(IHandler successor)
    {
        this.successor = successor;
    }

    public abstract void Handle(LogType type, string message);

    protected void PassToSuccessor(LogType type, string message)
    {
        if (this.successor != null)
        {
            this.successor.Handle(type, message);
        }
    }
}
