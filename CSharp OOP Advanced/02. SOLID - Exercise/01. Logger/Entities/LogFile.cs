namespace _01._Logger.Entities
{    
    using System.Linq;
    using System.Text;
    using _01._Logger.Interfaces;

    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.sb.AppendLine(message);
            this.Size += this.GetLettersOnlySum(message);
        }

        public override string ToString()
        {
            return this.sb.ToString().Trim();
        }

        private int GetLettersOnlySum(string message)
        {
            return message.Where(c => char.IsLetter(c)).Sum(c => c);
        }
    }
}
