using System;
using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = new List<Tire>(tires);
    }

    public Car(Func<string> readCarInfo)
    : this(readCarInfo().Split(" "))
    {
    }

    private Car(string[] carInfo)        
    {
        // Model
        this.model = carInfo[0];

        // Engine
        int engineSpeed = int.Parse(carInfo[1]);
        int enginePower = int.Parse(carInfo[2]);
        this.engine = new Engine(engineSpeed, enginePower);

        // Cargo
        int cargoWeight = int.Parse(carInfo[3]);
        string cargoType = carInfo[4];
        this.cargo = new Cargo(cargoWeight, cargoType);

        // Tires
        double tire1Pressure = double.Parse(carInfo[5]);
        int tire1Age = int.Parse(carInfo[6]);
        double tire2Pressure = double.Parse(carInfo[7]);
        int tire2Age = int.Parse(carInfo[8]);
        double tire3Pressure = double.Parse(carInfo[9]);
        int tire3Age = int.Parse(carInfo[10]);
        double tire4Pressure = double.Parse(carInfo[11]);
        int tire4Age = int.Parse(carInfo[12]); 
       
        this.tires = new List<Tire>
                            {
                                new Tire(tire1Pressure, tire1Age),
                                new Tire(tire2Pressure, tire2Age),
                                new Tire(tire3Pressure, tire3Age),
                                new Tire(tire4Pressure, tire4Age)
                            };
    }

    public string Model
    {
        get { return this.model; }
    }

    public Engine Engine
    {
        get { return this.engine; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
    }

    public List<Tire> Tires
    {
        get { return this.tires; }
    }
}