namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeOfSet = Assembly
                                    .GetCallingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals(type));

            if (typeOfSet == null)
            {
                throw new ArgumentException("Invalid Set type!");
            }

            if (!typeof(ISet).IsAssignableFrom(typeOfSet))
            {
                throw new ArgumentException($"{typeOfSet} is not a Set type!");
            }

            ISet set = (ISet)Activator.CreateInstance(typeOfSet, name);
            return set;
        }
	}
}
