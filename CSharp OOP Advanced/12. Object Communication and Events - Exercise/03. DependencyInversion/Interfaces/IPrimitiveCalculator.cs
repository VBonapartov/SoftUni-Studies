public interface IPrimitiveCalculator
{
    void ChangeStrategy(ICalculationStrategy strategy);

    int PerformCalculation(int firstOperand, int secondOperand);
}
