namespace P03_OldestFamilyMember
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
            : this()
        {
            this.age = age;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }

            set { this.age = value; }
        }
    }
}
