namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    using DungeonsAndCodeWizards.Entities.Characters;

    public interface IHealable
    {
        void Heal(Character character);
    }
}
