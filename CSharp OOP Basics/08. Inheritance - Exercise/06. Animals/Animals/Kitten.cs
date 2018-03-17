namespace _06._Animals.Animals
{
    public class Kitten : Cat
    {
        private const string KittenSound = "Meow";

        public Kitten(string name, int age, string gender) : base(name, age, "Female")
        {
        }

        public override string ProduceSound()
        {
            return KittenSound;
        }
    }
}
