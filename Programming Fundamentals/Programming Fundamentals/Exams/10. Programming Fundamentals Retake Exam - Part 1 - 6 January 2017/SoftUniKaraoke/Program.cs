using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class Participant
    {
        public string Name { get; set; }
        public HashSet<string> Awards { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Awards.Count == 0)
                sb.Append("No awards");
                        
            sb.AppendFormat($"{this.Name}: {this.Awards.Count} awards");
            foreach(string award in this.Awards.OrderBy(p => p))
            {
                if (sb.Length > 0)
                    sb.Append(Environment.NewLine);

                sb.AppendFormat($"--{award}");
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> allParticipants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<Participant> participants = new List<Participant>();
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("dawn"))
            {
                string[] tokens = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string participantName = tokens[0];
                string song = tokens[1];
                string award = tokens[2];

                if (!allParticipants.Contains(participantName) || !songs.Contains(song))
                    continue;

                participants = AddParticipantInfo(participants, participantName, award);
            }

            PrintParticipants(participants);
        }

        private static List<Participant> AddParticipantInfo(List<Participant> participants, string participantName, string award)
        {
            if(!participants.Exists(p => p.Name.Equals(participantName)))
            {
                Participant newParticipant = new Participant
                {
                    Name = participantName,
                    Awards = new HashSet<string> { }
                };

                participants.Add(newParticipant);
            }

            Participant participant = participants.Where(p => p.Name.Equals(participantName)).First();
            participant.Awards.Add(award);

            return participants;
        }

        private static void PrintParticipants(List<Participant> participants)
        {
            if(participants.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            participants = participants.OrderByDescending(p => p.Awards.Count).ThenBy(p => p.Name).ToList();

            foreach(Participant participant in participants)
            {
                Console.WriteLine(participant);
            }
        }

    }
}
