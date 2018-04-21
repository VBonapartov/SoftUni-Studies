namespace Forum.App
{
	using System;
	using Contracts;
	using Menus;
    using Microsoft.Extensions.DependencyInjection;

    internal class MenuController : IMainController
	{
		private IServiceProvider serviceProvider;

		private IForumViewEngine viewEngine;
		private ISession session;
		private ICommandFactory commandFactory;

		public MenuController(IServiceProvider serviceProvider, IForumViewEngine viewEngine, ISession session, ICommandFactory commandFactory)
		{
            this.serviceProvider = serviceProvider;
			this.viewEngine = viewEngine;
            this.session = session;
            this.commandFactory = commandFactory;

            this.InitializeSession();
        }

		private string Username { get; set; }

		private IMenu CurrentMenu => this.session.CurrentMenu;

		public void MarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption);
		}

		public void UnmarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption, false);
		}

		public void NextOption()
		{
			this.CurrentMenu.NextOption();
		}

		public void PreviousOption()
		{
			this.CurrentMenu.PreviousOption();
		}

		public void Back()
		{
			this.session.Back();
			this.RenderCurrentView();
		}

		public void Execute()
		{
			this.session.PushView(this.CurrentMenu.ExecuteCommand());
			this.RenderCurrentView();
		}

        private void InitializeSession()
        {
            this.session.PushView(new MainMenu(this.session,
                this.serviceProvider.GetService<ILabelFactory>(),
                this.serviceProvider.GetService<ICommandFactory>()));

            this.RenderCurrentView();
        }

        private void RenderCurrentView()
        {
            this.viewEngine.RenderMenu(this.CurrentMenu);
        }
    }
}