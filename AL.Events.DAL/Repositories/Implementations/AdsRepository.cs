using AL.Events.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel.Configuration;

namespace AL.Events.DAL.Repositories.Implementations
{
    public class AdsRepository : IAdsRepository
    {
        private readonly AdvertisingService.IAdvertisingService _wcfService;

        public AdsRepository()
        {
            try
            {
                _wcfService = CreateChannel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private AdvertisingService.IAdvertisingService CreateChannel()
        {
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "AL.Events.DAL.dll.config");

            var configuration = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

            var channelFactory = new ConfigurationChannelFactory<AdvertisingService.IAdvertisingService>("BasicHttpBinding_IAdvertisingService", configuration, null);

            var channel = channelFactory.CreateChannel();

            return channel;
        }

        public IReadOnlyCollection<AdCommon> GetRandomAds()
        {
            try
            {
                var list = _wcfService.GetRandomAds();

                var parsedList = new List<AdCommon>();

                foreach (var item in list)
                {
                    parsedList.Add(new AdCommon()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Image = item.Image,
                        Link = item.Link
                    });
                }

                return parsedList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        

        public IReadOnlyCollection<AdCommon> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(AdCommon item)
        {
            throw new NotImplementedException();
        }

        public AdCommon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AdCommon item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
