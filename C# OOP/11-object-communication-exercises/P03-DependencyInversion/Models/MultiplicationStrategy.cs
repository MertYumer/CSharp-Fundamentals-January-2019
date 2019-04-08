namespace P03_DependencyInversion.Models
{
    using Contracts;

    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
