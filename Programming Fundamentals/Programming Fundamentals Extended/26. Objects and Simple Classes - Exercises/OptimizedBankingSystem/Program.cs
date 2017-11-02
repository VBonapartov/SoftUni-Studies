using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedBankingSystem
{
    class BankAccount
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public decimal Balance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> bankAccounts = ReadBankAccounts();
            PrintReadBankAccounts(bankAccounts);
        }

        private static List<BankAccount> ReadBankAccounts()
        {
            Dictionary<string, List<BankAccount>> bankAccounts = new Dictionary<string, List<BankAccount>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                BankAccount bankAccount = ReadBankAccount(input);

                if(!bankAccounts.ContainsKey(bankAccount.Bank))
                {
                    bankAccounts.Add(bankAccount.Bank, new List<BankAccount> { });
                }

                if(bankAccounts[bankAccount.Bank].Exists(b => b.Name.Equals(bankAccount.Name)))
                {
                    int index = bankAccounts[bankAccount.Bank]
                                                .Select((b, i) => i)
                                                .First(i => bankAccounts[bankAccount.Bank][i].Name.Equals(bankAccount.Name));

                    bankAccounts[bankAccount.Bank][index].Balance += bankAccount.Balance;
                }
                else
                {
                    bankAccounts[bankAccount.Bank].Add(bankAccount);
                }             
            }
            
            return bankAccounts.Select(b => b.Value).SelectMany(x => x).ToList();
        }

        private static BankAccount ReadBankAccount(string input)
        {
            string[] command = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            BankAccount bankAccount = new BankAccount
            {
                Bank = command[0],
                Name = command[1],
                Balance = decimal.Parse(command[2])
            };

            return bankAccount;
        }

        private static void PrintReadBankAccounts(List<BankAccount> bankAccounts)
        {
            bankAccounts = bankAccounts.OrderByDescending(a => a.Balance).ThenBy(a => a.Bank.Length).ToList();

            foreach (BankAccount bankAccount in bankAccounts)
            {
                Console.WriteLine($"{bankAccount.Name} -> {bankAccount.Balance} ({bankAccount.Bank})");
            }
        }
    }
}
