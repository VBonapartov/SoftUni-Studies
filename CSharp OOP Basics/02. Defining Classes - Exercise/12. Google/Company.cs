public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public string Name
    {
        get { return this.name; }
    }

    public string Department
    {
        get { return this.department; }
    }

    public decimal Salary
    {
        get { return this.salary; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:F2}";
    }
}