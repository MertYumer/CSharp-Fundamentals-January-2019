namespace P03_WildFarm.Animals.Mammals
{
    using System;
    using P03_WildFarm.Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += (food.Quantity * 0.10);
                this.FoodEaten += food.Quantity;
            }

            else
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
