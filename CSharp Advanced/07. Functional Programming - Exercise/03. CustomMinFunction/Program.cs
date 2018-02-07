namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Func<double[], double> customMinFunc = nums =>
            {
                double min = int.MaxValue;

                foreach (double num in nums)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                return min;
            };

            double minValue = customMinFunc(Console.ReadLine()
                                                        .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(double.Parse)
                                                        .ToArray()
                                            );

            Console.WriteLine(minValue);
        }
    }
}
