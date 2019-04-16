namespace P02_BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get => this.author;
            set
            {
                string lastName = value.Split().Last();

                if (value.Length > 1 && char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Type: {this.GetType().Name}");
            stringBuilder.AppendLine($"Title: {this.Title}");
            stringBuilder.AppendLine($"Author: {this.Author}");
            stringBuilder.Append($"Price: {this.Price:f2}");
            return stringBuilder.ToString();
        }
    }
}
