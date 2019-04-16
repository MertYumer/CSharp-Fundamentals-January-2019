namespace P04_WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int workHoursPerWeek = 20;

        public PartTimeEmployee(string name)
            : base(name, workHoursPerWeek)
        {
        }
    }
}
