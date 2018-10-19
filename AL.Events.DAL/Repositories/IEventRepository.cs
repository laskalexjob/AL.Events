using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.DAL.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IReadOnlyCollection<Event> GetByUserId(int id);
    }
}
