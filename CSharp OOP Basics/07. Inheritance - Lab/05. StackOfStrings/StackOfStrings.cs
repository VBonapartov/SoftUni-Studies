using System.Collections.Generic;
using System.Linq;

public class StackOfStrings : List<string>
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string result = string.Empty;

        if (!IsEmpty())
        {
            int lastIndex = this.data.Count - 1;
            result = this.data[lastIndex];
            this.data.RemoveAt(lastIndex);
        }

        return result;
    }

    public string Peek()
    {
        string result = string.Empty;

        if(!IsEmpty())
        {
            result = this.data.Last();
        }

        return result;
    }

    public bool IsEmpty()
    {
        return !this.data.Any();
    }
}