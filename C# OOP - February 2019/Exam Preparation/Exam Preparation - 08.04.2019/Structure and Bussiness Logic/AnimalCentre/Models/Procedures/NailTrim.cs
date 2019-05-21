namespace AnimalCentre.Models.Procedures
{
    using Models.Contracts;

    public class NailTrim : Procedure
    {
        private const int Happiness = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= Happiness;
            animal.ProcedureTime -= procedureTime;
            this.ProcedureHistory.Add(animal);
        }
    }
}
