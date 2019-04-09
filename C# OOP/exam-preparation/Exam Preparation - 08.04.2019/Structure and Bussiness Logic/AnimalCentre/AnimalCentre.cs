namespace AnimalCentre
{
    using Models;
    using Models.Contracts;
    using Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private IHotel hotel;
        private IProcedure chip = new Chip();
        private IProcedure dentalCare = new DentalCare();
        private IProcedure fitness = new Fitness();
        private IProcedure nailTrim = new NailTrim();
        private IProcedure play = new Play();
        private IProcedure vaccinate = new Vaccinate();
        private AnimalFactory animalFactory = new AnimalFactory();
        private Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.owners = new Dictionary<string, List<string>>();
        }

        public IReadOnlyDictionary<string, List<string>> Owners
            => this.owners.ToImmutableDictionary();

        public string RegisterAnimal(string type, string name, int energy,
            int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy,
                happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.chip.DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.vaccinate.DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.fitness.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.play.DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.dentalCare.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = this.hotel.Animals[name];
            this.nailTrim.DoService(animal, procedureTime);

            return $"{name} had nailTrim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExists(animalName);
            IAnimal animal = this.hotel.Animals[animalName];
            this.hotel.Adopt(animalName, owner);

            if (!this.owners.ContainsKey(owner))
            {
                this.owners[owner] = new List<string>();
            }

            this.owners[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return this.chip.History();

                case "DentalCare":
                    return this.dentalCare.History();

                case "Fitness":
                    return this.fitness.History();

                case "NailTrim":
                    return this.nailTrim.History();

                case "Play":
                    return this.play.History();

                case "Vaccinate":
                    return this.vaccinate.History();

                default:
                    return null;
            }
        }

        public string GetOwnersInfo()
        {
            var stringBuilder = new StringBuilder();

            foreach (var owner in this.Owners)
            {
                stringBuilder.AppendLine($"--Owner: {owner.Key}");
                stringBuilder.AppendLine($"    - Adopted animals:" +
                    $" {string.Join(" ", owner.Value)}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private void CheckIfAnimalExists(string name)
        {
            if (!this.hotel.Animals.Any(a => a.Key == name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}
