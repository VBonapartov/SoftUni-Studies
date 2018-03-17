namespace _06._Animals.Animals
{
    public class Dog : Animal
    {
        private const string DogSound = "Woof!";

        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return DogSound;
        }
    }
}
