namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;

    public class DropDatabaseCommand : Command
    {
        private const string ExecutionMessage = "Database dropped!";

        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine(ExecutionMessage);
        }
    }
}
