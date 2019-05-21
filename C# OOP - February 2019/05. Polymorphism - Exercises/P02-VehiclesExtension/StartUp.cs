namespace P02_VehiclesExtension
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumptionPerKm = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);
            Car car = new Car(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            input = Console.ReadLine().Split();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumptionPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);
            Truck truck = new Truck(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            input = Console.ReadLine().Split();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumptionPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);
            Bus bus = new Bus(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                input = Console.ReadLine().Split();
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

                    case "Bus":
                        if (command == "DriveEmpty")
                        {
                            double distance = double.Parse(input[2]);
                            Console.WriteLine(bus.DriveEmpty(distance));
                        }

                        else
                        {
                            bus = (Bus)CheckCommand(command, bus, input);
                        }

                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
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
                try
                {
                    vehicle.Refuel(liters);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return vehicle;
        }
    }
}
