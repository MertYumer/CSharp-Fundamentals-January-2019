namespace P05_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        internal Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        private double TotalCalories()
        {
            double doughCalories = this.dough.Calories;
            double toppingCalories = this.toppings.Sum(t => t.CaloriesPerGram);
            return doughCalories + toppingCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories():f2} Calories.";
        }
    }
}
