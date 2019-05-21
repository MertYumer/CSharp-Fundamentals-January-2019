namespace P03_WildFarm.Animals.Felines
{
    using System;
    using P03_WildFarm.Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.Weight += (food.Quantity * 0.30);
                this.FoodEaten += food.Quantity;
            }

            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
