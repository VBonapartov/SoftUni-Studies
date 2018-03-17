using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private IList<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Name cannot be empty");
            }

            this.name = value;
        }
    }

    private decimal Money
    {
        get
        {
            return this.money;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    private IList<Product> Products
    {
        get { return this.products; }
        set { this.products = value; }
    }

    public void BoughtProduct(Product product)
    {
        if (product.Cost > this.Money)
        {
            throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
        }
        else
        {
            this.Products.Add(product);
            this.Money -= product.Cost;
        }
    }

    public override string ToString()
    {
        string productsBought = (this.Products.Count == 0) 
                                ? "Nothing bought" 
                                : string.Join(", ", this.Products.Select(p => p.Name));

        return $"{this.Name} - {productsBought}";
    }
}