namespace P03_DependencyInversion
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            while (true)
            {
                var input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "mode":
                        char symbol = input[1][0];
                        calculator.ChangeStrategy(symbol);
                        break;

                    case "End":
                        return;

                    default:
                        int firstOperand = int.Parse(input[0]);
                        int secondOperand = int.Parse(input[1]);
                        Console.WriteLine(calculator
                            .PerformCalculation(firstOperand, secondOperand));
                        break;
                }
            }
        }
    }
}
