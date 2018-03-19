namespace DungeonsAndCodeWizards.Entities.Items
{
    using DungeonsAndCodeWizards.Entities.Characters;

    public class ArmorRepairKit : Item
    {
        private const int DefaultWeight = 10;

        public ArmorRepairKit()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            // For an item to affect a character, the character needs to be alive.
            // The character’s armor restored up to the base armor value.
            // Example: Armor: 10, Base Armor: 100  Armor: 100
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
