namespace _01._Logger.Interfaces
{
    using _01._Logger.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorLevel { get; set; }

        void Append(IError error);
    }
}
