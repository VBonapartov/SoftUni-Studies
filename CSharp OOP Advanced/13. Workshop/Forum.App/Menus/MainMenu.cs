namespace Forum.App.Menus
{
	using Contracts;
	using Models;

    public class MainMenu : Menu
    {
		private ISession session;
		private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;

        public MainMenu(ISession session, ILabelFactory labelFactory, ICommandFactory commandFactory)
        {
            this.session = session;
			this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;

            this.Open();
        }
               
		public override IMenu ExecuteCommand()
		{
            string commandName = string.Join(string.Empty, this.CurrentOption.Text.Split()) + "Menu";

            ICommand command = this.commandFactory.CreateCommand(commandName);
            IMenu view = command.Execute();

            return view;
		}

        protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[] { "Categories", "Log In", "Sign Up" };

            if (this.session?.IsLoggedIn ?? false)
            {
                buttonContents[1] = "Add Post";
                buttonContents[2] = "Log Out";
            }

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 2),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 8),
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[]
            {
                "FORUM",
                string.Format("Hi, {0}", this.session?.Username),
            };

            Position[] labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 7),
            };

            this.Labels = new ILabel[labelContents.Length];

            int lastIndex = this.Labels.Length - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }

            this.Labels[lastIndex] = this.labelFactory
                .CreateLabel(labelContents[lastIndex], labelPositions[lastIndex], !this.session?.IsLoggedIn ?? true);
        }
    }
}
