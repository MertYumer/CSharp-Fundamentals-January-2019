namespace P03_Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workingHours;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        private decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        private decimal WorkingHours
        {
            get => this.workingHours;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkingHours * 5);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            stringBuilder.AppendLine($"Hours per day: {this.WorkingHours:f2}");
            stringBuilder.Append($"Salary per hour: {this.CalculateSalaryPerHour():f2}");
            return stringBuilder.ToString();
        }
    }
}
