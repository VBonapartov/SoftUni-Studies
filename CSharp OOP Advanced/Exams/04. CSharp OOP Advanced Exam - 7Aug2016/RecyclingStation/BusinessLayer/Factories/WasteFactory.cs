namespace RecyclingStation.BusinessLayer.Factories
{    
    using System;
    using System.Linq;
    using System.Reflection;
    using BusinessLayer.Contracts.Factories;
    using WasteDisposal.Interfaces;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string fullTypeName = type + GarbageSuffix;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type typeOfGarbageToActivate = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            if (typeOfGarbageToActivate == null)
            {
                throw new ArgumentException();
            }

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, new object[] { name, weight, volumePerKg });
            return waste;
        }
    }
}
