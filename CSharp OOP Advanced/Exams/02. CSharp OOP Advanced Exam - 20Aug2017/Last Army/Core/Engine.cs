using System;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;   
    private IGameController gameController;

    private bool isRunning;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {        
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;

        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            string input = this.reader.ReadLine();
            if (input == OutputMessages.InputTerminateString)
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.StoreMessage(arg.Message);
            }
        }

        this.gameController.ProduceSummury();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}