namespace P08_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RawData
    {
        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                var input = Console.ReadLine().Split();
                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];

                var engine = new Engine(speed, power);
                var cargo = new Cargo(weight, type);
                var tires = new Tire[4];
                int counter = 0;

                for (int j = 5; j < input.Length - 1; j += 2)
                {
                    double pressure = double.Parse(input[j]);
                    int age = int.Parse(input[j + 1]);

                    var tire = new Tire(pressure, age);
                    tires[counter] = tire;
                    counter++;
                }

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cargoType = Console.ReadLine();

            if (cargoType == "fragile")
            {
                var carsByType = cars
                    .Where(c => c.Cargo.Type == "fragile" &&
                    c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, carsByType));
            }

            else if (cargoType == "flamable")
            {
                var carsByType = cars
                    .Where(c => c.Cargo.Type == "flamable" &&
                    c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, carsByType));
            }
        }
    }
}
