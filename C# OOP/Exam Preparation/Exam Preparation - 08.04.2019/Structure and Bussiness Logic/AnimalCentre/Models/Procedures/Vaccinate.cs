namespace AnimalCentre.Models.Procedures
{
    using Models.Contracts;

    public class Vaccinate : Procedure
    {
        private const int Energy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Energy -= Energy;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;
            this.ProcedureHistory.Add(animal);
        }
    }
}
