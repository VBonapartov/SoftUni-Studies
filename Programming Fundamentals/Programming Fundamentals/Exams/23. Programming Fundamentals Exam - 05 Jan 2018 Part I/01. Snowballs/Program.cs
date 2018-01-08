namespace _01.Snowballs
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            BigInteger maxSnowballValue = 0;
            int snowballSnow = int.MinValue;
            int snowballTime = int.MinValue;
            int snowballQuality = int.MinValue;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int CurrentSnowballSnow = int.Parse(Console.ReadLine());
                int CurrentSnowballTime = int.Parse(Console.ReadLine());
                int CurrentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((CurrentSnowballSnow / CurrentSnowballTime), CurrentSnowballQuality);

                if (snowballValue > maxSnowballValue)
                {
                    maxSnowballValue = snowballValue;
                    snowballSnow = CurrentSnowballSnow;
                    snowballTime = CurrentSnowballTime;
                    snowballQuality = CurrentSnowballQuality;
                }
            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {maxSnowballValue} ({snowballQuality})");
        }
    }
}
