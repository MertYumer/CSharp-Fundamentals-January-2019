namespace P02_VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }

            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.tankCapacity = tankCapacity;
        }

        protected double FuelQuantity { get; set; }

        protected double FuelConsumptionPerKm { get; set; }

        public virtual string Drive(double distance)
        {
            if (this.FuelConsumptionPerKm * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.FuelConsumptionPerKm * distance);
                this.tankCapacity += (this.FuelConsumptionPerKm * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
