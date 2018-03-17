public class CherryBerry : Vegetable
{
    private new const char Identifier = 'C';
    private new const int PowerEffect = 0;
    private new const int StaminaEffect = 10;
    private new const int RegrowPeriod = 5;

    public CherryBerry()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
    }
}
