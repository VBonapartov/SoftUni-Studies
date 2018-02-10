namespace _04.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            List<Concert> concerts = GetInputData();
            PrintResult(concerts);
        }

        private static List<Concert> GetInputData()
        {
            List<Concert> concerts = new List<Concert>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("End"))
            {
                if(!IsInputValid(input))
                {
                    continue;
                }

                (string singer, string venue, long totalMoney) = ParseInfoFromInput(input);

                Concert concert = concerts.FirstOrDefault(c => c.VenueName.Equals(venue));

                if(concert == null)
                {
                    concert = new Concert(venue);
                    concerts.Add(concert);
                }

                concert.AddSinger(singer, totalMoney);
            }

            return concerts;
        }

        static private bool IsInputValid(string input)
        {
            // Check for symbol '@'
            int indexAt = input.IndexOf('@');
            if (indexAt == -1)
                return false;

            // Before '@' -> ' '(space)
            if (!char.IsWhiteSpace(input[indexAt - 1]))
                return false;

            // Number of speces after '@' - from 3 to 7
            int countSpaces = input.Count(Char.IsWhiteSpace);
            if (countSpaces < 3 || countSpaces > 7)
                return false;

            string strAfterAt = input.Substring(indexAt + 1);
            string[] info = strAfterAt.Split(' ');
            int elementsInInfo = info.Length;

            // Check last two numbers - ticketsPrice and ticketsCount
            int result = 0;
            bool isTicketsPrice = int.TryParse(info[elementsInInfo - 1], out result);
            bool isTicketsCount = int.TryParse(info[elementsInInfo - 2], out result);
            if (!isTicketsPrice || !isTicketsCount)
                return false;

            return true;
        }

        static private (string singer, string venue, long totalMoney) ParseInfoFromInput(string input)
        {
            int indexAt = input.IndexOf('@');
            string strAfterAt = input.Substring(indexAt + 1);
            string[] info = strAfterAt.Split(' ');

            string singer = input.Substring(0, indexAt - 1);
            string venue = string.Empty;
            int ticketsPrice = 0;
            int ticketsCount = 0;

            // spaces are 2, 3 or 4 after @
            int countSpaces = strAfterAt.Count(Char.IsWhiteSpace);
            if (countSpaces == 2)
            {
                venue = info[0];
                ticketsPrice = Convert.ToInt32(info[1]);
                ticketsCount = Convert.ToInt32(info[2]);
            }
            else if (countSpaces == 3)
            {
                venue = info[0] + " " + info[1];
                ticketsPrice = Convert.ToInt32(info[2]);
                ticketsCount = Convert.ToInt32(info[3]);
            }
            else
            {
                venue = info[0] + " " + info[1] + " " + info[2];
                ticketsPrice = Convert.ToInt32(info[3]);
                ticketsCount = Convert.ToInt32(info[4]);
            }

            int totalMoney = ticketsPrice * ticketsCount;

            return (singer, venue, totalMoney);
        }

        private static void PrintResult(List<Concert> concerts)
        {
            foreach(Concert concert in concerts)
            {
                Console.WriteLine(concert);
            }
        }
    }

    class Concert
    {
        private List<Singer> singers;

        public Concert(string venueName)
        {
            this.VenueName = venueName;
            this.singers = new List<Singer>();
        }

        public string VenueName { get; private set; }

        public void AddSinger(string name, long money)
        {
            Singer singer = singers.FirstOrDefault(s => s.Name.Equals(name));

            if(singer == null)
            {
                singer = new Singer(name);
                this.singers.Add(singer);
            }

            singer.AddMoney(money);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.VenueName);

            foreach(Singer singer in this.singers.OrderByDescending(s => s.Money))
            {
                sb.AppendLine($"#  {singer.Name} -> {singer.Money}");
            }

            return sb.ToString().Trim();
        }
    }

    class Singer
    {
        public Singer(string name)
        {
            this.Name = name;
            this.Money = 0;
        }

        public string Name { get; private set; }

        public long Money { get; private set; }

        public void AddMoney(long money)
        {
            this.Money += money;
        }
    }
}
