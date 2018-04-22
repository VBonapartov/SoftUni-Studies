namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;

            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

		public void Run()
		{
			while (true)
			{
				string input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

				try
				{
					string result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			string end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];
            string[] parameters = cmdArgs.Skip(1).ToArray();

            string result;

            if (command.Equals("LetsRock"))
            {
                result = this.setCоntroller.PerformSets();
                return result;
            }

            var festivalFunction = this.festivalCоntroller.GetType()
                                                              .GetMethods()
                                                              .FirstOrDefault(x => x.Name == command);

            try
            {
                result = (string)festivalFunction.Invoke(this.festivalCоntroller, new object[] { parameters });                
            }
            catch (TargetInvocationException up)
            {
                throw new InvalidOperationException(up.InnerException.Message);
            }

            return result;
        }
    }
}