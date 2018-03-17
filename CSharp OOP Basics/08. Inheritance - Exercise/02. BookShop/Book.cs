using System;
using System.Text;

public class Book
{
    private string author;
    private string title;    
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;        
        this.Price = price;
    }

    protected virtual decimal Price
    {
        get
        {
            return this.price;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    private string Author
    {
        get
        {
            return this.author;
        }

        set
        {
            string[] tokens = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length > 1)
            {
                if (char.IsDigit(tokens[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            this.author = value;
        }
    }

    private string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f2}")
            .AppendLine();

        return sb.ToString();
    }
}