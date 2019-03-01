namespace P02_Salary
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public string FirstName => this.firstName;
        public int Age => this.age;

        public void IncreaseSalary(decimal bonus)
        {
            if (this.age <= 30)
            {
                bonus /= 2;
            }

            this.salary += (this.salary * bonus / 100);
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.".ToString();
        }
    }
}