namespace DungeonsAndCodeWizards.Entities.Bags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Static_data;

    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private readonly List<Item> items;
        private int capacity;        

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        // The sum of the weights of the items in the bag.
        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        protected int Capacity
        {
            get => this.capacity;
            set { this.capacity = value; }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsFullException);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBagException);
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name.Equals(name));

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NoItemWithSpecificNameInTheBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}
