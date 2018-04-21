namespace _01._Logger.Factories
{    
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using _01._Logger.Attributes;
    using _01._Logger.Interfaces;

    public class AppenderFactory
    {
        private string defaultFileName = "LogFile.txt";

        private LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderName, string layoutName)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            ILayout layout = this.layoutFactory.CreateLayout(layoutName);

            Type appenderType = types.FirstOrDefault(t => t.Name.Equals(appenderName));
            if (appenderType == null)
            {
                throw new ArgumentException("Invalid Appender Type!");
            }

            IAppender appender = (IAppender)Activator.CreateInstance(appenderType, new object[] { layout });
            this.InjectDependencies(appenderType, appender);

            return appender;
        }

        private void InjectDependencies(Type appenderType, IAppender appender)
        {
            FieldInfo[] appenderFields = appenderType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] factoryFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo appenderField in appenderFields)
            {
                if (appenderField.GetCustomAttributes(typeof(InjectAttribute)) == null)
                {
                    continue;
                }

                if (factoryFields.Any(ifield => ifield.FieldType.Equals(appenderField.FieldType)))
                {
                    string filePath = Path.Combine(Environment.CurrentDirectory, this.defaultFileName);
                    appenderField.SetValue(appender, filePath);
                    break;
                }
            }
        }
    }
}
