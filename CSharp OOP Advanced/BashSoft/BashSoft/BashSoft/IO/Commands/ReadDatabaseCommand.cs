namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("readDb")]
    public class ReadDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository = null;

        public ReadDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string databasePath = this.Data[1];
            this.repository.LoadData(databasePath);
        }
    }
}
