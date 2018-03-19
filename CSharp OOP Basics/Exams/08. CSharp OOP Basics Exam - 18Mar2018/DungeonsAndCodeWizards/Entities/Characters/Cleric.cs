namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Characters.Contracts;
    using DungeonsAndCodeWizards.Entities.Characters.Enums;    
    using DungeonsAndCodeWizards.Static_data;

    public class Cleric : Character, IHealable
    {
        // 50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag
        private const double DefaultHealth = 50;
        private const double DefaultArmor = 25;
        private const double DefaultAbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Backpack(), faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterDeadException);
            }

            // If the character the character is healing is from a different faction, 
            // throw an InvalidOperationException with the message “Cannot heal enemy character!”
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotHealEnemyException);
            }

            // If both of those checks pass, the receiving character’s health increases by the healer’s ability points.
            character.Health += this.AbilityPoints;
        }
    }
}
