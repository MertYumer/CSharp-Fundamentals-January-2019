namespace P05_PizzaCalories
{
    using System;

    public class Topping
    {
        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        break;

                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value.ToLower();
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                string type = char.ToUpper(this.Type[0]) + this.Type.Substring(1);

                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram => this.CalculateCaloriesPerGram();

        private double CalculateCaloriesPerGram()
        {
            double typeModifier = 0;

            switch (this.Type)
            {
                case "meat":
                    typeModifier = 1.2;
                    break;

                case "veggies":
                    typeModifier = 0.8;
                    break; 

                case "cheese":
                    typeModifier = 1.1;
                    break;

                case "sauce":
                    typeModifier = 0.9;
                    break;
            }

            return this.Weight * 2 * typeModifier;
        }
    }
}
