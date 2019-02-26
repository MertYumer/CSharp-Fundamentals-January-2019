namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Output")
                {
                    break;
                }

                var department = input[0];
                var name = input[1] + ' ' + input[2];
                var patient = input[3];

                AddPatient(doctors, name, patient);
                AddPatient(departments, department, patient);
            }

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                else if (command.Length == 1)
                {
                    var searchedDepartment = departments[command[0]];
                    PrintPatients(searchedDepartment);
                }

                else if (int.TryParse(command[1], out int room))
                {
                    int roomNumber = int.Parse(command[1]) - 1;

                    if (roomNumber >= 20)
                    {
                        continue;
                    }

                    var searchedRoom = departments[command[0]]
                        .Skip(3 * roomNumber)
                        .Take(3)
                        .OrderBy(p => p)
                        .ToList();

                    PrintPatients(searchedRoom);
                }

                else
                {
                    var doctor = command[0] + ' ' + command[1];
                    var doctorsPatients = doctors[doctor]
                        .OrderBy(p => p)
                        .ToList();

                    PrintPatients(doctorsPatients);
                }
            }
        }

        public static void PrintPatients(List<string> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }

        public static void AddPatient(Dictionary<string, List<string>> collection, string name, string patient)
        {
            if (!collection.ContainsKey(name))
            {
                collection[name] = new List<string>();
            }

            collection[name].Add(patient);
        }
    }
}
