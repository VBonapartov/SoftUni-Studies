namespace DungeonsAndCodeWizards.Static_data
{
    public static class ExceptionMessages
    {
        public const string InvalidNameException = "Name cannot be null or whitespace!";
        public const string InvalidFactionException = "Invalid faction \"{0}\"!";
        public const string InvalidCharacterType = "Invalid character type \"{0}\"!";
        public const string InvalidItemType = "Invalid item \"{0}\"!";
        public const string CharacterNotFoundException = "Character {0} not found!";
        public const string ItemNotFound = "Item {0} not found!";
        public const string NoItemsInPool = "No items left in pool!";
        public const string EmptyBagException = "Bag is empty!";
        public const string BagIsFullException = "Bag is full!";
        public const string NoItemWithSpecificNameInTheBag = "No item with name {0} in bag!";
        public const string CharacterDeadException = "Must be alive to perform this action!";
        public const string FriendlyFireException = "Friendly fire! Both characters are from {0} faction!";
        public const string SelfAttackException = "Cannot attack self!";
        public const string InvalidAttackerException = "{0} cannot attack!";
        public const string InvalidHealerException = "{0} cannot heal!";
        public const string CannotHealEnemyException = "Cannot heal enemy character!";
    }
}
