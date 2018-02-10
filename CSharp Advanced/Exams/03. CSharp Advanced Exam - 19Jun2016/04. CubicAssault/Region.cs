namespace _04.CubicAssault
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Region
    {
        private Dictionary<string, long> soldiers;

        public Region(string name)
        {
            this.Name = name;
            this.soldiers = new Dictionary<string, long>
            {
                { "Green", 0L },
                { "Red", 0L },
                { "Black", 0L }
            };
        }

        public string Name { get; private set; }

        public void AddSoldier(string soldierType, int countOfSoldiers)
        {
            if (!soldiers.ContainsKey(soldierType))
                return;

            this.soldiers[soldierType] += countOfSoldiers;

            this.CombineSoldiers();
        }

        private void CombineSoldiers()
        {
            if (this.soldiers["Green"] >= 1_000_000)
            {
                long combineInRed = this.soldiers["Green"] / 1_000_000;

                this.soldiers["Green"] -= combineInRed * 1_000_000;
                this.soldiers["Red"] += combineInRed;
            }

            if (this.soldiers["Red"] >= 1_000_000)
            {
                long combineInBlack = this.soldiers["Red"] / 1_000_000;

                this.soldiers["Red"] -= combineInBlack * 1_000_000;
                this.soldiers["Black"] += combineInBlack;
            }
        }

        public long GetNumberOfBlackMeteors()
        {
            return this.soldiers["Black"];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.soldiers = this.soldiers
                            .OrderByDescending(s => s.Value)
                            .ThenBy(s => s.Key)
                            .ToDictionary(s => s.Key, s => s.Value);

            sb.AppendLine(this.Name);

            foreach (KeyValuePair<string, long> soldier in this.soldiers)
            {
                sb.AppendLine($"-> {soldier.Key} : {soldier.Value}");
            }

            return sb.ToString().Trim();
        }
    }
}
