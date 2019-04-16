namespace P04_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var firstLine = Console.ReadLine()
                .Split(new[] { ';', '=' }
                , StringSplitOptions.RemoveEmptyEntries);

            var secondLine = Console.ReadLine()
                .Split(new[] { ';', '=' }
                , StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < firstLine.Length; i += 2)
            {
                string name = firstLine[i];
                decimal money = decimal.Parse(firstLine[i + 1]);

                try
                {
                    var person = new Person(name, money);
                    people.Add(person);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            for (int i = 0; i < secondLine.Length; i += 2)
            {
                string name = secondLine[i];
                decimal cost = decimal.Parse(secondLine[i + 1]);

                try
                {
                    var product = new Product(name, cost);
                    products.Add(product);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    foreach (var currentPerson in people)
                    {
                        string boughtProducts = currentPerson.Products.Count == 0
                            ? "Nothing bought"
                            : string.Join(", ", currentPerson.Products.Select(p => p.Name));

                        Console.WriteLine($"{currentPerson.Name} - {boughtProducts}");
                    }

                    break;
                }

                string personName = command[0];
                string productName = command[1];
                var person = people.FirstOrDefault(p => p.Name == personName);
                var product = products.FirstOrDefault(p => p.Name == productName);
                Console.WriteLine(person.BuyProduct(product));
            }
        }
    }
}
