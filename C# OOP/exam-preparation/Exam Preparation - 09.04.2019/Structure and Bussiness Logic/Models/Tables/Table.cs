namespace SoftUniRestaurant.Models.Tables
{
    using Contracts;
    using Drinks.Contracts;
    using Models.Foods.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private List<IFood> orderedFoods;
        private List<IDrink> orderedDrinks;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.orderedFoods = new List<IFood>();
            this.orderedDrinks = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.numberOfPeople;

        public void Clear()
        {
            this.orderedFoods.Clear();
            this.orderedDrinks.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = this.orderedFoods.Sum(f => f.Price)
                + this.orderedDrinks.Sum(d => d.Price)
                + this.Price;

            return bill;
        }

        public string GetFreeTableInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Table: {this.TableNumber}");
            stringBuilder.AppendLine($"Type: {this.GetType().Name}");
            stringBuilder.AppendLine($"Capacity: {this.Capacity}");
            stringBuilder.AppendLine($"Price per Person: {this.PricePerPerson}");

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Table: {this.TableNumber}");
            stringBuilder.AppendLine($"Type: {this.GetType().Name}");
            stringBuilder.AppendLine($"Number of people: {this.NumberOfPeople}");

            string foodOrders = this.orderedFoods.Count == 0
                ? "None"
                : this.orderedFoods.Count.ToString();

            stringBuilder.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.orderedFoods)
            {
                stringBuilder.AppendLine(food.ToString());
            }

            string drinkOrders = this.orderedDrinks.Count == 0
                 ? "None"
                 : this.orderedDrinks.Count.ToString();

            stringBuilder.AppendLine($"Drink orders: {drinkOrders}");

            foreach (var drink in this.orderedDrinks)
            {
                stringBuilder.AppendLine(drink.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.orderedDrinks.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.orderedFoods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
