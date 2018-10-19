using AL.Events.Common.Entities;

namespace AL.Events.Business.Providers
{
    public interface IUserProvider : IProvider<User>
    {
        User GetByLogin(string login);
    }
}
