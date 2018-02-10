namespace _04.Events
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Event
    {
        private List<Person> persons;

        public Event(string location)
        {
            this.Location = location;
            this.persons = new List<Person>();
        }

        public string Location { get; private set; }

        public void AddPerson(string personName, string time)
        {
            Person person = persons.FirstOrDefault(p => p.Name.Equals(personName));

            if (person == null)
            {
                person = new Person(personName);
                persons.Add(person);
            }

            person.AddTime(time);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.Location + ":");

            int countLines = 0;

            foreach (Person person in persons.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{++countLines}. {person.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
