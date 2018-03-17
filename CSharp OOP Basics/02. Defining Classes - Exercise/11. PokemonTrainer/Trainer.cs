using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name, Pokemon pokemon)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons = new List<Pokemon>();
        this.pokemons.Add(pokemon);
    }

    public string Name
    {
        get { return this.name; }
    }

    public int NumberOfBadges
    {
        get { return this.numberOfBadges; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
    }

    public void CheckPokemonsForElement(string element)
    {
        if (pokemons.Where(p => p.Element.Equals(element)).Count() > 0)
        {
            numberOfBadges++;
        }
        else
        {
            for (int i = pokemons.Count - 1; i >= 0; i--)
            {
                if (!pokemons[i].LoseHealth())
                {
                    pokemons.RemoveAt(i);
                }
            }
        }
    }
}