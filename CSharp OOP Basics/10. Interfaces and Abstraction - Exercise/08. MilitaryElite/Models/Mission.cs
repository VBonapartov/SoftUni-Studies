using System;
using System.Linq;

public class Mission : IMission
{
    private readonly string[] possibleStates = new string[] { "inProgress", "Finished" };

    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; private set; }

    public string State
    {
        get
        {
            return this.state;
        }

        private set
        {
            if (!this.possibleStates.Contains(value))
            {
                throw new ArgumentException("Invalid mission state");
            }

            this.state = value;
        }
    }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
