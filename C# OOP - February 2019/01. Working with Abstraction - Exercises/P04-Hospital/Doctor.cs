namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        private string name;
        private List<string> patients;

        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<string> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
    }
}
