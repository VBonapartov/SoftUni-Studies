using System;
using System.Linq;

public class Engine
{
    private CenterManager centerManager;
    private IReader reader;
    private IWriter writer;

    public Engine(CenterManager centerManager, IReader reader, IWriter writer)
    {
        this.centerManager = centerManager;
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
            string[] cmdArgs = this.reader.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            string result = string.Empty;

            switch (command)
            {
                case "RegisterCleansingCenter":
                    this.centerManager.RegisterCleansingCenter(cmdArgs.Skip(1).ToList());
                    break;

                case "RegisterAdoptionCenter":
                    this.centerManager.RegisterAdoptionCenter(cmdArgs.Skip(1).ToList());
                    break;

                case "RegisterCastrationCenter":
                    this.centerManager.RegisterCastrationCenter(cmdArgs.Skip(1).ToList());
                    break;

                case "RegisterDog":
                    this.centerManager.RegisterDog(cmdArgs.Skip(1).ToList());
                    break;

                case "RegisterCat":
                    this.centerManager.RegisterCat(cmdArgs.Skip(1).ToList());
                    break;

                case "SendForCleansing":
                    this.centerManager.SendForCleansing(cmdArgs.Skip(1).ToList());
                    break;

                case "Cleanse":
                    this.centerManager.Cleanse(cmdArgs.Skip(1).ToList());
                    break;

                case "Adopt":
                    this.centerManager.Adopt(cmdArgs.Skip(1).ToList());
                    break;

                case "SendForCastration":
                    this.centerManager.SendForCastration(cmdArgs.Skip(1).ToList());
                    break;

                case "Castrate":
                    this.centerManager.Castrate(cmdArgs.Skip(1).ToList());
                    break;

                case "CastrationStatistics":
                    result = this.centerManager.CastrationStatistics();
                    Console.WriteLine(result);
                    break;

                case "Paw Paw Pawah":
                    result = this.centerManager.PrintStatistics();
                    this.writer.WriteLine(result);
                    return;
            }
        }
    }
}
