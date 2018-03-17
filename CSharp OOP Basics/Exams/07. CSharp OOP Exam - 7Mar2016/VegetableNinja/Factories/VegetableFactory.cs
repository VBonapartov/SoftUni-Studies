public class VegetableFactory
{
    public static IVegetable GetVegetable(char vegetableType)
    {
        switch (vegetableType)
        {
            case 'A':
                return new Asparagus();

            case 'B':
                return new Broccoli();

            case 'C':
                return new CherryBerry();

            case 'M':
                return new Mushroom();

            case 'R':
                return new Royal();

            case '*':
                return new MeloLemonMelon();

            default:
                return null;
        }
    }
}
