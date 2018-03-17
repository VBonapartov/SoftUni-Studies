using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;
    private Car car;

    public Person(string name)
    {
        this.name = name;
        this.company = null;
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.children = new List<Child>();
        this.car = null;
    }

    public Person(string name, Company company) : this(name)
    {
        this.company = company;
    }

    public Person(string name, Pokemon pokemon) : this(name)
    {
        this.pokemons = new List<Pokemon>() { pokemon };
    }

    public Person(string name, Parent parent) : this(name)
    {
        this.parents = new List<Parent>() { parent };
    }

    public Person(string name, Child child) : this(name)
    {
        this.children = new List<Child>() { child };
    }

    public Person(string name, Car car) : this(name)
    {
        this.car = car;
    }

    public string Name
    {
        get { return this.name; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
    }

    public List<Child> Children
    {
        get { return this.children; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.Name);

        sb.AppendLine("Company:");
        if (this.Company != null)
        {
            sb.AppendLine(this.Company.ToString());
        }

        sb.AppendLine("Car:");
        if (this.Car != null)
        {
            sb.AppendLine(this.Car.ToString());
        }

        sb.AppendLine("Pokemon:");
        if (this.Pokemons.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Pokemons.Select(p => p.ToString())));
        }

        sb.AppendLine("Parents:");
        if (this.Parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Parents.Select(p => p.ToString())));
        }

        sb.AppendLine("Children:");
        if (this.Children.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.Children.Select(c => c.ToString())));
        }

        return sb.ToString();
    }
}