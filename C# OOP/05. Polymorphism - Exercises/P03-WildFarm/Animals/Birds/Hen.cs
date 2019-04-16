namespace P03_WildFarm.Animals.Birds
{
    using System;
    using P03_WildFarm.Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += (food.Quantity * 0.35);
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
