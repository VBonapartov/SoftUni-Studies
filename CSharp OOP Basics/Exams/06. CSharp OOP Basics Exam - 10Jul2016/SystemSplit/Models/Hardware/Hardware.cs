using System.Collections.Generic;
using System.Linq;

public abstract class Hardware
{
    private string name;
    private int maxCapacity;
    private int maxMemory;
    private IList<Software> components;

    private int totalOperationalMemoryInUse;
    private int totalCapacityTaken;

    protected Hardware(string name, int maxCapacity, int maxMemory)
    {
        this.Name = name;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.Components = new List<Software>();

        this.TotalOperationalMemoryInUse = 0;
        this.TotalCapacityTaken = 0;
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

    public int MaxCapacity
    {
        get => this.maxCapacity;
        protected set { this.maxCapacity = value; }
    }

    public int MaxMemory
    {
        get => this.maxMemory;
        protected set { this.maxMemory = value; }
    }

    public int TotalCapacityTaken
    {
        get => this.totalCapacityTaken;
        private set { this.totalCapacityTaken = value; }
    }

    public int TotalOperationalMemoryInUse
    {
        get => this.totalOperationalMemoryInUse;
        private set { this.totalOperationalMemoryInUse = value; }
    }

    private IList<Software> Components
    {
        get => this.components;
        set { this.components = value; }
    }

    public void RegisterSoftwareComponent(Software component)
    {
        if (this.MaxCapacity - this.totalCapacityTaken >= component.CapacityConsumption && 
            this.MaxMemory - this.totalOperationalMemoryInUse >= component.MemoryConsumption)
        {
            this.TotalCapacityTaken += component.CapacityConsumption;
            this.TotalOperationalMemoryInUse += component.MemoryConsumption;

            this.Components.Add(component);
        }
    }

    public void ReleaseSoftwareComponent(string softwareComponentName)
    {
        Software component = this.components.FirstOrDefault(c => c.Name.Equals(softwareComponentName));

        if (component == null)
        {
            return;
        }

        this.TotalCapacityTaken -= component.CapacityConsumption;
        this.TotalOperationalMemoryInUse -= component.MemoryConsumption;

        this.Components.Remove(component);
    }

    public string GetSoftwareComponents()
    {
        string softwareComponents = this.GetNumberOfSoftware() > 0
                                    ? string.Join(", ", this.Components.Select(c => c.Name))
                                    : "None";

        return softwareComponents;
    }

    public int GetNumberOfSoftware()
    {
        return this.Components.Count;
    }

    public int GetNumberOfExpressSoftwareComponents()
    {
        return this.Components.Count(c => c is ExpressSoftware);
    }

    public int GetNumberOfLightSoftwareComponents()
    {
        return this.Components.Count(c => c is LightSoftware);
    }
}
