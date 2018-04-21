namespace _01._Logger.Interfaces
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
