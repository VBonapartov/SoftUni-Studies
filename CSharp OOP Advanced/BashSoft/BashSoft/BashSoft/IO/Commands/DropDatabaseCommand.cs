namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command, IExecutable
    {
        private const string ExecutionMessage = "Database dropped!";

        [Inject]
        private IDatabase repository = null;

        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine(ExecutionMessage);
        }
    }
}
