using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private const string MissingEmployeeExceptionMessage = "Employee {0} is not available";

    private IReader reader;
    private IWriter writer;

    private IList<IEmployee> employees;
    private IList<IJob> jobs;

    private IList<IJob> jobsForRemoving;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;

        this.employees = new List<IEmployee>();
        this.jobs = new List<IJob>();
        this.jobsForRemoving = new List<IJob>();
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        string input = string.Empty;

        while (!(input = this.reader.ReadLine()).Equals("End"))
        {
            string[] cmdArgs = input.Split(' ');
            string command = cmdArgs[0];

            switch (command)
            {
                case "Job":
                    this.Job(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3]);
                    break;

                case "StandardEmployee":
                    this.CreateStandardEmployee(cmdArgs[1]);
                    break;

                case "PartTimeEmployee":
                    this.CreatePartTimeEmployee(cmdArgs[1]);
                    break;

                case "Status":
                    this.Status();
                    break;

                case "Pass":
                    this.Pass();
                    break;
            }
        }
    }

    private void Job(string jobName, int requiredHoursOfWork, string employeeName)
    {
        IEmployee assigningEmployee = this.employees.FirstOrDefault(e => e.Name.Equals(employeeName));
        if (assigningEmployee == null)
        {
            throw new ArgumentException(string.Format(MissingEmployeeExceptionMessage, employeeName));
        }

        IJob job = new Job(jobName, requiredHoursOfWork, assigningEmployee);
        this.jobs.Add(job);

        job.JobDone += this.OnJobDone;
    }

    private void CreateStandardEmployee(string name)
    {
        StandardEmployee standartEmployee = new StandardEmployee(name);
        this.employees.Add(standartEmployee);
    }

    private void CreatePartTimeEmployee(string name)
    {
        PartTimeEmployee parttimeEmployee = new PartTimeEmployee(name);
        this.employees.Add(parttimeEmployee);
    }

    private void Status()
    {
        foreach (IJob job in this.jobs)
        {
            this.writer.WriteLine(job.ToString());
        }
    }

    private void Pass()
    {
        foreach (IJob job in this.jobs)
        {
            job.Update();
        }

        this.RemoveDoneJobs();
    }

    private void OnJobDone(object sender, JobEventArgs args)
    {
        this.writer.WriteLine($"Job {args.Job.Name} done!");
        this.jobsForRemoving.Add(args.Job);
    }

    private void RemoveDoneJobs()
    {
        foreach (IJob job in this.jobsForRemoving)
        {
            this.jobs.Remove(job);
        }

        this.jobsForRemoving.Clear();
    }
}
