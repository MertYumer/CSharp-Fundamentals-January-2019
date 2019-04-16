namespace P05_PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var input = Console.ReadLine().Split();
                var pizza = new Pizza(input[1]);

                input = Console.ReadLine().Split();
                var dough = new Dough(input[1], input[2], int.Parse(input[3]));
                pizza.Dough = dough;

                while (true)
                {
                    input = Console.ReadLine().Split();

                    if (input[0] == "END")
                    {
                        Console.WriteLine(pizza);
                        break;
                    }

                    var topping = new Topping(input[1], int.Parse(input[2]));
                    pizza.AddTopping(topping);
                }
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
