using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> demons = Console
                                        .ReadLine()
                                        .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => s.Trim())
                                        .ToList();

            SortedDictionary<string, List<double>> demonsHealthAndDamage = new SortedDictionary<string, List<double>>();
            for (int i = 0; i < demons.Count; i++)
            {
                int demonHealth = GetHealth(demons[i]);
                double demonDamage = GetDamage(demons[i]);

                demonsHealthAndDamage.Add(demons[i], new List<double> { demonHealth, demonDamage });
            }

            PrintDemons(demonsHealthAndDamage);
        }

        private static int GetHealth(string demon)
        {
            string healthPattern = @"[^0-9\+\-\*\/\.]+";

            MatchCollection matchHealth = Regex.Matches(demon, healthPattern);
            int totalHealth = matchHealth.Cast<Match>().Select(d => d.Value.Sum(ch => (int)ch)).Sum();

            return totalHealth;
        }

        private static double GetDamage(string demon)
        {
            string damagePattern = @"[+-]?\d+(\.\d+)?";

            double totalDamage = 0;
            MatchCollection matchDamage = Regex.Matches(demon, damagePattern);
            foreach (Match match in matchDamage)
            {
                string value = match.Value;
                if (value[0].ToString().Equals("-"))
                {
                    totalDamage -= Convert.ToDouble(value.Substring(1));
                }
                else if (value[0].ToString().Equals("+"))
                {
                    totalDamage += Convert.ToDouble(value.Substring(1));
                }
                else
                {
                    totalDamage += Convert.ToDouble(value);
                }
            }

            MatchCollection damageMulDiv = Regex.Matches(demon, @"[*/]");
            foreach (Match match in damageMulDiv)
            {
                if (match.Value.Equals("*"))
                {
                    totalDamage *= 2;
                }
                else
                {
                    totalDamage /= 2;
                }
            }

            return totalDamage;
        }

        private static void PrintDemons(SortedDictionary<string, List<double>> demonsHealthAndDamage)
        {
            foreach(KeyValuePair<string, List<double>> demon in demonsHealthAndDamage)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:F2} damage");
            }
        }
    }
}
