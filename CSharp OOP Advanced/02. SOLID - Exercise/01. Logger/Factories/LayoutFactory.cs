namespace _01._Logger.Factories
{    
    using System;
    using System.Linq;
    using System.Reflection;
    using _01._Logger.Interfaces;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutName)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            Type layoutType = types.FirstOrDefault(t => t.Name.Equals(layoutName));
            if (layoutType == null)
            {
                throw new ArgumentException("Invalid Layout Type!");
            }

            ILayout layout = (ILayout)Activator.CreateInstance(layoutType);
            return layout;
        }
    }
}
