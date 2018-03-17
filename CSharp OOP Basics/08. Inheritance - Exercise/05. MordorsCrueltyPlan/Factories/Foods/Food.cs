namespace _05._MordorsCrueltyPlan.Factories.Foods
{
    public abstract class Food
    {
        private int pointsOfHappiness;

        public Food(int pointsOfHappiness)
        {
            this.PointsOfHappiness = pointsOfHappiness;
        }

        public int PointsOfHappiness
        {
            get
            {
                return this.pointsOfHappiness;
            }

            private set
            {
                this.pointsOfHappiness = value;
            }
        }
    }
}
