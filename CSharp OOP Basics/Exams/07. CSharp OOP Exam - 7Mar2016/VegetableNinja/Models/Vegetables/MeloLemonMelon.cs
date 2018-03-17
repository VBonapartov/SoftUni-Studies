public class MeloLemonMelon : Vegetable
{
    private new const char Identifier = '*';
    private new const int PowerEffect = 0;
    private new const int StaminaEffect = 0;
    private new const int RegrowPeriod = int.MaxValue;

    public MeloLemonMelon()
        : base(Identifier, PowerEffect, StaminaEffect, RegrowPeriod)
    {
        // Not implemented
    }
}
