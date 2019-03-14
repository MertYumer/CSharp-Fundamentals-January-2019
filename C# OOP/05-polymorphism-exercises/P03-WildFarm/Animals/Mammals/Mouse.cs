﻿namespace P03_WildFarm.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P03_WildFarm.Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
