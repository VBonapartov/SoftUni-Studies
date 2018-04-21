namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    [Alias("show")]
    public class ShowCourseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository = null;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string course = this.Data[1];
                this.repository.GetAllStudentsFromCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                string course = this.Data[1];
                string username = this.Data[2];

                this.repository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
