using AL.Events.WCF.Business;
using AL.Events.WCF.Entities;

namespace AL.Events.WCF
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdService _adService;

        public AdvertisingService()
        {
            _adService = new AdService();
        }
        public Ad[] GetRandomAds()
        {
            return _adService.GetRandomAds().ToArray();
        }
    }
}