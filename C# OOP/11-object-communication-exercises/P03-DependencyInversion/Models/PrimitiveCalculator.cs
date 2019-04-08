namespace P03_DependencyInversion.Models
{
    using Contracts;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            IStrategy currentStrategy = null;

            switch (@operator)
            {
                case '+':
                    currentStrategy = new AdditionStrategy();
                    break;

                case '-':
                    currentStrategy = new SubtractionStrategy();
                    break;

                case '*':
                    currentStrategy = new MultiplicationStrategy();
                    break;

                case '/':
                    currentStrategy = new DivisionStrategy();
                    break;
            }

            this.strategy = currentStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
