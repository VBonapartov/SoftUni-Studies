using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private IReader reader;
    private IWriter writer;    

    public Engine(DraftManager draftManager, IReader reader, IWriter writer)
    {
        this.draftManager = draftManager;
        this.reader = reader;
        this.writer = writer;        
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    { 
        while (true)
        {
            string[] cmdArgs = this.reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            string result = string.Empty;

            switch (command)
            {
                case "RegisterHarvester":
                    result = this.draftManager.RegisterHarvester(cmdArgs.Skip(1).ToList());
                    break;

                case "RegisterProvider":
                    result = this.draftManager.RegisterProvider(cmdArgs.Skip(1).ToList());
                    break;

                case "Day":
                    result = this.draftManager.Day();
                    break;

                case "Mode":
                    result = this.draftManager.Mode(cmdArgs.Skip(1).ToList());
                    break;

                case "Check":
                    result = this.draftManager.Check(cmdArgs.Skip(1).ToList());                    
                    break;

                case "Shutdown":
                    result = this.draftManager.ShutDown();
                    break;
            }

            if (!result.Equals(string.Empty))
            {
                this.writer.WriteLine(result);
            }

            if (command.Equals("Shutdown"))
            {
                break;
            }
        }
    }
}
