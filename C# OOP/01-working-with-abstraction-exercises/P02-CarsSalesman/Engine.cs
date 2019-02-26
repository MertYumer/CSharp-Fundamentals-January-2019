namespace P02_CarsSalesman
{
    public class Engine
    {
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power)
            : this(model, power, -1, "n/a")
        {
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine CreateEngine(string[] input)
        {
            string model = input[0];
            int power = int.Parse(input[1]);
            Engine engine;

            if (input.Length == 2)
            {
                engine = new Engine(model, power);
            }

            else if (input.Length == 4)
            {
                int displacement = int.Parse(input[2]);
                string efficiency = input[3];
                engine = new Engine(model, power, displacement, efficiency);
            }

            else
            {
                int displacement = -1;
                bool isDisplacement = int.TryParse(input[2], out displacement);

                if (isDisplacement)
                {
                    displacement = int.Parse(input[2]);
                    engine = new Engine(model, power, displacement);
                }

                else
                {
                    string efficiency = input[2];
                    engine = new Engine(model, power, efficiency);
                }
            }

            return engine;
        }
    }
}
