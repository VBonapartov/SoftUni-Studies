namespace BashSoft.IO.Commands
{
    using System.Diagnostics;
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    
    [Alias("open")]
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
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
