namespace SoftUniRestaurant.Core
{
    using Factories;
    using Models.Foods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;
        private List<IFood> availableFoods;
        private List<IDrink> availableDrinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            this.availableFoods = new List<IFood>();
            this.availableDrinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);
            this.availableFoods.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.availableDrinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables
                .FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been" +
                $" reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            var food = this.availableFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = this.availableDrinks
                .FirstOrDefault(d => d.Brand == drinkBrand && d.Name == drinkName);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Table: {tableNumber}");
            stringBuilder.AppendLine($"Bill: {bill:f2}");

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(t => !t.IsReserved);

            var stringBuilder = new StringBuilder();

            foreach (var table in freeTables)
            {
                stringBuilder.AppendLine(table.GetFreeTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = this.tables
                .Where(t => t.IsReserved);

            var stringBuilder = new StringBuilder();

            foreach (var table in occupiedTables)
            {
                stringBuilder.AppendLine(table.GetOccupiedTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }
    }
}
