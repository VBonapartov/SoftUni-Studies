public abstract class Employee : IEmployee
{
    public Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public string Name { get; private set; }

    public int WorkHoursPerWeek { get; private set; }
}
