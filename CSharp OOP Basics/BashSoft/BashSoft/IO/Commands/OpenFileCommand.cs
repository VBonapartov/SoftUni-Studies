﻿namespace BashSoft.IO.Commands
{
    using System.Diagnostics;
    using BashSoft.Exceptions;    

    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);                
            }
            else
            {
                string fileName = this.Data[1];
                Process.Start(SessionData.CurrentPath + "\\" + fileName);
            }
        }
    }
}
