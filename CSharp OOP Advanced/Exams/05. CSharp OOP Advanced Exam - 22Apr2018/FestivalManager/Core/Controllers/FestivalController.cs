namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

        private readonly IStage stage;

        private ISetFactory setFactory;
        private ISongFactory songFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;        

		public FestivalController(IStage stage, ISetFactory setFactory, ISongFactory songFactory, IPerformerFactory performerFactory, IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
            this.performerFactory = performerFactory;
            this.instrumentFactory = instrumentFactory;
        }

		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			IInstrument[] instruments = args.Skip(2)
                                        .Select(i => this.instrumentFactory.CreateInstrument(i))
				                        .ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);
            this.stage.AddPerformer(performer);

            foreach (IInstrument instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}            		

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string songName = args[0];
            string strDuration = args[1];

            bool isParse = TimeSpan.TryParseExact(strDuration, TimeFormat, CultureInfo.InvariantCulture, out TimeSpan duration);

            if (!isParse)
            {
                // error
            }

            ISong song = this.songFactory.CreateSong(songName, duration);
            this.stage.AddSong(song);

			return $"Registered song {songName} ({duration.ToString(TimeFormat)})";
		}

		public string AddSongToSet(string[] args)
		{
			string songName = args[0];
			string setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			ISet set = this.stage.GetSet(setName);
			ISong song = this.stage.GetSong(songName);

			set.AddSong(song);

            return $"Added {songName} ({ song.Duration.ToString(TimeFormat)}) to {setName}";
        }

		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            
            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				                                    .SelectMany(p => p.Instruments)
				                                    .Where(i => i.Wear < 100)
				                                    .ToArray();

			foreach (IInstrument instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine($"Festival length: {this.FormatTime(totalFestivalLength)}");

            foreach (ISet set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({this.FormatTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);

                foreach (IPerformer performer in performersOrderedDescendingByAge)
                {
                    List<string> instruments = new List<string>();

                    foreach (var instrument in performer.Instruments.OrderByDescending(i => i.Wear))
                    {
                        instruments.Add(instrument.ToString());
                    }

                    result.AppendLine($"---{performer.Name} ({string.Join(", ", instruments)})");
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine("--No songs played");
                }
                else
                {
                    result.AppendLine("--Songs played:");

                    foreach (ISong song in set.Songs)
                    {
                        result.AppendLine($"----{song.Name} ({this.FormatTime(song.Duration)})");
                    }
                }
            }

            return result.ToString().Trim();
        }

        private string FormatTime(TimeSpan ts)
        {
            int mins = (ts.Days * 1440) + (ts.Hours * 60) + ts.Minutes;
            int secs = ts.Seconds;

            return $"{mins:D2}:{secs:D2}";
        }
    }
}