public class Mushroom : Vegetable
{
    private new const char Identifier = 'M';
    private new const int PowerEffect = -10;
    private new const int StaminaEffect = -10;
    private new const int RegrowPeriod = 5;

    public Mushroom()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
    }
}
