namespace P03_Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected string FirstName
        {
            get => this.firstName;
            set
            {
                ValidName(value, 4, "firstName");
                this.firstName = value;
            }
        }

        protected string LastName
        {
            get => this.lastName;
            set
            {
                ValidName(value, 3, "lastName");
                this.lastName = value;
            }
        }

        private void ValidName(string name, int minLength, string output)
        {
            if (char.IsLower(name[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {output}");
            }

            if (name.Length < minLength)
            {
                if (minLength == 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {output}");
                }

                else
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: {output}");
                }
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First Name: {FirstName}");
            stringBuilder.Append($"Last Name: {LastName}");

            return stringBuilder.ToString();
        }
    }
}
