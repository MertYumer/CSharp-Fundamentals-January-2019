namespace P03_WildFarm.Animals.Felines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P03_WildFarm.Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
