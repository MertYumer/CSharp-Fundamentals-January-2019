namespace AnimalCentre.Models
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals 
            => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = animals[animalName];
            animal.IsAdopt = true;
            animal.Owner = owner;
            this.animals.Remove(animalName);
        }
    }
}
