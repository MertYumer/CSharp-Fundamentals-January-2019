namespace P03_WildFarm.Animals
{
    using P03_WildFarm.Animals.Contracts;
    using P03_WildFarm.Foods;

    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void ProduceSound();

        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
