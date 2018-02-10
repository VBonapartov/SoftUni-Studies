namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    class Doctor
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

        public IReadOnlyList<string> GetAllPatients()
        {
            return this.patients.OrderBy(p => p).ToList();
        }
    }
}
