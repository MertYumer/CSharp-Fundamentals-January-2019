namespace P07_SpeedRacing
{
    using System;

    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public int Distance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = 0;
        }

        public void CheckFuel(int distance)
        {
            if (FuelAmount - distance * FuelConsumption >= 0)
            {
                FuelAmount -= distance * FuelConsumption;
                Distance += distance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Distance}".ToString();
        }
    }
}
