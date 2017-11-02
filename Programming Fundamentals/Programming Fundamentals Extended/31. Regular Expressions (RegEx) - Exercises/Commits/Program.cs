using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commits
{
    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public long Additions { get; set; }
        public long Deletions { get; set; }
    }

    class Repo
    {
        public string Name { get; set; }
        public List<Commit> Commits { get; set; }

        public long GetTotalAdditions()
        {
            return this.Commits.Sum(c => c.Additions);
        }

        public long GetTotalDeletions()
        {
            return this.Commits.Sum(c => c.Deletions);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"  {this.Name}:");

            foreach (Commit commit in this.Commits)
            {
                sb.AppendFormat(Environment.NewLine + $"    commit {commit.Hash}: {commit.Message} ({commit.Additions} additions, {commit.Deletions} deletions)");
            }
            sb.AppendFormat(Environment.NewLine + $"    Total: {GetTotalAdditions()} additions, {GetTotalDeletions()} deletions");

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "https:\\/\\/github\\.com\\/(?<user>[A-Za-z0-9-]+)\\/(?<repo>[A-Z-a-z-_]+)\\/commit\\/(?<hash>[0-9a-f]{40}),(?<message>[^\\r\\n|\\r|\\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)";
            Dictionary<string, List<Repo>> usersRepos = new Dictionary<string, List<Repo>>();            

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("git push"))
            {
                Match gitInfo = Regex.Match(input, pattern);
                if (!gitInfo.Success)
                    continue;

                string user = gitInfo.Groups["user"].Value;
                string repo = gitInfo.Groups["repo"].Value;
                string hash = gitInfo.Groups["hash"].Value;
                string message = gitInfo.Groups["message"].Value;
                long additions = Convert.ToInt64(gitInfo.Groups["additions"].Value);
                long deletions = Convert.ToInt64(gitInfo.Groups["deletions"].Value);

                if (!usersRepos.ContainsKey(user))
                {
                    usersRepos.Add(user, new List<Repo> { });
                }

                Commit newCommit = new Commit
                {
                    Hash = hash,
                    Message = message,
                    Additions = additions,
                    Deletions = deletions
                };

                if (!usersRepos[user].Exists(r => r.Name.Equals(repo)))
                {
                    Repo newRepo = new Repo
                    {
                        Name = repo,
                        Commits = new List<Commit> { newCommit }
                    };

                    usersRepos[user].Add(newRepo);
                }
                else
                {
                    Repo exRepo = usersRepos[user].Where(r => r.Name.Equals(repo)).First();
                    exRepo.Commits.Add(newCommit);
                }             
            }

            PrintCommits(usersRepos);
        }

        private static void PrintCommits(Dictionary<string, List<Repo>> usersRepos)
        {
            foreach(KeyValuePair<string, List<Repo>> userRepo in usersRepos.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{userRepo.Key}:");
                
                foreach(Repo repo in userRepo.Value.OrderBy(r => r.Name))
                {
                    Console.WriteLine(repo);
                }
            }
        }
    }
}
