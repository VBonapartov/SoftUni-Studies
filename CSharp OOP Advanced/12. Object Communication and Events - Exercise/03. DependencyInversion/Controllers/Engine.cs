public class Engine
{
    private IPrimitiveCalculator calculator;
    private IReader reader;
    private IWriter writer;

    public Engine(IPrimitiveCalculator calculator, IReader reader, IWriter writer)
    {
        this.calculator = calculator;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        string input = string.Empty;

        while (!(input = this.reader.ReadLine()).Equals("End"))
        {
            string[] cmdArgs = input.Split(' ');

            if (cmdArgs[0].Equals("mode"))
            {
                ICalculationStrategy strategy = null;

                switch (cmdArgs[1])
                {
                    case "+":
                        strategy = new AdditionStrategy();
                        break;

                    case "-":
                        strategy = new SubtractionStrategy();
                        break;

                    case "*":
                        strategy = new MultiplicationStrategy();
                        break;

                    case "/":
                        strategy = new DivisionStrategy();
                        break;

                    default:
                        break;
                }

                this.calculator.ChangeStrategy(strategy);
            }
            else
            {
                int firstOperand = int.Parse(cmdArgs[0]);
                int secondOperand = int.Parse(cmdArgs[1]);

                int result = this.calculator.PerformCalculation(firstOperand, secondOperand);
                this.writer.WriteLine(result.ToString());
            }
        }
    }
}
