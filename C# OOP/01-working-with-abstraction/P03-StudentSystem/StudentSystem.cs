namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; set; }

        public void AddStudent(string[] input)
        {
            var name = input[1];
            var age = int.Parse(input[2]);
            var grade = double.Parse(input[3]);

            if (!this.Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }

        public void ShowStudent(string name)
        {
            if (this.Students.ContainsKey(name))
            {
                var student = this.Students[name];
                string info = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    info += " Excellent student.";
                }

                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    info += " Average student.";
                }

                else
                {
                    info += " Very nice person.";
                }

                Console.WriteLine(info);
            }
        }
    }
}
