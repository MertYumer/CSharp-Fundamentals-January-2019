namespace P06_BirthdayCelebrations
{
    public class Citizen : IBirthable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id, string birhdate)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.Birthdate = birhdate;
        }

        public string Birthdate { get; }
    }
}
