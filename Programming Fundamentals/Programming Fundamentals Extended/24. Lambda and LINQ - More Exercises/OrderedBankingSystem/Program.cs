using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedBankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> orderedBankingSystem = new Dictionary<string, Dictionary<string, decimal>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string bank = command[0];
                string account = command[1];
                decimal balance = decimal.Parse(command[2]);

                if (!orderedBankingSystem.ContainsKey(bank))
                {
                    orderedBankingSystem.Add(bank, new Dictionary<string, decimal>());
                }

                if(orderedBankingSystem[bank].ContainsKey(account))
                {
                    orderedBankingSystem[bank][account] += balance;
                }
                else
                {
                    orderedBankingSystem[bank].Add(account, balance);
                }
            }

            orderedBankingSystem = orderedBankingSystem
                                            .OrderByDescending(s => s.Value.Values.Sum())
                                            .ThenByDescending(s => s.Value.Values.Max())
                                            .ToDictionary(
                                                            bank => bank.Key, 
                                                            bank => bank.Value
                                                                            .OrderByDescending(account => account.Value)
                                                                            .ToDictionary(accout => accout.Key, account => account.Value)         
                                                          );

            PrintBankAccounts(orderedBankingSystem);
        }

        static private void PrintBankAccounts(Dictionary<string, Dictionary<string, decimal>> orderedBankingSystem)
        {
            foreach(KeyValuePair<string, Dictionary<string, decimal>> bank in orderedBankingSystem)
            {
                foreach(KeyValuePair<string, decimal> account in bank.Value)
                {
                    Console.WriteLine($"{account.Key} -> {account.Value} ({bank.Key})");
                }
            }
        }
    }
}
