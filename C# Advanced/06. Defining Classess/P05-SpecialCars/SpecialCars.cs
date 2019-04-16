namespace P05_SpecialCars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpecialCars
    {
        static void Main()
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

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public static bool Drive(double distance, Car car)
        {
            return car.FuelQuantity - (distance * car.FuelConsumption / 100) > 0 ? true : false;
        }

        public static string WhoAmI(Car car)
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine($"Make: {car.Make}");
            carInfo.AppendLine($"Model: {car.Model}");
            carInfo.AppendLine($"Year: {car.Year}");
            carInfo.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
            carInfo.Append($"FuelQuantity: {car.FuelQuantity}");
            return carInfo.ToString();
        }

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get; set; }
        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
    }
}
