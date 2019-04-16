namespace SoftUniRestaurant.Factories
{
    using Models.Drinks.Contracts;
    using Models.Drinks;

    public static class DrinkFactory
    {
        public static IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink;

            switch (type)
            {
                case "Alcohol":
                    drink = new Alcohol(name, servingSize, brand);
                    break;

                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;

                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;

                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;

                default:
                    drink = null;
                    break;
            }

            return drink;
        }
    }
}
