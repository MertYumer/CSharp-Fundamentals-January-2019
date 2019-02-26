namespace P02_CarsSalesman
{
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var information = new StringBuilder();
            information.AppendLine($"{this.Model}:");
            information.AppendLine($"  {this.Engine.Model}:");
            information.AppendLine($"    Power: {this.Engine.Power}");
            information.AppendLine(this.Engine.Displacement == -1
                ? "    Displacement: n/a"
                : $"    Displacement: {Engine.Displacement}");
            information.AppendLine($"    Efficiency: {Engine.Efficiency}");
            information.AppendLine(Weight == -1
                ? "  Weight: n/a"
                : $"  Weight: {Weight}");
            information.Append($"  Color: {Color}");
            return information.ToString();
        }
    }
}
