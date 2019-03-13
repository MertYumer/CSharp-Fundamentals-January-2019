namespace P07_FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }

        int Food { get; }

        void BuyFood();
    }
}
