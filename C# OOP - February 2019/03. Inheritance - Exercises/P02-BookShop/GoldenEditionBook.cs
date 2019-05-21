﻿namespace P02_BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price) 
            : base(author, title, price)
        {

        }

        public override decimal Price { get => base.Price * 1.3m; }
    }
}
