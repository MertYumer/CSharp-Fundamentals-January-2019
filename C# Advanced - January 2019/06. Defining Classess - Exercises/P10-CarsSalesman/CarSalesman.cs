namespace P10_CarsSalesman
{
    using System;
    using System.Collections.Generic;

    public class CarSalesman
    {
        public static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < enginesCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                Engine engine;

                if (input.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }

                else
                {
                    int displacement = -1;
                    bool isDisplacement = int.TryParse(input[2], out displacement);

                    if (isDisplacement)
                    {
                        displacement = int.Parse(input[2]);
                        engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                        string efficiency = input[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines.Find(e => e.Model == input[1]);
                Car car;

                if (input.Length == 2)
                {
                    car = new Car(model, engine);
                }

                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                    car = new Car(model, engine, weight, color);
                }

                else
                {
                    int weight = -1;
                    bool isWeight = int.TryParse(input[2], out weight);

                    if (isWeight)
                    {
                        weight = int.Parse(input[2]);
                        car = new Car(model, engine, weight);
                    }

                    else
                    {
                        string color = input[2];
                        car = new Car(model, engine, color);
                    }
                }

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
