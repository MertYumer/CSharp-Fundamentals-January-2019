namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static List<Department> departments;
        public static List<Doctor> doctors;

        public static void Main()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Output")
                {
                    break;
                }

                var departmentName = input[0];
                var doctorName = input[1] + ' ' + input[2];
                var patient = input[3];

                Department department = GetDepartment(departmentName);
                Doctor doctor = GetDoctor(doctorName);
                bool hasFreeSpace = department.Rooms.Sum(r => r.Patients.Count) < 60;

                for (int room = 0; room < department.Rooms.Count; room++)
                {
                    if (department.Rooms[room].Patients.Count < 3)
                    {
                        department.Rooms[room].Patients.Add(patient);
                        doctor.Patients.Add(patient);
                        break;
                    }
                }
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
                    string departmentName = command[0];
                    Department department = GetDepartment(departmentName);

                    foreach (var room in department.Rooms.Where(r => r.Patients.Count > 0))
                    {
                        PrintPatients(room.Patients);
                    }
                }

                else if (int.TryParse(command[1], out int room))
                {
                    string departmentName = command[0];
                    Department department = GetDepartment(departmentName);
                    int roomNumber = int.Parse(command[1]) - 1;
                    var patients = department.Rooms[roomNumber]
                        .Patients
                        .OrderBy(p => p)
                        .ToList();

                    PrintPatients(patients);
                }

                else
                {
                    var doctorName = command[0] + ' ' + command[1];
                    var doctor = GetDoctor(doctorName);
                    var patients = doctor
                        .Patients
                        .OrderBy(p => p)
                        .ToList();

                    PrintPatients(patients);
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

        public static Doctor GetDoctor(string doctorName)
        {
            var doctor = doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                doctor = new Doctor(doctorName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        public static Department GetDepartment(string departmentName)
        {
            var department = departments.FirstOrDefault(d => d.Name == departmentName);

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }

            return department;
        }
    }
}
