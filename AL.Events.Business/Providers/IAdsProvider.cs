using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.Business.Providers
{
    public interface IAdsProvider : IProvider<AdCommon>
    {
        IReadOnlyCollection<AdCommon> GetRandomAds();
    }
}
