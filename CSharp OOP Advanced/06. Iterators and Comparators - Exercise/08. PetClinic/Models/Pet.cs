public class Pet
{
    public Pet(string petName, int petAge, string petKind)
    {
        this.PetName = petName;
        this.PetAge = petAge;
        this.PetKind = petKind;
    }

    public string PetName { get; private set; }

    public int PetAge { get; private set; }

    public string PetKind { get; private set; }

    public override string ToString()
    {
        return $"{this.PetName} {this.PetAge} {this.PetKind}";
    }
}