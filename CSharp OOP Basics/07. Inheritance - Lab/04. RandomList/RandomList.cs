using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random rnd;

    public RandomList()
    {
        this.rnd = new Random();
    }

    public string RandomString()
    {
        string result = null;

        if(this.Count > 0)
        {
            int index = this.rnd.Next(0, this.Count - 1);
            result = (string)this[index];
            this.RemoveAt(index);
        }

        return result;  
    }
}