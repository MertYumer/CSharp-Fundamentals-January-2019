namespace P03_Ferrari
{
    using System.Text;

    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => "488-Spider";

        public string Driver { get; }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"{this.Model}/");
            builder.Append($"{this.UseBrakes()}/");
            builder.Append($"{this.PushGasPedal()}/");
            builder.Append($"{this.Driver}");
            return builder.ToString();
        }
    }
}
