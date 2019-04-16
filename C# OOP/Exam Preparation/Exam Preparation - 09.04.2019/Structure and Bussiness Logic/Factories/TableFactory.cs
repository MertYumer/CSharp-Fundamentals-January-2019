namespace SoftUniRestaurant.Factories
{
    using Models.Tables.Contracts;
    using Models.Tables;

    public static class TableFactory
    {
        public static ITable CreateTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;

                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;

                default:
                    table = null;
                    break;
            }

            return table;
        }
    }
}
