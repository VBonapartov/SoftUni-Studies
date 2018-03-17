using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    //private Dictionary<int, Car> cars;
    //private Dictionary<int, Race> races;
    //private Garage garage;

    //public CarManager()
    //{
    //    cars = new Dictionary<int, Car>();
    //    races = new Dictionary<int, Race>();
    //    garage = new Garage();
    //}

    //public void Register(List<string> commands)
    //{
    //    int id = int.Parse(commands[0]);
    //    string type = commands[1];
    //    string brand = commands[2];
    //    string model = commands[3];
    //    int yearOfProduction = int.Parse(commands[4]);
    //    int horsepower = int.Parse(commands[5]);
    //    int acceleration = int.Parse(commands[6]);
    //    int suspension = int.Parse(commands[7]);
    //    int durability = int.Parse(commands[8]);

    //    Car car = null;

    //    switch(type)
    //    {
    //        case "Performance":
    //            car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    //            break;

    //        case "Show":
    //            car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    //            break;
    //    }

    //    if (!this.cars.ContainsKey(id))
    //    {
    //        this.cars.Add(id, car);
    //    }        
    //}

    //public string Check(List<string> commands)
    //{
    //    int id = int.Parse(commands[0]);

    //    if (this.cars.ContainsKey(id))
    //    {
    //        return this.cars[id].ToString();
    //    }

    //    return null;
    //}

    //public void Open(List<string> commands)
    //{
    //    int id = int.Parse(commands[0]);
    //    string type = commands[1];
    //    int length = int.Parse(commands[2]);
    //    string route = commands[3];
    //    int prizePool = int.Parse(commands[4]);

    //    Race race = null;

    //    switch (type)
    //    {
    //        case "Casual":
    //            race = new CasualRace(length, route, prizePool);
    //            break;

    //        case "Drag":
    //            race = new DragRace(length, route, prizePool);
    //            break;

    //        case "Drift":
    //            race = new DriftRace(length, route, prizePool);
    //            break;

    //        case "TimeLimit":
    //            int goldTime = int.Parse(commands[5]);
    //            race = new TimeLimitRace(length, route, prizePool, goldTime);
    //            break;

    //        case "Circuit":
    //            int laps = int.Parse(commands[5]);
    //            race = new CircuitRace(length, route, prizePool, laps);
    //            break;
    //    }

    //    if (!this.races.ContainsKey(id))
    //    {
    //        this.races.Add(id, race);
    //    }
    //}

    //public void Participate(List<string> commands)
    //{
    //    int carId = int.Parse(commands[0]);
    //    int raceId = int.Parse(commands[1]);

    //    if(!this.cars.ContainsKey(carId) || !this.races.ContainsKey(raceId))
    //    {
    //        return;
    //    }

    //    Race race = this.races[raceId];
    //    Car car = this.cars[carId];

    //    //if (!this.garage.IsCarParked(car))
    //    if (!garage.ParkedCars.Contains(car))
    //    {   
    //        if ((race.GetType().Name == "TimeLimitRace" && race.Participants.Count == 0) || race.GetType().Name != "TimeLimitRace")
    //        {
    //            //race.AddParticipants(car);
    //            race.Participants.Add(car);
    //        }            
    //    }            
    //}

    //public string Start(List<string> commands)
    //{
    //    int raceId = int.Parse(commands[0]);

    //    if (!this.races.ContainsKey(raceId))
    //    {
    //        return null;
    //    }

    //    Race race = this.races[raceId];

    //    if (race.Participants.Count > 0)
    //    {
    //        this.races.Remove(raceId);
    //    }

    //    return race.ToString();
    //}

    //public void Park(List<string> commands)
    //{
    //    int carId = int.Parse(commands[0]);

    //    if (!this.cars.ContainsKey(carId))
    //    {
    //        return;
    //    }

    //    Car car = this.cars[carId];

    //    //if (!this.races.Any(r => r.Value.IsCarIsInRace(car)))
    //    if (!races.Values.Any(r => r.Participants.Contains(car)))
    //    {
    //        //if (!this.garage.IsCarParked(car))
    //        if (!garage.ParkedCars.Contains(car))
    //        {
    //            //this.garage.Park(car);
    //            garage.ParkedCars.Add(car);
    //        }
    //    }
    //}

    //public void Unpark(List<string> commands)
    //{
    //    int carId = int.Parse(commands[0]);

    //    if (!this.cars.ContainsKey(carId))
    //    {
    //        return;
    //    }

    //    Car car = this.cars[carId];

    //    //if (this.garage.IsCarParked(car))
    //    if (garage.ParkedCars.Contains(car))
    //    {
    //        //this.garage.Unpark(car);
    //        garage.ParkedCars.Remove(car);
    //    }
    //}

    //public void Tune(List<string> commands)
    //{
    //    int tuneIndex = int.Parse(commands[0]);
    //    string addOn = commands[1];

    //    //this.garage.TuneCars(tuneIndex, addOn);

    //    foreach (var car in garage.ParkedCars)
    //    {
    //        car.Tune(tuneIndex, addOn);
    //    }
    //}


    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        cars = new Dictionary<int, Car>();
        races = new Dictionary<int, Race>();
        garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = null;

        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;

            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
        }

        if (!this.cars.ContainsKey(id))
        {
            this.cars.Add(id, car);
        }
    }

    public string Check(int id)
    {
        Car car = cars[id];

        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (!this.races.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    this.races[id] = new CasualRace(length, route, prizePool);
                    break;

                case "Drag":
                    this.races[id] = new DragRace(length, route, prizePool);
                    break;

                case "Drift":
                    this.races[id] = new DriftRace(length, route, prizePool);
                    break;
            }
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int lapGold)
    {
        if (!this.races.ContainsKey(id))
        {
            switch (type)
            {
                case "TimeLimit":
                    this.races[id] = new TimeLimitRace(length, route, prizePool, lapGold);
                    break;

                case "Circuit":
                    this.races[id] = new CircuitRace(length, route, prizePool, lapGold);
                    break;
            }
        }
    }

    public void Participate(int carId, int raceId)
    {
        Car car = cars[carId];
        Race race = races[raceId];

        if (!this.garage.IsCarParked(car))
        {
            if ((race.GetType().Name == "TimeLimitRace" && !race.AreThereAnyParticipants()) || race.GetType().Name != "TimeLimitRace")
            {
                race.AddParticipants(car);
            }
        }
    }

    public string Start(int raceId)
    {
        Race race = races[raceId];

        if (race.AreThereAnyParticipants())
        {
            this.races.Remove(raceId);
        }

        return race.ToString();
    }

    public void Park(int carId)
    {
        Car car = cars[carId];

        if (!this.races.Values.Any(r => r.IsCarIsInRace(car)))
        {
            if (!garage.IsCarParked(car))
            {
                garage.Park(car);
            }
        }
    }

    public void Unpark(int carId)
    {
        Car car = cars[carId];

        if (garage.IsCarParked(car))
        {
            garage.Unpark(car);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneCars(tuneIndex, addOn);
    }
}
