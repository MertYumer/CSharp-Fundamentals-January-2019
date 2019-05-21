namespace P06_CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyRoster
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();
            var departments = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < peopleCount; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                Employee employee;

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<decimal>());
                }

                departments[department].Add(salary);

                if (input.Length == 4)
                {
                    employee = new Employee(name, salary, position, department);
                }

                else if (input.Length == 6)
                {
                    string email = input[4];
                    int age = int.Parse(input[5]);
                    employee = new Employee(name, salary, position, department, email, age);
                }

                else
                {
                    int age = -1;
                    bool isAge = int.TryParse(input[4], out age);

                    if (isAge)
                    {
                        age = int.Parse(input[4]);
                        employee = new Employee(name, salary, position, department, age);
                    }

                    else
                    {
                        string email = input[4];
                        employee = new Employee(name, salary, position, department, email);
                    }
                }

                employees.Add(employee);
            }

            var bestDepartment = departments
                .OrderByDescending(d => d.Value.Average())
                .First();

            var choosenDepartment = employees
                .Where(e => e.Department == bestDepartment.Key)
                .OrderByDescending(e => e.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {choosenDepartment[0].Department}");

            foreach (var employee in choosenDepartment)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} " +
                    $"{employee.Email} {employee.Age}");
            }
        }
    }
}
