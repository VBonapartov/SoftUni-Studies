using System;
using System.Text;

public class Human
{
    private const int FirstNameMinLength = 4;
    private const int LastNameMinLength = 3;

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    protected string FirstName
    {
        get
        {
            return this.firstName;
        }

        private set
        {
            ValidateName(value, nameof(this.firstName), FirstNameMinLength);
            this.firstName = value;
        }
    }

    protected string LastName
    {
        get
        {
            return this.lastName;
        }

        private set
        {
            ValidateName(value, nameof(this.lastName), LastNameMinLength);
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("First Name: ").AppendLine(this.FirstName)
            .Append("Last Name: ").AppendLine(this.LastName);

        return sb.ToString();
    }

    private static void ValidateName(string value, string type, int minLength)
    {
        if (char.IsLower(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {type}");
        }

        if (value.Length < minLength)
        {
            throw new ArgumentException($"Expected length at least {minLength} symbols! Argument: {type}");
        }
    }
}