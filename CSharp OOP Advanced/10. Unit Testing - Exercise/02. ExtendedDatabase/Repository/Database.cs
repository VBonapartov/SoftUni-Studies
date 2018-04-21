using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Database : IEnumerable<IPerson>
{
    private const int Capacity = 16;

    private IPerson[] data;
    private int count;

    public Database()
    {
        this.data = new IPerson[Capacity];
    }

    public Database(params IPerson[] persons)
        : this()
    {
        if (persons != null)
        {
            foreach (IPerson person in persons)
            {
                this.Add(person);
            }
        }
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public void Add(IPerson person)
    {
        if (this.count == Capacity)
        {
            throw new InvalidOperationException("Database is full!");
        }

        for (int i = 0; i < this.count; i++)
        {
            if (this.data[i] != null)
            {
                if (this.data[i].Id == person.Id || this.data[i].Username.Equals(person.Username))
                {
                    throw new InvalidOperationException("Person already exists!");
                }
            }
        }

        this.data[this.count] = person;
        this.count++;
    }

    public IPerson Remove()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Database is empty!");
        }

        IPerson person = this.data[this.count - 1];
        this.data[this.count - 1] = default(IPerson);
        this.count--;

        return person;
    }

    public IPerson[] Fetch()
    {
        IPerson[] result = new IPerson[this.count];
        Array.Copy(this.data, result, this.count);

        return result;
    }

    public IPerson FindByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException(string.Empty, "Username cannot be empty!");
        }

        if (!this.PersonExists(username))
        {
            throw new InvalidOperationException("Person does not exists in the database!");
        }

        return this.data.First(p => p.Username.Equals(username));
    }

    public IPerson FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(string.Empty, "Id cannot be a negative number!");
        }

        if (!this.PersonExists(id))
        {
            throw new InvalidOperationException("Person does not exists in the database!");
        }

        return this.data.First(p => p.Id == id);
    }

    public IEnumerator<IPerson> GetEnumerator()
    {
        for (int i = 0; i < this.count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private bool PersonExists(IPerson person)
    {
        if (this.Count == 0)
        {
            return false;
        }

        return this.data.Where(x => x != null).Any(p => p.Id == person.Id || p.Username.Equals(person.Username));
    }

    private bool PersonExists(string username)
    {
        if (this.Count == 0)
        {
            return false;
        }

        return this.data.Where(x => x != null).Any(p => p.Username.Equals(username));
    }

    private bool PersonExists(long id)
    {
        if (this.Count == 0)
        {
            return false;
        }

        return this.data.Where(x => x != null).Any(p => p.Id == id);
    }
}
