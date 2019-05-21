namespace P04_WorkForce.Models
{
    using System.Collections.Generic;

    public class JobList : List<Job>
    {
        public void AddJob(Job job)
        {
            this.Add(job);
            job.JobFinished += this.RemoveJobWhenIsFinished;
        }

        public void RemoveJobWhenIsFinished(Job job)
        {
            this.Remove(job);
        }
    }
}
