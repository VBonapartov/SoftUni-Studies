using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private SystemManager systemManager;

    public Engine(SystemManager systemManager, IReader reader, IWriter writer)
    {
        this.systemManager = systemManager;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {        
        Regex regex = new Regex(@"([\w]+)\(([^\)]+)\)");

        string input = string.Empty;
        string result = string.Empty;

        while (!(input = this.reader.ReadLine()).Equals("System Split"))
        {
            if (regex.IsMatch(input))
            {
                MatchCollection matches = regex.Matches(input);
                string command = matches[0].Groups[1].Value;
                string[] dataSystem = matches[0].Groups[2].Value
                                                            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                            .ToArray();

                switch (command)
                {
                    case "RegisterPowerHardware":
                        this.systemManager.RegisterPowerHardware(dataSystem[0], int.Parse(dataSystem[1]), int.Parse(dataSystem[2]));
                        break;

                    case "RegisterHeavyHardware":
                        this.systemManager.RegisterHeavyHardware(dataSystem[0], int.Parse(dataSystem[1]), int.Parse(dataSystem[2]));
                        break;

                    case "RegisterExpressSoftware":
                        this.systemManager.RegisterExpressSoftware(dataSystem[0], dataSystem[1], int.Parse(dataSystem[2]), int.Parse(dataSystem[3]));
                        break;

                    case "RegisterLightSoftware":
                        this.systemManager.RegisterLightSoftware(dataSystem[0], dataSystem[1], int.Parse(dataSystem[2]), int.Parse(dataSystem[3]));
                        break;

                    case "ReleaseSoftwareComponent":
                        this.systemManager.ReleaseSoftwareComponent(dataSystem[0], dataSystem[1]);
                        break;

                    case "Dump":
                        this.systemManager.Dump(dataSystem[0]);
                        break;

                    case "Restore":
                        this.systemManager.Restore(dataSystem[0]);
                        break;

                    case "Destroy":
                        this.systemManager.Destroy(dataSystem[0]);
                        break;

                    default:
                        break;
                }
            }
            else if (input == "Analyze()")
            {
                result = this.systemManager.Analyze();
                this.writer.WriteLine(result);
            }
            else if (input == "DumpAnalyze()")
            {
                result = this.systemManager.DumpAnalyze();
                this.writer.WriteLine(result);
            }
        }

        result = this.systemManager.SystemSplit();
        if (!result.Equals(string.Empty))
        {
            this.writer.WriteLine(result);
        }
    }
}