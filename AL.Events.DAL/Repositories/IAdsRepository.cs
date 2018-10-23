using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.DAL.Repositories
{
    public interface IAdsRepository : IRepository<AdCommon>
    {
        IReadOnlyCollection<AdCommon> GetRandomAds();
    }
}
