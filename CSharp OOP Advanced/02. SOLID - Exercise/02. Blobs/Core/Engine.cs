using System;
using System.Collections.Generic;
using System.Text;

public class Engine : IEngine
{
    private readonly ICollection<IBlob> blobs = new List<IBlob>();
    private readonly IDictionary<string, IBlob> blobsByName = new Dictionary<string, IBlob>();

    private IBlobFactory blobFactory;
    private IAttackFactory attackFactory;
    private IBehaviorFactory behaviorFactory;
    private IReader reader;
    private IWriter outputWriter;

    public Engine(
        IBlobFactory blobFactory,
        IAttackFactory attackFactory,
        IBehaviorFactory behaviorFactory,
        IReader reader,
        IWriter writer)
    {
        this.BlobFactory = blobFactory;
        this.AttackFactory = attackFactory;
        this.BehaviorFactory = behaviorFactory;
        this.InputReader = reader;
        this.OutputWriter = writer;
    }

    protected IBlobFactory BlobFactory
    {
        get
        {
            return this.blobFactory;
        }

        private set
        {
            this.blobFactory = value ?? throw new ArgumentNullException(nameof(value), "The engine's blob factory cannot be null.");
        }
    }

    protected IAttackFactory AttackFactory
    {
        get
        {
            return this.attackFactory;
        }

        private set
        {
            this.attackFactory = value ?? throw new ArgumentNullException(nameof(value), "The engine's attack factory cannot be null.");
        }
    }

    protected IBehaviorFactory BehaviorFactory
    {
        get
        {
            return this.behaviorFactory;
        }

        private set
        {
            this.behaviorFactory = value ?? throw new ArgumentNullException(nameof(value), "The engine's behavior factory cannot be null.");
        }
    }

    protected IReader InputReader
    {
        get
        {
            return this.reader;
        }

        private set
        {
            this.reader = value ?? throw new ArgumentNullException(nameof(value), "The engine's input reader cannot be null.");
        }
    }

    protected IWriter OutputWriter
    {
        get
        {
            return this.outputWriter;
        }

        private set
        {
            this.outputWriter = value ?? throw new ArgumentNullException(nameof(value), "The engine's output writer cannot be null.");
        }
    }

    private bool AreEventsMonitored { get; set; } = false;

    private StringBuilder Output { get; } = new StringBuilder();

    public void Run()
    {
        while (true)
        {
            string[] commandArgs = this.reader.ReadLine().Split(' ');

            this.ProcessCommand(commandArgs);
            this.Update();
        }
    }

    public void ProcessCommand(string[] commandArgs)
    {
        string commandName = commandArgs[0];

        switch (commandName)
        {
            case "drop":
                Environment.Exit(0);
                break;
            case "pass":
                break;
            case "create":
                this.CreateBlob(commandArgs);
                break;
            case "attack":
                this.PerformAttack(commandArgs);
                break;
            case "status":
                this.PrintStatus();
                break;
            case "report-events":
                this.AreEventsMonitored = true;
                break;
            default:
                throw new ArgumentException("Unknown command.");
        }
    }

    public void Update()
    {
        foreach (IBlob blob in this.blobs)
        {
            blob.Update();
        }
    }

    private void CreateBlob(string[] commandArgs)
    {
        string name = commandArgs[1];
        int health = int.Parse(commandArgs[2]);
        int damage = int.Parse(commandArgs[3]);
        string behavior = commandArgs[4];
        string attack = commandArgs[5];

        IBlob blob = this.blobFactory.CreateBlob(
            name,
            health,
            damage,
            attack,
            behavior,
            this.attackFactory,
            this.behaviorFactory);

        this.blobs.Add(blob);
        this.blobsByName.Add(name, blob);

        if (this.AreEventsMonitored)
        {
            blob.OnToggleBehavior += this.PrintToggleBehaviorInfo;
            blob.OnBlobDeath += this.PrintBlobDeathInfo;
        }
    }

    private void PerformAttack(string[] commandArgs)
    {
        string attackerName = commandArgs[1];
        if (!this.blobsByName.ContainsKey(attackerName))
        {
            throw new ArgumentException("Attacking blob does not exist.");
        }

        IBlob attacker = this.blobsByName[attackerName];

        if (!attacker.IsAlive)
        {
            throw new InvalidOperationException("A dead blob cannot produce an attack.");
        }

        string defenderName = commandArgs[2];
        if (!this.blobsByName.ContainsKey(defenderName))
        {
            throw new ArgumentException("Defending blob does not exist.");
        }

        IBlob defender = this.blobsByName[defenderName];

        if (!defender.IsAlive)
        {
            throw new InvalidOperationException("A dead blob cannot be attacked.");
        }

        IAttack attack = attacker.ProduceAttack();
        defender.Health -= attack.Damage;
    }

    private void PrintStatus()
    {
        foreach (IBlob blob in this.blobs)
        {
            this.Output.AppendLine(blob.ToString());
        }

        this.outputWriter.WriteLine(this.Output.ToString().Trim());
        this.Output.Clear();
    }

    private void PrintToggleBehaviorInfo(IBlob sender, EventArgs eventArgs)
    {
        this.outputWriter.WriteLine($"Blob {sender.Name} toggled {sender.BehaviorType}");
    }

    private void PrintBlobDeathInfo(IBlob sender, EventArgs eventargs)
    {
        this.outputWriter.WriteLine($"Blob {sender.Name} was killed");
    }
}
