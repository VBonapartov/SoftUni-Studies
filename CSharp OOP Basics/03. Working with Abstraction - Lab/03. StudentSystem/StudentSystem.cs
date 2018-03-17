using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string command, Action<string> printFunction)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            this.Create(args[1], args[2], args[3]);
        }
        else if (args[0] == "Show")
        {
            string studentName = args[1];

            if (this.repo.ContainsKey(studentName))
            {
                printFunction(this.repo[studentName].ToString());
            }
        }
    }

    private void Create(string name, string ageString, string gradeString)
    {
        int age = int.Parse(ageString);
        double grade = double.Parse(gradeString);

        if (!this.repo.ContainsKey(name))
        {
            Student student = new Student(name, age, grade);
            this.repo[name] = student;
        }
    }
}