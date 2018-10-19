using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.Business.Providers
{
    public interface IEventProvider : IProvider<Event>
    {
        IReadOnlyCollection<Event> GetByUserId(int id);
    }
}
