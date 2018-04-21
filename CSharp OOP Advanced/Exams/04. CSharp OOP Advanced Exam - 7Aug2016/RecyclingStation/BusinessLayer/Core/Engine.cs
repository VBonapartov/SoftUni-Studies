namespace RecyclingStation.BusinessLayer.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BusinessLayer.Contracts.Core;
    using BusinessLayer.Contracts.IO;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] recyclingStationMethods;

        private IReader reader;
        private IWriter writer;

        private IRecyclingStation recyclingStation;

        public Engine(IReader reader, IWriter writer, IRecyclingStation recyclingStation)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingStation = recyclingStation;

            this.recyclingStationMethods = this.recyclingStation.GetType().GetMethods();
        }

        public void Run()
        {
            string inputLine = string.Empty;

            while (!(inputLine = this.reader.ReadLine()).Equals(TerminatingCommand))
            {
                string[] commandArgs = this.SplitStringByChar(inputLine, ' ');

                string methodName = commandArgs[0];
                string[] methodNonParseParams = default(string[]);

                if (commandArgs.Length == 2)
                {
                    methodNonParseParams = this.SplitStringByChar(commandArgs[1], '|');
                }

                MethodInfo methodToInvoke = this.recyclingStationMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];

                for (int currentConvertion = 0; currentConvertion < methodParams.Length; currentConvertion++)
                {
                    Type currentParamType = methodParams[currentConvertion].ParameterType;

                    string toConvert = methodNonParseParams[currentConvertion];
                    parsedParams[currentConvertion] = Convert.ChangeType(toConvert, currentParamType);
                }

                object result = methodToInvoke.Invoke(this.recyclingStation, parsedParams);

                this.writer.GatherOutput(result.ToString());
            }

            this.writer.WriteGatherOutput();
        }

        private string[] SplitStringByChar(string toSplit, params char[] toSplitBy)
        {
            return toSplit.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
