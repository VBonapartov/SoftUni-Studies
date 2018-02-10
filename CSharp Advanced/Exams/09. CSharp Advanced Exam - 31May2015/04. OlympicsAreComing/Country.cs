namespace _04.OlympicsAreComing
{
    using System.Collections.Generic;
    using System.Linq;

    class Country
    {
        private List<Athlete> athletes;

        public Country(string name)
        {
            this.Name = name;
            this.athletes = new List<Athlete>();
        }

        public string Name { get; private set; }

        public void AddAthlete(string name)
        {
            Athlete athlete = athletes.FirstOrDefault(a => a.Name.Equals(name));

            if (athlete == null)
            {
                athlete = new Athlete(name);
                athletes.Add(athlete);
            }

            athlete.Wins += 1;
        }

        public int NumberOfWins()
        {
            return this.athletes.Sum(a => a.Wins);
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.athletes.Count} participants): {this.NumberOfWins()} wins";
        }
    }
}
