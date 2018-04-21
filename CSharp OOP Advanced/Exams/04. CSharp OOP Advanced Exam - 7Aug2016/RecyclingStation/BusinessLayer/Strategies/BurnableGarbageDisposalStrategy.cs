namespace RecyclingStation.BusinessLayer.Strategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double totalVolume = garbage.CalculateWasteTotalVolume();

            double energyProduced = totalVolume;
            double energyUsed = totalVolume * 0.20;

            return energyProduced - energyUsed;
        }
    }
}
