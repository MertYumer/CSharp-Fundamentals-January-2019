namespace P03_Mankind
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var firstInput = Console.ReadLine().Split();
                string firstName = firstInput[0];
                string lastName = firstInput[1];
                string facultyNumber = firstInput[2];
                var student = new Student(firstName, lastName, facultyNumber);

                var secondInput = Console.ReadLine().Split();
                firstName = secondInput[0];
                lastName = secondInput[1];
                decimal weekSalary = decimal.Parse(secondInput[2]);
                decimal workingHours = decimal.Parse(secondInput[3]);
                var worker = new Worker(firstName, lastName, weekSalary, workingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
