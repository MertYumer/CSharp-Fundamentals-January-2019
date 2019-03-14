namespace P03_WildFarm.Animals.Birds
{
    using System;
    using P03_WildFarm.Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += (food.Quantity * 0.25);
                this.FoodEaten += food.Quantity;
            }

            else
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
