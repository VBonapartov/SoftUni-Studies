namespace _01.JediMeditation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> jedis = GetJedis();
            PrintSequenceForMeditation(jedis);
        }

        private static Dictionary<string, List<string>> GetJedis()
        {
            Dictionary<string, List<string>> jedis = new Dictionary<string, List<string>>();

            int lines = int.Parse(Console.ReadLine());

            for(int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');

                foreach (string jedi in cmdArgs)
                {
                    string jediType = jedi[0].ToString();

                    // Toshko and Slav -> special symbol "s"
                    jediType = jediType.Equals("t") ? "s" : jediType;

                    if (!jedis.ContainsKey(jediType))
                    {
                        jedis.Add(jediType, new List<string>());
                    }

                    jedis[jediType].Add(jedi);
                }
            }

            return jedis;
        }

        private static void PrintSequenceForMeditation(Dictionary<string, List<string>> jedis)
        {            
            string masterJedis = (jedis.ContainsKey("m")) ? string.Join(" ", jedis["m"]) : string.Empty;
            string knightJedis = (jedis.ContainsKey("k")) ? string.Join(" ", jedis["k"]) : string.Empty;
            string padawanJedis = (jedis.ContainsKey("p")) ? string.Join(" ", jedis["p"]) : string.Empty;
            string toshkoSlav = (jedis.ContainsKey("s")) ? string.Join(" ", jedis["s"]) : string.Empty;

            // Is there Yoda?
            if (jedis.ContainsKey("y"))
            {
                Console.WriteLine($"{masterJedis} {knightJedis} {toshkoSlav} {padawanJedis}");
            }
            else
            {
                Console.WriteLine($"{toshkoSlav} {masterJedis} {knightJedis} {padawanJedis}");
            }
        }
    }
}
