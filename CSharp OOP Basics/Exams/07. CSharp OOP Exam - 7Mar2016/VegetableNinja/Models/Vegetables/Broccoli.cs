public class Broccoli : Vegetable
{
    private new const char Identifier = 'B';
    private new const int PowerEffect = 10;
    private new const int StaminaEffect = 0;
    private new const int RegrowPeriod = 3;

    public Broccoli()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
    }
}
