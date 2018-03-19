namespace DungeonsAndCodeWizards.Entities.Items.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Static_data;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Type typeOfCommand = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(type => type.Name.Equals(itemName));

            if (typeOfCommand == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItemType, itemName));
            }

            Item item = (Item)Activator.CreateInstance(typeOfCommand);
            return item;
        }
    }
}
