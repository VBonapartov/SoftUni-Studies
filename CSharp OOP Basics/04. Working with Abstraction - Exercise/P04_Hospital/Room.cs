using System.Collections.Generic;
using System.Linq;

public class Room
{
    private const int BedsInRoom = 3;
    private string[] patients;

    public Room()
    {
        this.patients = new string[BedsInRoom] { string.Empty, string.Empty, string.Empty };
    }

    public int GetFreeBeds()
    {
        return this.patients.Count(b => b.Equals(string.Empty));
    }

    public void AddPatient(string patient)
    {
        for (int i = 0; i < this.patients.Count(); i++)
        {
            if (this.patients[i].Equals(string.Empty))
            {
                this.patients[i] = patient;
                break;
            }
        }
    }

    public IReadOnlyList<string> GetPatients()
    {
        return this.patients.Where(p => !p.Equals(string.Empty)).ToList();
    }
}