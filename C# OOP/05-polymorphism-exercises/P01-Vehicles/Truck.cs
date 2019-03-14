namespace P01_Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            this.FuelConsumptionPerKm += 1.6;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += (liters * 0.95);
        }
    }
}
