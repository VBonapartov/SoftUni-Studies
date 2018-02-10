namespace _07.VladkosNotebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static List<Sheet> notebook;

        static void Main(string[] args)
        {
            GetInputData();
            PrintStats();
        }

        private static void GetInputData()
        {
            notebook = new List<Sheet>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split('|');
                string colorName = cmdArgs[0];

                Sheet sheet = notebook.FirstOrDefault(s => s.ColorName.Equals(colorName));

                if(sheet == null)
                {
                    sheet = new Sheet(colorName);
                    notebook.Add(sheet);
                }

                switch(cmdArgs[1])
                {
                    case "name":
                        sheet.PlayerName = cmdArgs[2];
                        break;

                    case "age":
                        sheet.Age = int.Parse(cmdArgs[2]);
                        break;

                    case "win":
                    case "loss":
                        sheet.AddOpponents(cmdArgs[1], cmdArgs[2]);
                        break;
                }
            }
        }

        private static void PrintStats()
        {
            if(notebook.All(s => s.PlayerName.Equals("") || s.Age == 0))
            {
                Console.WriteLine("No data recovered.");
            }
            
            foreach(Sheet sheet in notebook.OrderBy(s => s.ColorName))
            {
                string sheetInfo = sheet.ToString();

                if(!sheetInfo.Equals(""))
                {
                    Console.WriteLine(sheetInfo);
                }
            }
        }
    }

    class Sheet
    {
        private int wins;
        private int loss;
        private List<string> opponents;

        public Sheet(string colorName)
        {
            this.ColorName = colorName;
            this.PlayerName = "";
            this.Age = 0;
            this.wins = 0;
            this.loss = 0;
            this.opponents = new List<string>();
        }

        public string ColorName { get; private set; }

        public string PlayerName { get; set; }

        public int Age { get; set; }

        public void AddOpponents(string winOrLoss, string opponent)
        {
            this.opponents.Add(opponent);

            if(winOrLoss.Equals("win"))
            {
                this.wins++;
            }
            else
            {
                this.loss++;
            }
        }

        private double GetRank()
        {
            return (double)(this.wins + 1) / (this.loss + 1);
        }

        public override string ToString()
        {
            if(this.PlayerName.Equals("") || this.Age == 0)
            {
                return "";
            }

            this.opponents.Sort(StringComparer.Ordinal);
            string opponentsStr = (this.opponents.Any()) ? string.Join(", ", this.opponents) : "(empty)";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Color: {this.ColorName}");
            sb.AppendLine($"-age: {this.Age}");
            sb.AppendLine($"-name: {this.PlayerName}");
            sb.AppendLine($"-opponents: {opponentsStr}");
            sb.Append($"-rank: {this.GetRank():F2}");

            return sb.ToString();
        }
    }
}
