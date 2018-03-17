namespace _04._HotelReservation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            PriceCalculator priceCalculator = new PriceCalculator(Console.ReadLine());
            string totalPrice = priceCalculator.CalculatePrice();

            Console.WriteLine(totalPrice);
        }
    }
}
