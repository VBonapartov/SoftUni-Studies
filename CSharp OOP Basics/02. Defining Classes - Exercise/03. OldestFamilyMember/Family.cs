using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> listOfPeople;

    public Family()
    {
        listOfPeople = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.listOfPeople.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.listOfPeople.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}