public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.grade = grade;
    }

    public double Grade
    {
        get { return this.grade; }
        set { this.grade = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public override string ToString()
    {
        string gradeComment = this.GetGradeComment();
        return $"{this.Name} is {this.Age} years old. {gradeComment}";
    }

    private string GetGradeComment()
    {
        if (this.Grade >= 5.00)
        {
            return "Excellent student.";
        }
        else if (this.Grade < 5.00 && this.Grade >= 3.50)
        {
            return "Average student.";
        }
        else
        {
            return "Very nice person.";
        }
    }
}