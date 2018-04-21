public class StandardEmployee : Employee
{
    private const int WeeklyWorkingHours = 40;

    public StandardEmployee(string name)
        : base(name, WeeklyWorkingHours)
    {
    }
}
