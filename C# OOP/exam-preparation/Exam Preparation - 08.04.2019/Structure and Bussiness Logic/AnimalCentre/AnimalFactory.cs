namespace AnimalCentre
{
    using Models.Animals;
    using Models.Contracts;

    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy,
            int happiness, int procedureTime)
        {
            IAnimal animal;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;

                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;

                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;

                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;

                default:
                    animal = null;
                    break;
            }

            return animal;
        }
    }
}
