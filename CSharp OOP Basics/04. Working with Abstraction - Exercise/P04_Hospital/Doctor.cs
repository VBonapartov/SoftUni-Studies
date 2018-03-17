using System;
using System.Collections.Generic;
using System.Linq;

public class Doctor
{
    private List<string> patients;

    public Doctor(string name)
    {
        this.Name = name;
        this.patients = new List<string>();
    }

    public string Name { get; private set; }

    public void AddPatient(string patient)
    {
        this.patients.Add(patient);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, this.GetAllPatients());
    }

    private IReadOnlyList<string> GetAllPatients()
    {
        return this.patients.OrderBy(p => p).ToList();
    }
}