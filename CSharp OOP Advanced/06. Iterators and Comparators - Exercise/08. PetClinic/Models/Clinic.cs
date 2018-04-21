using System;
using System.Text;

public class Clinic
{
    private int roomsNumber;
    private RoomsRegister roomsRegister;
    private int occupiedRooms;

    public Clinic(string clinicName, int roomsNumber)
    {
        this.ClinicName = clinicName;
        this.RoomsNumber = roomsNumber;
        this.roomsRegister = new RoomsRegister(roomsNumber);
        this.occupiedRooms = 0;
    }

    public string ClinicName { get; private set; }

    public int RoomsNumber
    {
        get
        {
            return this.roomsNumber;
        }

        set
        {
            if (value < 0 || value > 101 || value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            this.roomsNumber = value;
        }
    }

    public bool TryAddPet(Pet newPet)
    {
        foreach (int roomIndex in this.roomsRegister)
        {
            if (this.roomsRegister[roomIndex] == null)
            {
                this.roomsRegister[roomIndex] = newPet;
                this.occupiedRooms++;
                return true;
            }            
        }

        return false;
    }

    public bool TryReleasePet()
    {
        int centralRoomIndex = this.RoomsNumber / 2;

        for (int i = 0; i < this.RoomsNumber; i++)
        {
            int currentIndex = (centralRoomIndex + i) % this.RoomsNumber;

            if (this.roomsRegister[currentIndex] != null)
            {
                this.roomsRegister[currentIndex] = null;
                this.occupiedRooms--;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.occupiedRooms < this.RoomsNumber;
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.RoomsNumber; i++)
        {
            sb.AppendLine(this.Print(i));
        }

        return sb.ToString().TrimEnd();
    }

    public string Print(int roomIndex)
    {
        return this.roomsRegister[roomIndex]?.ToString() ?? "Room empty";
    }
}