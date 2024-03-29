﻿namespace BashSoft.IO.Commands
{
    using BashSoft.Exceptions;

    public class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string databasePath = this.Data[1];
            this.Repository.LoadData(databasePath);
        }
    }
}
