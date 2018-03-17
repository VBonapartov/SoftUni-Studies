namespace _05._PizzaCalories
{
    using System;  

    public class Program
    {
        public static void Main(string[] args)
        {   
            try
            {
                Pizza pizza = CreatePizza();

                string command = string.Empty;
                while (!(command = Console.ReadLine()).Equals("END"))
                {
                    AddTopping(command, pizza);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        private static Pizza CreatePizza()
        {
            string pizzaName = Console.ReadLine().Split(" ")[1];

            Dough dough = CreateDough();
            Pizza pizza = new Pizza(pizzaName, dough);

            return pizza;
        }

        private static Dough CreateDough()
        {
            string[] doughTypeAndTechnique = Console.ReadLine().Split(" ");
            string flourType = doughTypeAndTechnique[1];
            string technique = doughTypeAndTechnique[2];
            int weight = int.Parse(doughTypeAndTechnique[3]);

            Dough dough = new Dough(flourType, technique, weight);

            return dough;
        }

        private static void AddTopping(string command, Pizza pizza)
        {
            string[] toppingInput = command.Split(" ");
            string toppingType = toppingInput[1];
            int toppingWeight = int.Parse(toppingInput[2]);

            Topping topping = new Topping(toppingType, toppingWeight);
            pizza.AddTopping(topping);
        }
    }
}
