namespace _10._Tuple
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            string name = cmdArgs[0] + " " + cmdArgs[1];
            string address = cmdArgs[2];
            MyTuple<string, string> firstTuple = new MyTuple<string, string>(name, address);

            cmdArgs = Console.ReadLine().Split();
            name = cmdArgs[0];
            int amountOfBeer = int.Parse(cmdArgs[1]);
            MyTuple<string, int> secondTuple = new MyTuple<string, int>(name, amountOfBeer);

            cmdArgs = Console.ReadLine().Split();
            int inputInt = int.Parse(cmdArgs[0]);
            double inputDouble = double.Parse(cmdArgs[1]);
            MyTuple<int, double> thirdTuple = new MyTuple<int, double>(inputInt, inputDouble);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}
