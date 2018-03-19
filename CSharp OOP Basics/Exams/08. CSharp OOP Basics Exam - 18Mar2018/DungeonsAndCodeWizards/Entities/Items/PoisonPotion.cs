namespace DungeonsAndCodeWizards.Entities.Items
{
    using System;
    using DungeonsAndCodeWizards.Entities.Characters;

    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int HitPointsDamaged = 20;

        public PoisonPotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            // The character’s health gets decreased by 20 points. 
            base.AffectCharacter(character);
            character.Health = Math.Max(0, character.Health - HitPointsDamaged);
        }
    }
}
