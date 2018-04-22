namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly IList<ISet> sets;
		private readonly IList<ISong> songs;
		private readonly IList<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => (IReadOnlyCollection<ISet>)this.sets;

        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;

        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>)this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
           this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(p => p.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            bool hasPerformer = this.performers.Any(p => p.Name.Equals(name));
            return hasPerformer;
        }

        public bool HasSet(string name)
        {
            bool hasSet = this.sets.Any(s => s.Name.Equals(name));
            return hasSet;
        }

        public bool HasSong(string name)
        {
            bool hasSong = this.songs.Any(s => s.Name.Equals(name));
            return hasSong;
        }
    }
}
