using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                var currentTires = input.Split().Select(double.Parse).ToArray();
                var tiresPack = new Tire[4];
                int counter = 0;

                for (int i = 0; i < currentTires.Length - 1; i += 2)
                {
                    var currentTire = new Tire((int)currentTires[i], currentTires[i + 1]);
                    tiresPack[counter] = currentTire;
                    counter++;
                }

                tires.Add(tiresPack);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                var currentEngine = input.Split().Select(double.Parse).ToArray();
                var engine = new Engine((int)currentEngine[0], currentEngine[1]);
                engines.Add(engine);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Show special")
                {
                    foreach (var currentCar in cars)
                    {
                        bool enoughFuel = Car.Drive(20, currentCar);

                        double pressureSum = 0.0;

                        for (int i = 0; i < currentCar.Tires.Length; i++)
                        {
                            pressureSum += currentCar.Tires[i].Pressure;
                        }

                        if (enoughFuel && currentCar.Year >= 2017 &&
                            currentCar.Engine.HorsePower > 330 &&
                            pressureSum > 9 && pressureSum < 10)
                        {
                            currentCar.FuelQuantity -= (20 * currentCar.FuelConsumption / 100);
                            Console.WriteLine(Car.WhoAmI(currentCar));
                        }
                    }

                    break;
                }

                var currentModel = input.Split();
                string make = currentModel[0];
                string model = currentModel[1];
                int year = int.Parse(currentModel[2]);
                double fuelQuantity = double.Parse(currentModel[3]);
                double fuelConsumption = double.Parse(currentModel[4]);
                int engineIndex = int.Parse(currentModel[5]);
                int tiresIndex = int.Parse(currentModel[6]);

                var car = new Car(make, model, year, fuelQuantity,
                    fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }
        }
    }
}
