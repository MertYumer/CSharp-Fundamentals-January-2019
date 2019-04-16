namespace P04_WorkForce.Models
{
    using System;

    public delegate void JobFinishedEventHandler(Job job);

    public class Job
    {
        private Employee employee;
        private string name;
        private int hoursOfWorkRequired;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.name = name;
            this.hoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public event JobFinishedEventHandler JobFinished;

        public void Update()
        {
            this.hoursOfWorkRequired -= this.employee.WorkHoursPerWeek;

            if (this.hoursOfWorkRequired <= 0)
            {
                Console.WriteLine($"Job {this.name} done!");
                this.JobFinished.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
        }
    }
}
