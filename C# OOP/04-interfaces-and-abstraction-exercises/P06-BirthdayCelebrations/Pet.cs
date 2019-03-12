namespace P06_BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string name;

        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.Birthdate = birthdate;
        }

        public string Birthdate { get; }
    }
}
