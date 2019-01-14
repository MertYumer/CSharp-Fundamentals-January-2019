namespace P03_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var calculatorStack = new Stack<string>(input.Reverse());

            while (calculatorStack.Count > 1)
            {
                int firstNumber = int.Parse(calculatorStack.Pop());
                string operand = calculatorStack.Pop();
                int secondNumber = int.Parse(calculatorStack.Pop());

                switch (operand)
                {
                    case "+":
                        calculatorStack.Push((firstNumber + secondNumber).ToString());
                        break;

                    case "-":
                        calculatorStack.Push((firstNumber - secondNumber).ToString());
                        break;

                    default:
                        calculatorStack.Push(0.ToString());
                        break;
                }
            }

            Console.WriteLine(calculatorStack.Pop());
        }
    }
}
