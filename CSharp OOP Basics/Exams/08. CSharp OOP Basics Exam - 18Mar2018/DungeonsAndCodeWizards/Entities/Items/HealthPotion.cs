namespace DungeonsAndCodeWizards.Entities.Items
{
    using DungeonsAndCodeWizards.Entities.Characters;

    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int HitPointsRestored = 20;

        public HealthPotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            // The character’s health gets increased by 20 points.
            base.AffectCharacter(character);
            character.Health += HitPointsRestored;
        }
    }
}
