using System;
using System.Text;

public class Worker : Human
{
    private const decimal MinWeekSalary = 10;
    private const int MinWorkingHoursPerDay = 1;
    private const int MaxWorkingHoursPerDay = 12;
    private const int WorkDaysPerWeek = 5;

    private const string Error = "Expected value mismatch! Argument: {0}";

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }

        set
        {
            if (value <= MinWeekSalary)
            {
                throw new ArgumentException(string.Format(Error, nameof(this.weekSalary)));
            }

            this.weekSalary = value;
        }
    }

    private double WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }

        set
        {
            if (value < MinWorkingHoursPerDay || value > MaxWorkingHoursPerDay)
            {
                throw new ArgumentException(string.Format(Error, nameof(this.workHoursPerDay)));
            }

            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(base.ToString())
            .Append("Week Salary: ").AppendLine($"{this.WeekSalary:F2}")
            .Append("Hours per day: ").AppendLine($"{this.WorkHoursPerDay:F2}")
            .Append("Salary per hour: ").AppendLine($"{this.GetSalaryPerHour():F2}");

        return sb.ToString().TrimEnd();
    }

    private decimal GetSalaryPerHour()
    {
        return this.WeekSalary / (decimal)(WorkDaysPerWeek * this.workHoursPerDay);
    }
}