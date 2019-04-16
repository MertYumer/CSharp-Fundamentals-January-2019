namespace P02_Cars.Cars
{
    using P02_Cars.Interfaces;

    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} with {this.Battery} Batteries";
        }
    }
}
