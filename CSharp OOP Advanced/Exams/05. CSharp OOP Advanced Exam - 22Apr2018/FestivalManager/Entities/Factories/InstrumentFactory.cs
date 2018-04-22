namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type typeOfInstrument = Assembly
                                    .GetCallingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals(type));

            if (typeOfInstrument == null)
            {
                throw new ArgumentException("Invalid Instrument type!");
            }

            if (!typeof(IInstrument).IsAssignableFrom(typeOfInstrument))
            {
                throw new ArgumentException($"{typeOfInstrument} is not an Instrument type!");
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(typeOfInstrument);
            return instrument;
        }
	}
}