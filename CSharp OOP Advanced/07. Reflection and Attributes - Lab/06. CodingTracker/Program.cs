namespace _06._CodingTracker
{
    [SoftUni("Ventsi")]
    public class Program
    {
        [SoftUni("Gosho")]
        [SoftUni("Veselin")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
