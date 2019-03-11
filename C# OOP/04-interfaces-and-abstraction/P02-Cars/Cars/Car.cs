namespace P02_Cars.Cars
{
    using P02_Cars.Interfaces;
    using System.Text;

    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; protected set; }

        public string Color { get; protected set; }

        public string Start()
        {
            return "Engine start!";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public virtual string GetInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetInfo());
            builder.AppendLine(this.Start());
            builder.Append(this.Stop());
            return builder.ToString();
        }
    }
}
