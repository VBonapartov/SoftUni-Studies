namespace DungeonsAndCodeWizards.Entities.Characters.Contracts
{
    using DungeonsAndCodeWizards.Entities.Characters;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}
