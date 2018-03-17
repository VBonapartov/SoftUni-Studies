using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private const int FacultyNumberMinLength = 5;
    private const int FacultyNumberMaxLength = 10;

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    private string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }

        set
        {
            if (value.Length < FacultyNumberMinLength || value.Length > FacultyNumberMaxLength || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(base.ToString())
          .Append("Faculty number: ").AppendLine(this.FacultyNumber);

        return sb.ToString();
    }
}