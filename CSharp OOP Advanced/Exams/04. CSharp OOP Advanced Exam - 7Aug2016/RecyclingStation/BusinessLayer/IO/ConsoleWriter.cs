namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using System.Text;
    using RecyclingStation.BusinessLayer.Contracts.IO;    

    public class ConsoleWriter : IWriter
    {
        private StringBuilder outputGatherer;

        public ConsoleWriter()
            : this(new StringBuilder())
        {
        }

        public ConsoleWriter(StringBuilder outputGatherer)
        {
            this.OutputGatherer = outputGatherer;
        }

        public StringBuilder OutputGatherer
        {
            get
            {
                return this.outputGatherer;
            }

            private set
            {
                this.outputGatherer = value;
            }
        }

        public void GatherOutput(string outputToGather)
        {
            this.OutputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatherOutput()
        {
            Console.Write(this.OutputGatherer);
        }
    }
}
