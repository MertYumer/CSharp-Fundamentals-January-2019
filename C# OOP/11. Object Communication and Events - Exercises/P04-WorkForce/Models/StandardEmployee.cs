namespace P04_WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int workHoursPerWeek = 40;

        public StandardEmployee(string name) 
            : base(name, workHoursPerWeek)
        {
        }
    }
}
