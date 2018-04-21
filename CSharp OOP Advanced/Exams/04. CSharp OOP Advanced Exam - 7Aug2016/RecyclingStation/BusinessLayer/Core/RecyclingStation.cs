namespace RecyclingStation.BusinessLayer.Core
{
    using BusinessLayer.Contracts.Factories;
    using Contracts.Core;    
    using WasteDisposal.Interfaces;

    public class RecyclingStation : IRecyclingStation
    {
        private const string RequirementsChangedMessage = "Management requirement changed!";
        private const string ProcessingDeniedMessage = "Processing Denied!";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double energyBalance;
        private double capitalBalance;

        private bool requirementsAreSet;

        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string garbageType;

        public RecyclingStation(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.requirementsAreSet)
            {
                bool requirementsAreSatisfied = true;
                if (type.Equals(this.garbageType))
                {
                    requirementsAreSatisfied = this.energyBalance >= this.minimumEnergyBalance &&
                                               this.capitalBalance >= this.minimumCapitalBalance;
                }

                if (!requirementsAreSatisfied)
                {
                    return ProcessingDeniedMessage;
                }
            }

            IWaste someWaste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(someWaste);
            this.energyBalance += processedData.EnergyBalance;
            this.capitalBalance += processedData.CapitalBalance;

            return $"{someWaste.Weight:F2} kg of {someWaste.Name} successfully processed!";
        }

        public string Status()
        {
            return $"Energy: {this.energyBalance:F2} Capital: {this.capitalBalance:F2}";
        }

        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string garbageType)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.garbageType = garbageType;

            this.requirementsAreSet = true;

            return RequirementsChangedMessage;
        }
    }
}
