namespace P05_PizzaCalories
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" 
                    && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories => this.CalculateCalories();

        private double CalculateCalories()
        {
            double flourModifier = this.FlourType == "white" ? 1.5 : 1.0;
            double bakingModifier = 0;

            switch (this.BakingTechnique)
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;

                case "chewy":
                    bakingModifier = 1.1;
                    break;

                case "homemade":
                    bakingModifier = 1.0;
                    break;
            }

            return (this.Weight * 2) * flourModifier * bakingModifier;
        }
    }
}
