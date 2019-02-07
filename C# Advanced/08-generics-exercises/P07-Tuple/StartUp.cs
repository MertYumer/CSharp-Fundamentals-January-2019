namespace P07_Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            string name = $"{input[0]} {input[1]}";
            string address = input[2];
            var firstTuple = new Tuple<string, string>(name, address);
            Console.WriteLine(firstTuple);

            input = Console.ReadLine().Split();
            name = input[0];
            int liters = int.Parse(input[1]);
            var secondTuple = new Tuple<string, int>(name, liters);
            Console.WriteLine(secondTuple);

            input = Console.ReadLine().Split();
            int integer = int.Parse(input[0]);
            double realNumber = double.Parse(input[1]);
            var thirdTuple = new Tuple<int, double>(integer, realNumber);
            Console.WriteLine(thirdTuple);
        }
    }
}
