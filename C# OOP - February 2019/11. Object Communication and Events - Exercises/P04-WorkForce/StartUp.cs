namespace P04_WorkForce
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var jobs = new JobList();
            var employees = new List<Employee>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "Job":
                        string jobName = input[1];
                        int requiredHours = int.Parse(input[2]);
                        string employeeName = input[3];
                        var employee = employees.First(e => e.Name == employeeName);
                        var job = new Job(jobName, requiredHours, employee);
                        jobs.AddJob(job);
                        break;

                    case "StandardEmployee":
                        employeeName = input[1];
                        employee = new StandardEmployee(employeeName);
                        employees.Add(employee);
                        break;

                    case "PartTimeEmployee":
                        employeeName = input[1];
                        employee = new PartTimeEmployee(employeeName);
                        employees.Add(employee);
                        break;

                    case "Pass":
                        jobs.ToList().ForEach(j => j.Update());

                        break;

                    case "Status":
                        foreach (var currentJob in jobs)
                        {
                            Console.WriteLine(currentJob);
                        }

                        break;

                    case "End":
                        return;
                }
            }
        }
    }
}
