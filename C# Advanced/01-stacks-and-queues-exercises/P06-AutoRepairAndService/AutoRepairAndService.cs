namespace P06_AutoRepairAndService
{
    using System;
    using System.Collections.Generic;

    public class AutoRepairAndService
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var cars = new Queue<string>(input);
            var servedCars = new Stack<string>();

            while (true)
            {
                var command = Console.ReadLine().Split("-");

                if (command[0] == "End")
                {
                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"Vehicles for service: " + string.Join(", ", cars));
                    }
                    
                    Console.WriteLine($"Served vehicles: " + string.Join(", ", servedCars));
                    break;
                }

                else if (command[0] == "Service" && cars.Count > 0)
                {
                    string currentVehicle = cars.Dequeue();
                    servedCars.Push(currentVehicle);
                    Console.WriteLine($"Vehicle {currentVehicle} got served.");
                }

                else if (command[0] == "CarInfo")
                {
                    string currentVehicle = command[1];

                    if (cars.Contains(currentVehicle))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }

                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                else if (command[0] == "History")
                {
                    var tempCars = servedCars;

                    Console.WriteLine(string.Join(", ", servedCars));

                    servedCars = tempCars;
                }
            }
        }
    }
}
