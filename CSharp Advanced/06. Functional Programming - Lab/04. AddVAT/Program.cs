namespace _04.AddVAT
{
    using System;
    using System.Linq;

    class Program
    {
        private const double VAT = 0.20;

        static void Main(string[] args)
        {
            Func<double, double> addVAT = d => d + d * VAT;

            Console.WriteLine(
                                string.Join(Environment.NewLine,
                                            Console.ReadLine()
                                                        .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(double.Parse)
                                                        .Select(d => string.Format($"{addVAT(d):F2}"))
                                           )
                             );
        }
    }
}
