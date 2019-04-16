namespace P01_Persons
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName => this.firstName;

        public int Age => this.age;

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} is {this.age} years old.".ToString();
        }
    }
}
