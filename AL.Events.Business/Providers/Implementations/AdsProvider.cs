using System;
using System.Collections.Generic;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;

namespace AL.Events.Business.Providers.Implementations
{
    public class AdsProvider : IAdsProvider
    {
        private readonly IAdsRepository _adsRepository;

        public AdsProvider(IAdsRepository adsRepository)
        {
            if(adsRepository == null)
            {
                throw new ArgumentNullException();
            }

            _adsRepository = adsRepository;
        }

        public IReadOnlyCollection<AdCommon> GetRandomAds()
        {
            var list = _adsRepository.GetRandomAds();

            return list;
        }



        public IReadOnlyCollection<AdCommon> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public AdCommon GetById(int id)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
