namespace P12_Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public List<Parent> Parents { get; set; } = new List<Parent>();

        public List<Child> Children { get; set; } = new List<Child>();

        public Person(string name, Company company)
        {
            Name = name;
            Company = company;
        }

        public Person(string name, Car car)
        {
            Name = name;
            Car = car;
        }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            var information = new StringBuilder();
            information.AppendLine(Name);
            information.AppendLine("Company:");

            if (Company != null)
            {
                information.AppendLine($"{Company.Name} {Company.Department} {Company.Salary:f2}");
            }

            information.AppendLine("Car:");

            if (Car != null)
            {
                information.AppendLine($"{Car.Model} {Car.Speed}");
            }

            information.AppendLine("Pokemon:");

            if (Pokemons.Count > 0)
            {
                foreach (var pokemon in Pokemons)
                {
                    information.AppendLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            information.AppendLine("Parents:");

            if (Parents.Count > 0)
            {
                foreach (var parent in Parents)
                {
                    information.AppendLine($"{parent.Name} " +
                        $"{parent.Birthday}");
                }
            }

            if (Children.Count > 0)
            {
                information.AppendLine("Children:");

                for (int i = 0; i < Children.Count; i++)
                {
                    if (i < Children.Count - 1)
                    {
                        information.AppendLine($"{Children[i].Name} " +
                            $"{Children[i].Birthday}");
                    }

                    else
                    {
                        information.Append($"{Children[i].Name} " +
                            $"{Children[i].Birthday}");
                    }
                }
            }

            else
            {
                information.Append("Children:");
            }

            return information.ToString();
        }
    }
}
