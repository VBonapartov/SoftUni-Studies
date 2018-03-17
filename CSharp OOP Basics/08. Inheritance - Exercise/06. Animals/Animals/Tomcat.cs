namespace _06._Animals.Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatSound = "MEOW";

        public Tomcat(string name, int age, string gender) : base(name, age, "Male")
        {
        }

        public override string ProduceSound()
        {
            return TomcatSound;
        }
    }
}
