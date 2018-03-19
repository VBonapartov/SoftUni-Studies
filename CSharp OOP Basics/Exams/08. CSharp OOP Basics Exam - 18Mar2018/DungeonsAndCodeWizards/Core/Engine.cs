namespace DungeonsAndCodeWizards.Core
{    
    using System;
    using System.Linq;
    using DungeonsAndCodeWizards.IO;

    public class Engine
    {
        private readonly DungeonMaster dungeonMaster;
                        
        private IReader reader;
        private IWriter writer;

        private bool isRunning;

        public Engine(DungeonMaster dungeonMaster, IReader reader, IWriter writer)
        {
            this.dungeonMaster = dungeonMaster;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.isRunning = true;

            while (!this.dungeonMaster.IsGameOver() && this.isRunning)
            {
                string command = this.reader.ReadLine();

                try
                {
                    this.ExecuteCommand(command);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine("Invalid Operation: " + ioe.Message);
                }
            }

            this.writer.WriteLine("Final stats:");
            this.writer.WriteLine(this.dungeonMaster.GetStats());
        }

        private void ExecuteCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            string[] cmdArgs = command.Split(" ");
            string commandName = cmdArgs[0];

            string result = string.Empty;

            switch (commandName)
            {
                case "JoinParty":
                    result = this.dungeonMaster.JoinParty(cmdArgs.Skip(1).ToArray());
                    break;

                case "AddItemToPool":
                    result = this.dungeonMaster.AddItemToPool(cmdArgs.Skip(1).ToArray());
                    break;

                case "PickUpItem":
                    result = this.dungeonMaster.PickUpItem(cmdArgs.Skip(1).ToArray());
                    break;

                case "UseItem":
                    result = this.dungeonMaster.UseItem(cmdArgs.Skip(1).ToArray());
                    break;

                case "UseItemOn":
                    result = this.dungeonMaster.UseItemOn(cmdArgs.Skip(1).ToArray());
                    break;

                case "GiveCharacterItem":
                    result = this.dungeonMaster.GiveCharacterItem(cmdArgs.Skip(1).ToArray());
                    break;

                case "GetStats":
                    result = this.dungeonMaster.GetStats();
                    break;

                case "Attack":
                    result = this.dungeonMaster.Attack(cmdArgs.Skip(1).ToArray());
                    break;

                case "Heal":
                    result = this.dungeonMaster.Heal(cmdArgs.Skip(1).ToArray());
                    break;

                case "EndTurn":
                    result = this.dungeonMaster.EndTurn(cmdArgs.Skip(1).ToArray());
                    break;
            }

            this.writer.WriteLine(result);
        }
    }
}
