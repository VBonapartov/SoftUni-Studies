namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Characters.Contracts;
    using DungeonsAndCodeWizards.Entities.Characters.Enums;    
    using DungeonsAndCodeWizards.Static_data;

    public class Warrior : Character, IAttackable
    {
        // 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel 
        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterDeadException);
            }

            // If the character they are trying to attack is the same character, 
            // throw an InvalidOperationException with the message “Cannot attack self!”
            if (this.Name.Equals(character.Name))
            {                
                throw new InvalidOperationException(ExceptionMessages.SelfAttackException);
            }

            // If the character the character is attacking is from the same faction, 
            // throw an ArgumentException with the message “Friendly fire! Both characters are from {faction} faction!”
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FriendlyFireException, this.Faction));
            }

            // If all of those checks pass, the receiving character takes damage with hit points equal to the 
            // attacking character’s ability points.
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
