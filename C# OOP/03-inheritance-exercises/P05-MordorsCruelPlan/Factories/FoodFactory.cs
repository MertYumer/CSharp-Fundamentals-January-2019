namespace P05_MordorsCruelPlan.Factories
{
    using Food;

    public class FoodFactory
    {
        public Food CreateFood(string type)
        {
            switch (type.ToLower())
            {
                case "apple":
                    return new Apple();

                case "cram":
                    return new Cram();

                case "honeycake":
                    return new HoneyCake();

                case "lembas":
                    return new Lembas();

                case "melon":
                    return new Melon();

                case "mushrooms":
                    return new Mushrooms();

                default:
                    return new OtherFood();
            }
        }
    }
}
