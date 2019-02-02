namespace P11_PokemonTrainer
{
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        public string Name { get; set; }

        public int Badges { get; set; } = 0;

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public Trainer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            var information = new StringBuilder();
            information.Append($"{Name} {Badges} {Pokemons.Count}");
            return information.ToString();
        }
    }
}
