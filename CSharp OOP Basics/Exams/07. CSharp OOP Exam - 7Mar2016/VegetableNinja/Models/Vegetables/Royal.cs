public class Royal : Vegetable
{
    private new const char Identifier = 'R';
    private new const int PowerEffect = 20;
    private new const int StaminaEffect = 10;
    private new const int RegrowPeriod = 10;

    public Royal()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
    }
}
