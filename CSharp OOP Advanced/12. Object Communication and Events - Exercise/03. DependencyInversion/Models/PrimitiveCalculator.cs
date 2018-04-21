public class PrimitiveCalculator : IPrimitiveCalculator
{
    private ICalculationStrategy currentStrategy;

    public PrimitiveCalculator()
        : this(new AdditionStrategy())
    {
    }

    public PrimitiveCalculator(ICalculationStrategy strategy)
    {
        this.currentStrategy = strategy;
    }

    public void ChangeStrategy(ICalculationStrategy strategy)
    {
        this.currentStrategy = strategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.currentStrategy.Calculate(firstOperand, secondOperand);
    }
}
