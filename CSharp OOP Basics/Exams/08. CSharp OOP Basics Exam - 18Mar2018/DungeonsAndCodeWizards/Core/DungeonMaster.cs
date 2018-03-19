namespace DungeonsAndCodeWizards.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    
    using DungeonsAndCodeWizards.Entities.Characters;
    using DungeonsAndCodeWizards.Entities.Characters.Contracts;
    using DungeonsAndCodeWizards.Entities.Characters.Factory;
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Entities.Items.Factory;
    using DungeonsAndCodeWizards.Static_data;

    public class DungeonMaster
    {
        private readonly List<Character> party;
        private readonly Stack<Item> itemPool;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        private int lastSurvivorRounds = 0;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];
            
            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);
            this.party.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.FindCharacter(characterName);

            bool anyItemsLeft = this.itemPool.Any();

            if (!anyItemsLeft)
            {
                throw new InvalidOperationException(ExceptionMessages.NoItemsInPool);
            }

            Item item = this.itemPool.Pop();

            character.ReceiveItem(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.FindCharacter(characterName);
            Item item = this.FindItem(itemName, character);

            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacter(giverName);
            Character receiver = this.FindCharacter(receiverName);
            Item item = this.FindItem(itemName, giver);

            giver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacter(giverName);
            Character receiver = this.FindCharacter(receiverName);
            Item item = this.FindItem(itemName, giver);

            giver.GiveCharacterItem(item, receiver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder result = new StringBuilder();

            foreach (Character character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.FindCharacter(attackerName);
            Character receiver = this.FindCharacter(receiverName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAttackerException, attacker.Name));
            }

            attackingCharacter.Attack(receiver);

            StringBuilder result = new StringBuilder();

            result
                .Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ")
                .AppendLine($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().Trim();          
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.FindCharacter(healerName);
            Character receiver = this.FindCharacter(healingReceiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHealerException, healerName));
            }

            healingCharacter.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder result = new StringBuilder();

            foreach (Character character in this.party.Where(c => c.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                double currentHealth = character.Health;

                result.AppendLine($"{character.Name} rests ({healthBeforeRest} => {currentHealth})");
            }

            int aliveCharacters = this.party.Count(c => c.IsAlive);
            if (aliveCharacters <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return result.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorRounds > 1 &&
                   this.party.Count(c => c.IsAlive) < 2;
        }

        private Character FindCharacter(string characterName)
        {
            Character character = this.party.FirstOrDefault(c => c.Name.Equals(characterName));

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotFoundException, characterName));
            }

            return character;
        }

        private Item FindItem(string itemName, Character character)
        {
            Item item = character.Bag.GetItem(itemName);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFound, itemName));
            }

            return item;
        }
    }
}
