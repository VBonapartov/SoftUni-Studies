using System.Collections.Generic;
using System.Linq;

public class Department
{
    private const int NumberOfRooms = 20;
    private Room[] rooms;

    public Department(string name)
    {
        this.Name = name;
        this.InitializeRooms();
    }

    public string Name { get; private set; }

    public bool AddPatient(string patient)
    {
        if (this.rooms.Count(r => r.GetFreeBeds() > 0) > 0)
        {
            Room room = this.rooms.Where(r => r.GetFreeBeds() > 0).First();
            room.AddPatient(patient);

            return true;
        }

        return false;
    }

    public IReadOnlyList<string> GetAllPatients()
    {
        List<string> temp = new List<string>();

        for (int i = 0; i < this.rooms.Length; i++)
        {
            temp.AddRange(this.rooms[i].GetPatients());
        }

        return temp;
    }

    public IReadOnlyList<string> GetPatientsInRoom(int room)
    {
        room -= 1;

        if (room < 0 || room > NumberOfRooms)
        {
            return null;
        }

        return this.rooms[room].GetPatients().OrderBy(p => p).ToList();
    }

    private void InitializeRooms()
    {
        this.rooms = new Room[NumberOfRooms];

        for (int i = 0; i < NumberOfRooms; i++)
        {
            this.rooms[i] = new Room();
        }
    }
}