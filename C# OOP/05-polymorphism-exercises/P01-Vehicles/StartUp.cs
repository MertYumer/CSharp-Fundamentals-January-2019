namespace P01_Vehicles
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstInput = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(firstInput[1]);
            double fuelConsumptionPerKm = double.Parse(firstInput[2]);
            Car car = new Car(fuelQuantity, fuelConsumptionPerKm);

            var secondInput = Console.ReadLine().Split();
            fuelQuantity = double.Parse(secondInput[1]);
            fuelConsumptionPerKm = double.Parse(secondInput[2]);
            Truck truck = new Truck(fuelQuantity, fuelConsumptionPerKm);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];
                string type = input[1];

                switch (type)
                {
                    case "Car":
                        car = (Car)CheckCommand(command, car, input);
                        break;

                    case "Truck":
                        truck = (Truck)CheckCommand(command, truck, input);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        public static Vehicle CheckCommand(string command, Vehicle vehicle, string[] input)
        {
            if (command == "Drive")
            {
                double distance = double.Parse(input[2]);
                Console.WriteLine(vehicle.Drive(distance));
            }

            else if (command == "Refuel")
            {
                double liters = double.Parse(input[2]);
                vehicle.Refuel(liters);
            }

            return vehicle;
        }
    }
}
