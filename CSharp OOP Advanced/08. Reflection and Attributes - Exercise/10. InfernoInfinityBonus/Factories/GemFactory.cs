using System;

public class GemFactory
{
    public Gem Create(string gemType, string clarity)
    {
        if (!Enum.TryParse(clarity, out GemClarity levelOfClarity))
        {
            return null;
        }

        switch (gemType)
        {
            case "Ruby":
                return new Ruby(levelOfClarity);

            case "Emerald":
                return new Emerald(levelOfClarity);

            case "Amethyst":
                return new Amethyst(levelOfClarity);

            default:
                throw new ArgumentException("Invalid gem type!");
        }
    }
}