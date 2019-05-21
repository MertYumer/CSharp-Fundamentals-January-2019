namespace AnimalCentre.Models.Procedures
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected List<IAnimal> ProcedureHistory { get; set; }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public string History()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.GetType().Name}");

            foreach (var animal in this.ProcedureHistory)
            {
                stringBuilder.AppendLine(animal.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
