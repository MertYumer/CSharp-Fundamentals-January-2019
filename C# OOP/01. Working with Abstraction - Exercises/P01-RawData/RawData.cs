namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
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

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }

            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
