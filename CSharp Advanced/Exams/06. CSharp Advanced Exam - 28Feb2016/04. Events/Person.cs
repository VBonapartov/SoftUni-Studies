namespace _04.Events
{
    using System.Collections.Generic;
    using System.Linq;

    class Person
    {
        private List<string> times;

        public Person(string name)
        {
            this.Name = name;
            this.times = new List<string>();
        }

        public string Name { get; private set; }

        public void AddTime(string time)
        {
            this.times.Add(time);
        }

        public override string ToString()
        {
            return $"{this.Name} -> {string.Join(", ", times.OrderBy(t => t))}";
        }
    }
}
