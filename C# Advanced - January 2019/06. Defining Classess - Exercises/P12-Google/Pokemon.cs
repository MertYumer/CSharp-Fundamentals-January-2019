namespace P12_Google
{
    public class Pokemon
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
