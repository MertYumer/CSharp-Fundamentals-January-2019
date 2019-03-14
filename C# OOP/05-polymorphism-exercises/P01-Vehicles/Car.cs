namespace P01_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            this.FuelConsumptionPerKm += 0.9;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
