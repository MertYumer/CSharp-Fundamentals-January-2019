namespace P07_FamilyTree
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<Person> Parents { get; set; } = new List<Person>();

        public List<Person> Children { get; set; } = new List<Person>();

        public override string ToString()
        {
            var information = new StringBuilder();
            information.AppendLine($"{Name} {Birthday}");
            information.AppendLine("Parents:");

            if (Parents.Count > 0)
            {
                foreach (var parent in Parents)
                {
                    information.AppendLine($"{parent.Name} {parent.Birthday}");
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
