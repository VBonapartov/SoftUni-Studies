public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department)
    {
        this.email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department)
    {
        this.age = age;
    }

    public string Name
    {
        get { return this.name; }
    }

    public decimal Salary
    {
        get { return this.salary; }
    }

    public string Position
    {
        get { return this.position; }
    }

    public string Department
    {
        get { return this.department; }
    }

    public string Email
    {
        get { return this.email; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";
    }
}