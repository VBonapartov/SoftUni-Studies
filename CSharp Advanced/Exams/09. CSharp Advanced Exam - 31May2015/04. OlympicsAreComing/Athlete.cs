namespace _04.OlympicsAreComing
{
    class Athlete
    {
        public Athlete(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public int Wins { get; set; }
    }
}
