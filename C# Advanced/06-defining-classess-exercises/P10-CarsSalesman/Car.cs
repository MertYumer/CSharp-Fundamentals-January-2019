namespace P10_CarsSalesman
{
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
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

        public override string ToString()
        {
            var information = new StringBuilder();
            information.AppendLine($"{Model}:");
            information.AppendLine($"  {Engine.Model}:");
            information.AppendLine($"    Power: {Engine.Power}");
            information.AppendLine(Engine.Displacement == -1
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
