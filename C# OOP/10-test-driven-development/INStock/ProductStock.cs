namespace INStock
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index >= this.products.Count)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                return this.products[index];
            }

            set
            {
                if (index < 0 || index >= this.products.Count)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                this.products[index] = value;
            }
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            int index = this.products.FindIndex(p => p.Label == product.Label);

            if (index == -1)
            {
                this.products.Add(product);
            }

            else
            {
                this.products[index].Quantity += product.Quantity;
            }
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}");
            }

            return this[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return this.products.Where(p => p.Price >= lo && p.Price <= hi);
        }

        public IProduct FindByLabel(string label)
        {
            var product = this.products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException("Label doesn't exist in the product stock.");
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no products in the stock.");
            }

            return this.products
                .OrderByDescending(p => p.Price)
                .First();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in this.products)
            {
                yield return product;
            }
        }

        public bool Remove(IProduct product)
        {
            if (!this.products.Contains(product))
            {
                return false;
            }

            this.products.Remove(product);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
