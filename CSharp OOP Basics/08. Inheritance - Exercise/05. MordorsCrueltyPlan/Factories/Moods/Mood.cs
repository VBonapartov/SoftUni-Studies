namespace _05._MordorsCrueltyPlan.Factories.Moods
{
    public abstract class Mood
    {
        private int happinessPoints;

        public Mood(int happinessPoints)
        {
            this.happinessPoints = happinessPoints;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
