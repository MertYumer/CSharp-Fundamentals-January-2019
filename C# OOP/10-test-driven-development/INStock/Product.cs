namespace INStock
{
    using Contracts;
    using System;
    using System.Linq;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get => this.label;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Label must be at least 1 character long.");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be greater than zero.");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be greater than zero.");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
