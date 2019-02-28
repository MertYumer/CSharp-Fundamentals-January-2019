namespace P04_ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.money -= product.Cost;
                this.products.Add(product);
                return $"{this.name} bought {product.Name}";
            }

            return $"{this.name} can't afford {product.Name}";
        }
    }
}
