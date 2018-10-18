namespace AL.Events.Business.Authentication
{
    public interface ILoginService
    {
        bool Login(string login, string password);
        void Logout();
    }
}
