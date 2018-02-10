namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    class Department
    {
        private Room[] rooms;

        public Department(string name)
        {
            this.Name = name;
            InitializeRooms();
        }

        public string Name { get; private set; }

        private void InitializeRooms()
        {
            this.rooms = new Room[20];

            for (int i = 0; i < 20; i++)
            {
                this.rooms[i] = new Room();
            }
        }

        public bool AddPatient(string patient)
        {
            if (rooms.Count(r => r.GetFreeBeds() > 0) > 0)
            {
                Room room = rooms.Where(r => r.GetFreeBeds() > 0).First();
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

            if (room < 0 || room > 20)
                return null;

            return this.rooms[room].GetPatients().OrderBy(p => p).ToList();
        }
    }
}
