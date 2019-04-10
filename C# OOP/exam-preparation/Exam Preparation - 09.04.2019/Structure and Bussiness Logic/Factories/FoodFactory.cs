namespace SoftUniRestaurant.Factories
{
    using Models.Foods.Contracts;
    using Models.Foods;

    public static class FoodFactory
    {
        public static IFood CreateFood(string type, string name, decimal price)
        {
            IFood food;

            switch (type)
            {
                case "Dessert":
                    food = new Dessert(name, price);
                    break;

                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;

                case "Salad":
                    food = new Salad(name, price);
                    break;

                case "Soup":
                    food = new Soup(name, price);
                    break;

                default:
                    food = null;
                    break;
            }

            return food;
        }
    }
}
