namespace P01_Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        protected double FuelQuantity { get; set; }

        protected double FuelConsumptionPerKm { get; set; }

        public string Drive(double distance)
        {
            if (this.FuelConsumptionPerKm * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.FuelConsumptionPerKm * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
