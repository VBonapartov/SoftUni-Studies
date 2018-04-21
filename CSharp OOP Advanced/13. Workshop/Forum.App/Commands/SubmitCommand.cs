namespace Forum.App.Commands
{
    using System;
    using Forum.App.Contracts;    

    public class SubmitCommand : ICommand
    {
        private const string ErrorMessage = "Cannot add an empty reply!";

        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyText = args[0];

            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException(ErrorMessage);
            }

            int postId = int.Parse(args[1]);
            int authorId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, authorId);

            return this.session.Back();
        }
    }
}
