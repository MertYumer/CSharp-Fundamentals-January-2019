namespace P03_WildFarm.Factories
{
    using P03_WildFarm.Foods;
    using System;

    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "fruit":
                    return new Fruit(quantity);

                case "meat":
                    return new Meat(quantity);

                case "seeds":
                    return new Seeds(quantity);

                case "vegetable":
                    return new Vegetable(quantity);

                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
