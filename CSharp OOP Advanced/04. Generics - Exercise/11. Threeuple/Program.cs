namespace _11._Threeuple
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            string name = cmdArgs[0] + " " + cmdArgs[1];
            string address = cmdArgs[2];
            string town = cmdArgs[3];
            MyThreeuple<string, string, string> firstThreeuple = new MyThreeuple<string, string, string>(name, address, town);

            cmdArgs = Console.ReadLine().Split();
            name = cmdArgs[0];
            int amountOfBeer = int.Parse(cmdArgs[1]);
            bool drunkOrNot = cmdArgs[2].Equals("drunk") ? true : false;
            MyThreeuple<string, int, bool> secondThreeuple = new MyThreeuple<string, int, bool>(name, amountOfBeer, drunkOrNot);

            cmdArgs = Console.ReadLine().Split();
            name = cmdArgs[0];
            double accountBalance = double.Parse(cmdArgs[1]);
            string bankName = cmdArgs[2];
            MyThreeuple<string, double, string> thirdThreeuple = new MyThreeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine($"{firstThreeuple.Item1} -> {firstThreeuple.Item2} -> {firstThreeuple.Item3}");
            Console.WriteLine($"{secondThreeuple.Item1} -> {secondThreeuple.Item2} -> {secondThreeuple.Item3}");
            Console.WriteLine($"{thirdThreeuple.Item1} -> {thirdThreeuple.Item2} -> {thirdThreeuple.Item3}");
        }
    }
}
