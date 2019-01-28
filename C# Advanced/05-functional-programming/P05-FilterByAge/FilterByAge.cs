namespace P05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class FIlterByAge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var people = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int searchedAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, searchedAge);
            Action<Person> printer = CreatePrinter(format);

            foreach (var person in people)
            {
                if (tester(person.Age))
                {
                    printer(person);
                }
            }
        }

        public static Func<int, bool> CreateTester(string condition, int searchedAge)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < searchedAge;

                case "older":
                    return x => x >= searchedAge;

                default:
                    return null;
            }
        }

        public static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Name}");

                case "age":
                    return person => Console.WriteLine($"{person.Age}");

                case "name age":
                    return person => Console.WriteLine($"{person.Name} - {person.Age}"); 

                default:
                    return null;
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
