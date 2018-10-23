using AL.Events.WCF.Entities;
using System.ServiceModel;

namespace AL.Events.WCF
{
    [ServiceContract]
    public interface IAdvertisingService
    {
        [OperationContract]
        Ad[] GetRandomAds();
    }
}
