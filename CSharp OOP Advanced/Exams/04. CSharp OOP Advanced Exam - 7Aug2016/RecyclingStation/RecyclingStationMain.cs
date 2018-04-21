namespace RecyclingStation
{
    using System;
    using System.Collections.Generic;

    using BusinessLayer.Contracts.Core;
    using BusinessLayer.Contracts.Factories;
    using BusinessLayer.Contracts.IO;
    using BusinessLayer.Core;    
    using BusinessLayer.Factories;
    using BusinessLayer.IO;

    using WasteDisposal;
    using WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();

            IStrategyHolder strategyHolder = new StrategyHolder(strategies);

            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();

            IRecyclingStation recyclingStation = new RecyclingStation(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, recyclingStation);
            engine.Run();
        }
    }
}
