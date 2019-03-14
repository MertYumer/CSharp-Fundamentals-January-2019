﻿namespace P03_WildFarm.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P03_WildFarm.Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
