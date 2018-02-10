namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    class Room
    {
        private string[] patients;

        public Room()
        {
            this.patients = new string[3] { "", "", "" };
        }

        public int GetFreeBeds()
        {
            return this.patients.Count(b => b.Equals(""));
        }

        public void AddPatient(string patient)
        {
            for (int i = 0; i < patients.Count(); i++)
            {
                if (patients[i].Equals(""))
                {
                    patients[i] = patient;
                    break;
                }
            }
        }

        public IReadOnlyList<string> GetPatients()
        {
            return this.patients.Where(p => !p.Equals("")).ToList();
        }
    }
}
