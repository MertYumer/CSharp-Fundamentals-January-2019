namespace P03_ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductShop
    {
        public static void Main()
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var orderedShops = shops.OrderBy(s => s.Key);

                if (input[0] == "Revision")
                {
                    foreach (var currentShop in orderedShops)
                    {
                        Console.WriteLine($"{currentShop.Key}->");

                        foreach (var currentProduct in currentShop.Value)
                        {
                            Console.WriteLine($"Product: {currentProduct.Key}, Price: {currentProduct.Value}");
                        }
                    }
                    break;
                }

                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }
        }
    }
}
