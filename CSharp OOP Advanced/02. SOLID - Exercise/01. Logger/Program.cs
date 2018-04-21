namespace _01._Logger
{
    using System.Collections.Generic;
    using _01._Logger.Controllers;
    using _01._Logger.Entities;
    using _01._Logger.Factories;
    using _01._Logger.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            IList<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            ErrorFactory errorFactory = new ErrorFactory();
            
            Controller controller = new Controller(appenders, appenderFactory, errorFactory);

            controller.ReadAppendersFromConsole();
            ILogger logger = new Logger(new List<IAppender>(controller.Appenders).ToArray());

            controller.ExecuteCommands(logger);
        }
    }
}
