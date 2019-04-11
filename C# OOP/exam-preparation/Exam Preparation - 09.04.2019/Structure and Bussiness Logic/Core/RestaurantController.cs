namespace SoftUniRestaurant.Core
{
    using Factories;
    using Models.Foods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = FoodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = DrinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = TableFactory.CreateTable(type, tableNumber, capacity);
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

            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            else if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            else
            {
                table.OrderFood(food);
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = this.drinks
                .FirstOrDefault(d => d.Brand == drinkBrand && d.Name == drinkName);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            else if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            else
            {
                table.OrderDrink(drink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.Find(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            var stringBuilder = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                stringBuilder.AppendLine(table.GetFreeTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var stringBuilder = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved))
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
