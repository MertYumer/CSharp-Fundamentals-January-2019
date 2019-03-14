namespace P03_WildFarm.Foods
{
    using P03_WildFarm.Foods.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
