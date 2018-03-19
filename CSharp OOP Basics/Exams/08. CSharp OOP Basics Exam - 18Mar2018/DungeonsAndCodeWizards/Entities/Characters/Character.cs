namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Characters.Enums;    
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Static_data;

    public abstract class Character
    {
        private string name;

        private double baseHealth;
        private double health;

        private double baseArmor;
        private double armor;

        private double abilityPoints;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.health = health;

            this.BaseArmor = armor;
            this.armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.Faction = faction;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameException);
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get => this.baseHealth;
            private set { this.baseHealth = value; }
        }

        // Health maxes out at BaseHealth and mins out at 0. 
        public double Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = Math.Min(value, this.BaseHealth);

                if (this.health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public double BaseArmor
        {
            get => this.baseArmor;
            private set { this.baseArmor = value; }
        }

        // Armor maxes out at BaseArmor and mins out at 0
        public double Armor
        {
            get
            {
                return this.armor;
            }

            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set { this.abilityPoints = value; }
        }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; private set; } = true;

        protected virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            // For a character to take damage, they need to be alive.
            this.EnsureAlive();

            // The character’s armor is reduced by the hit point amount, 
            // then if there are still hit points left, they take that amount of health damage.
            // Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
            if (hitPoints > this.Armor)
            {
                this.Health = Math.Max(0, this.Health - (hitPoints - this.Armor));
            }

            this.Armor = Math.Max(0, this.Armor - hitPoints);
        }

        public void Rest()
        {
            // For a character to rest, they need to be alive.
            this.EnsureAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            // For a character to use an item, they need to be alive.
            // The item affects the character with the item effect.
            this.UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            // For a character to use an item on another character, both of them need to be alive.
            // The item affects the targeted character with the item effect.
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterDeadException);
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            // For a character to give another character an item, both of them need to be alive.
            // The targeted character receives the item.
            this.EnsureAlive();
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            // For a character to receive an item, they need to be alive.
            // The character puts the item into their bag.
            this.EnsureAlive();
            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterDeadException);
            }
        }
    }
}
