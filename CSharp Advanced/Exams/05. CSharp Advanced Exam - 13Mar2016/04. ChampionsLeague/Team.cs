namespace _04.ChampionsLeague
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Team
    {
        private List<string> opponents;

        public Team(string name)
        {
            this.Name = name;
            this.Wins = 0;
            this.opponents = new List<string>();
        }

        public string Name { get; private set; }

        public int Wins { get; private set; }

        public void IncreaseWins()
        {
            this.Wins++;
        }

        public void AddOpponent(string opponent)
        {
            this.opponents.Add(opponent);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.Name);
            sb.AppendLine($"- Wins: {this.Wins}");
            sb.AppendLine($"- Opponents: {string.Join(", ", this.opponents.OrderBy(o => o))}");

            return sb.ToString().Trim();
        }
    }
}
