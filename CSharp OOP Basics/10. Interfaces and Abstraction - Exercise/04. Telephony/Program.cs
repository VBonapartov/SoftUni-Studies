namespace _04._Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> phones = GetPhones();
            List<string> sites = GetPhones();

            ISmartphone phone = new Smartphone("Smartphone");
            TestPhone(phone, phones);
            TestSites(phone, sites);
        }

        private static List<string> GetPhones()
        {
            return Console.ReadLine().Split(' ').ToList();
        }

        private static List<string> GetSites()
        {
            return Console.ReadLine().Split(' ').ToList();
        }

        private static void TestPhone(ISmartphone phone, IList<string> phones)
        {
            foreach (string number in phones)
            {
                Console.WriteLine(phone.Call(number));
            }
        }

        private static void TestSites(ISmartphone phone, IList<string> sites)
        {
            foreach (string site in sites)
            {
                Console.WriteLine(phone.Browse(site));
            }
        }
    }
}
