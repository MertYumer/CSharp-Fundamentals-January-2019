namespace P06_Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        private int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        private string Gender
        {
            get => this.gender;
            set
            {
                if (string.IsNullOrEmpty(value) 
                    || string.IsNullOrWhiteSpace(value)
                    || (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.GetType().Name);
            builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            builder.Append($"{this.ProduceSound()}");
            return builder.ToString();
        }
    }
}
