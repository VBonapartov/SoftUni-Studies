public interface IAnimal : IStatus, ICenter
{
    string Name { get; }

    int Age { get; }
}
