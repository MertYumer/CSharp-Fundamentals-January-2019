namespace AnimalCentre.Models.Procedures
{
    using System;
    using Models.Contracts;

    public class Chip : Procedure
    {
        private const int Happiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.Happiness -= Happiness;
            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;
            this.ProcedureHistory.Add(animal);
        }
    }
}
