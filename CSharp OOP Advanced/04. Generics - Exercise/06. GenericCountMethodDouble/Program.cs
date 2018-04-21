namespace _06._GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<double>> doubles = GetInputDoubles();
            ComparingByValue(doubles);
        }

        private static List<Box<double>> GetInputDoubles()
        {
            List<Box<double>> doubles = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                doubles.Add(box);
            }

            return doubles;
        }

        private static void ComparingByValue(List<Box<double>> doubles)
        {
            double element = double.Parse(Console.ReadLine());

            int count = Box<double>.CompareByValue(doubles, element);
            Console.WriteLine(count);
        }
    }
}
