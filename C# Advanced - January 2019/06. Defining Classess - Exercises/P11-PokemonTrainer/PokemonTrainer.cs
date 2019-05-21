namespace P11_PokemonTrainer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PokemonTrainer
    {
        public static void Main()
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }

                string name = input[0];
                string pokemonName = input[1];
                string element = input[2];
                int health = int.Parse(input[3]);

                var pokemon = new Pokemon(pokemonName, element, health);
                var trainer = new Trainer(name);

                int index = trainers.FindIndex(t => t.Name == name);

                if (index == -1)
                {
                    trainers.Add(trainer);
                    trainers[trainers.Count - 1].Pokemons.Add(pokemon);
                }

                else
                {
                    trainers[index].Pokemons.Add(pokemon);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    var orderedTrainers = trainers
                        .OrderByDescending(t => t.Badges);

                    Console.WriteLine(string.Join(Environment.NewLine, orderedTrainers));
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }

                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            if (trainer.Pokemons[i].Health - 10 <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }

                            else
                            {
                                trainer.Pokemons[i].Health -= 10;
                            }
                        }
                    }
                }
            }
        }
    }
}
