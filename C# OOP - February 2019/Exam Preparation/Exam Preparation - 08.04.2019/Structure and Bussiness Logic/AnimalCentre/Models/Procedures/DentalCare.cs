namespace AnimalCentre.Models.Procedures
{
    using Models.Contracts;

    public class DentalCare : Procedure
    {
        private const int Happiness = 12;
        private const int Energy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness += Happiness;
            animal.Energy += Energy;
            animal.ProcedureTime -= procedureTime;
            this.ProcedureHistory.Add(animal);
        }
    }
}
