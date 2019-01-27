namespace P05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class FIlterByAge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(name, age);
            }

            string condition = Console.ReadLine();
            int searchedAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, searchedAge);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            foreach (var person in people)
            {
                if (tester(person.Value))
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

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");

                case "age":
                    return person => Console.WriteLine($"{person.Value}");

                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");

                default:
                    return null;
            }
        }
    }
}
