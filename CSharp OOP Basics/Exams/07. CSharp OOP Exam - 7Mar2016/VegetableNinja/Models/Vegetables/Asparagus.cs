public class Asparagus : Vegetable
{
    private new const char Identifier = 'A';
    private new const int PowerEffect = 5;
    private new const int StaminaEffect = -5;
    private new const int RegrowPeriod = 2;

    public Asparagus()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
    }
}
