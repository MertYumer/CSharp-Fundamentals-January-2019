namespace P02_VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            if ((this.FuelConsumptionPerKm + 1.4) * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= ((this.FuelConsumptionPerKm + 1.4) * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}
