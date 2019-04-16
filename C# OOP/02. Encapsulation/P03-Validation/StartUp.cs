namespace P03_Validation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                try
                {
                    var person = new Person(
                        input[0],
                        input[1],
                        int.Parse(input[2]),
                        decimal.Parse(input[3]));

                    persons.Add(person);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            var bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
