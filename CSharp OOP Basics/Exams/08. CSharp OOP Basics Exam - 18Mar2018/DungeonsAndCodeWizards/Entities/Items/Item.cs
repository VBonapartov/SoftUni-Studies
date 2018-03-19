namespace DungeonsAndCodeWizards.Entities.Items
{
    using System;
    using DungeonsAndCodeWizards.Entities.Characters;
    using DungeonsAndCodeWizards.Static_data;    

    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            this.weight = weight;
        }

        public int Weight
        {
            get => this.weight;
            set { this.weight = value; }
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterDeadException);
            }
        }
    }
}
