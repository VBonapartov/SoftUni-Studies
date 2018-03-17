namespace Forum.App.Controllers
{
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public AddReplyController()
        {
            this.ResetReply();
        }

        private enum Command
        {
            Write, Post, Back
        }

        public ReplyViewModel Reply { get; private set; }

        public bool Error { get; private set; }

        private PostViewModel PostViewModel { get; set; }

        private TextArea TextArea { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;

                case Command.Post:
                    bool validReply = PostService.TrySaveReply(this.Reply, this.PostViewModel.PostId);
                    if (!validReply)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }

                    return MenuState.ReplyAdded;

                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.PostViewModel, this.Reply, this.TextArea, this.Error);
        }

        public void SetPostId(int postId)
        {
            this.PostViewModel = PostService.GetPostViewModel(postId);
            this.ResetReply();
        }

        private void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            int contentLength = this.PostViewModel?.Content.Count ?? 0;
            this.TextArea = new TextArea(centerLeft - 18, centerTop + contentLength - 6, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }
    }
}
