using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemManager
{
    private IList<Hardware> hardware;
    private IList<Hardware> dumpHardware;

    public SystemManager()
    {
        this.hardware = new List<Hardware>();
        this.dumpHardware = new List<Hardware>();
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        Hardware newHardware = new PowerHardware(name, capacity, memory);
        this.hardware.Add(newHardware);
    }

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        Hardware newHardware = new HeavyHardware(name, capacity, memory);
        this.hardware.Add(newHardware);
    }

    public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        Hardware currentHardware = this.hardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }

        Software newSoftwareComponent = new ExpressSoftware(name, capacity, memory);
        currentHardware.RegisterSoftwareComponent(newSoftwareComponent);
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        Hardware currentHardware = this.hardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }

        Software newSoftwareComponent = new LightSoftware(name, capacity, memory);
        currentHardware.RegisterSoftwareComponent(newSoftwareComponent);
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        Hardware currentHardware = this.hardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }

        currentHardware.ReleaseSoftwareComponent(softwareComponentName);
    }

    public void Dump(string hardwareComponentName)
    {
        Hardware currentHardware = this.hardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }

        this.dumpHardware.Add(currentHardware);
        this.hardware.Remove(currentHardware);
    }

    public void Restore(string hardwareComponentName)
    {
        Hardware currentHardware = this.dumpHardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }
                
        this.hardware.Add(currentHardware);
        this.dumpHardware.Remove(currentHardware);
    }

    public void Destroy(string hardwareComponentName)
    {
        Hardware currentHardware = this.dumpHardware.FirstOrDefault(h => h.Name.Equals(hardwareComponentName));

        if (currentHardware == null)
        {
            return;
        }

        this.dumpHardware.Remove(currentHardware);
    }

    public string Analyze()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine("System Analysis")
            .AppendLine($"Hardware Components: {this.hardware.Count}")
            .AppendLine($"Software Components: {this.hardware.Sum(h => h.GetNumberOfSoftware())}")
            .AppendLine($"Total Operational Memory: {this.hardware.Sum(h => h.TotalOperationalMemoryInUse)} / {this.hardware.Sum(h => h.MaxMemory)}")
            .AppendLine($"Total Capacity Taken: {this.hardware.Sum(h => h.TotalCapacityTaken)} / {this.hardware.Sum(h => h.MaxCapacity)}");

        return result.ToString().Trim();
    }

    public string DumpAnalyze()
    {
        StringBuilder result = new StringBuilder();

        int countOfPowerHardwareComponents = this.dumpHardware.Count(h => h is PowerHardware);
        int countOfHeavyHardwareComponents = this.dumpHardware.Count(h => h is HeavyHardware);
        int countOfExpressSoftwareComponents = this.dumpHardware.Sum(h => h.GetNumberOfExpressSoftwareComponents());
        int countOfLightSoftwareComponents = this.dumpHardware.Sum(h => h.GetNumberOfLightSoftwareComponents());
        int totalDumpedMemory = this.dumpHardware.Sum(h => h.TotalOperationalMemoryInUse);
        int totalDumpedCapacity = this.dumpHardware.Sum(h => h.TotalCapacityTaken);

        result
            .AppendLine("Dump Analysis ")
            .AppendLine($"Power Hardware Components: {countOfPowerHardwareComponents}")
            .AppendLine($"Heavy Hardware Components: {countOfHeavyHardwareComponents}")
            .AppendLine($"Express Software Components: {countOfExpressSoftwareComponents}")
            .AppendLine($"Light Software Components: {countOfLightSoftwareComponents}")
            .AppendLine($"Total Dumped Memory: {totalDumpedMemory}")
            .AppendLine($"Total Dumped Capacity: {totalDumpedCapacity}");

        return result.ToString().Trim();
    }

    public string SystemSplit()
    {
        StringBuilder result = new StringBuilder();

        List<Hardware> sortedHardware = this.hardware.OrderByDescending(h => h.GetType().Name).ToList();

        foreach (Hardware hw in sortedHardware)
        {
            result
                .AppendLine($"Hardware Component - {hw.Name}")
                .AppendLine($"Express Software Components - {hw.GetNumberOfExpressSoftwareComponents()}")
                .AppendLine($"Light Software Components - {hw.GetNumberOfLightSoftwareComponents()}")
                .AppendLine($"Memory Usage: {hw.TotalOperationalMemoryInUse} / {hw.MaxMemory}")
                .AppendLine($"Capacity Usage: {hw.TotalCapacityTaken} / {hw.MaxCapacity}")
                .AppendLine($"Type: {hw.GetType().Name.Substring(0, 5)}")
                .AppendLine($"Software Components: {hw.GetSoftwareComponents()}");
        }

        return result.ToString().Trim();
    }
}
