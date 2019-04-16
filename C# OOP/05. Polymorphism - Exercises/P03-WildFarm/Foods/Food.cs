namespace P03_WildFarm.Foods
{
    using P03_WildFarm.Foods.Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
