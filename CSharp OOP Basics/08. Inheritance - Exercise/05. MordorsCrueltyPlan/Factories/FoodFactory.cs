namespace _05._MordorsCrueltyPlan.Factories
{    
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Foods;

    public class FoodFactory
    {
        public static Food GetFood(string foodType)
        {
            foodType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodType.ToLower());

            Type typeOfFood = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals(foodType));

            if (typeOfFood == null)
            {
                typeOfFood = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals("Other"));
            }

            if (typeOfFood == null)
            {
                throw new ArgumentException("Invalid input!");
            }

            return (Food)Activator.CreateInstance(typeOfFood);
        }
    }
}
