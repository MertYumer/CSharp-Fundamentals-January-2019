namespace SoftUniRestaurant.Core
{
    using System;

    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            Console.WriteLine(this.restaurantController
                                .AddFood(input[1], input[2], decimal.Parse(input[3])));
                            break;

                        case "AddDrink":
                            Console.WriteLine(this.restaurantController
                                .AddDrink(input[1], input[2], int.Parse(input[3]), input[4]));
                            break;

                        case "AddTable":
                            Console.WriteLine(this.restaurantController
                                .AddTable(input[1], int.Parse(input[2]), int.Parse(input[3])));
                            break;

                        case "ReserveTable":
                            Console.WriteLine(this.restaurantController
                                .ReserveTable(int.Parse(input[1])));
                            break;

                        case "OrderFood":
                            Console.WriteLine(this.restaurantController
                                .OrderFood(int.Parse(input[1]), input[2]));
                            break;

                        case "OrderDrink":
                            Console.WriteLine(this.restaurantController
                                .OrderDrink(int.Parse(input[1]), input[2], input[3]));
                            break;

                        case "LeaveTable":
                            Console.WriteLine(this.restaurantController
                                .LeaveTable(int.Parse(input[1])));
                            break;

                        case "GetFreeTablesInfo":
                            Console.WriteLine(this.restaurantController.GetFreeTablesInfo());
                            break;

                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(this.restaurantController.GetOccupiedTablesInfo());
                            break;

                        case "END":
                            Console.WriteLine(this.restaurantController.GetSummary());
                            return;
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
