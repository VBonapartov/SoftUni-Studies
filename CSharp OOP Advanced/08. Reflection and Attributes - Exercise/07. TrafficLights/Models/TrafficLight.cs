using System;

public class TrafficLight
{
    private LightColor colorState;

    public TrafficLight(string light)
    {
        this.SetTrafficLight(light);
    }

    public void ChangeLight()
    {
        this.colorState += 1;

        if ((int)this.colorState > Enum.GetNames(typeof(LightColor)).Length - 1)
        {
            this.colorState = 0;
        }
    }

    public override string ToString()
    {
        return $"{this.colorState}";
    }

    private void SetTrafficLight(string lightAsString)
    {
        if (!Enum.TryParse(lightAsString, out LightColor colorState))
        {
            throw new ArgumentException("Invalid traffic light signal!");
        }

        this.colorState = colorState;
    }
}