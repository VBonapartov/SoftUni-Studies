public interface IMonument
{
    string Name { get; }

    long Affinity { get; }

    string GetMonumentType();

    string ToString();
}
