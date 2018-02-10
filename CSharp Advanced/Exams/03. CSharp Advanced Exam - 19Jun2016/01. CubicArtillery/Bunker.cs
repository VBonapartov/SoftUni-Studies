namespace _01.CubicArtillery
{
    using System.Collections.Generic;

    class Bunker
    {
        public Bunker(string name)
        {
            this.Name = name;
            this.Weapons = new Queue<int>();
            this.UsedSpace = 0;
        }

        public string Name { get; private set; }

        public Queue<int> Weapons { get; private set; }

        public int UsedSpace { get; private set; }

        public void AddWeapon(int weaponCapacity)
        {
            this.UsedSpace += weaponCapacity;
            this.Weapons.Enqueue(weaponCapacity);
        }

        public void RemoveWeapon()
        {
            this.UsedSpace -= this.Weapons.Dequeue();
        }

        public override string ToString()
        {
            string weapons = (this.Weapons.Count == 0) ? "Empty" : string.Join(", ", this.Weapons);

            return $"{this.Name} -> {weapons}";
        }
    }
}
