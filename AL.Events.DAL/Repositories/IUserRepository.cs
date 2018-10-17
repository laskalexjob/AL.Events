using AL.Events.Common.Entities;

namespace AL.Events.DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);
    }
}
