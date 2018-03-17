namespace _05._MordorsCrueltyPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Factories.Foods;
    using Factories.Moods;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Food> foods = GetFoods();

            int happinessPoints = CalcHappinessPoints(foods);
            Console.WriteLine(happinessPoints);
            Console.WriteLine(GetCurrentMood(happinessPoints));
        }

        private static List<Food> GetFoods()
        {
            return Console.ReadLine()
                                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Where(f => !f.Equals(string.Empty))
                                    .Select(f => FoodFactory.GetFood(f))
                                    .ToList();
        }

        private static int CalcHappinessPoints(List<Food> foods)
        {
            return foods.Sum(f => f.PointsOfHappiness);
        }

        private static Mood GetCurrentMood(int happinessPoints)
        {
            return MoodFactory.GetMood(happinessPoints);
        }
    }
}
