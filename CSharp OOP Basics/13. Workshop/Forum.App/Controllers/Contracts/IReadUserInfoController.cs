namespace Forum.App.Controllers.Contracts
{
    public interface IReadUserInfoController
    {
        string Username { get; }

        void ReadUsername();

        void ReadPassword();
    }
}
