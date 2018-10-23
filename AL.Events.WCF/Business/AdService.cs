using AL.Events.WCF.Data;
using AL.Events.WCF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AL.Events.WCF.Business
{
    public class AdService
    {
        private readonly AdRepository _adRepository;

        public AdService()
        {
            _adRepository = new AdRepository();
        }

        public List<Ad> GetRandomAds()
        {
            var adList = _adRepository.GetAll();

            var randomNumberArray = GetRandomNumber(2, adList.Count);

            int i = -1;

            return adList.FindAll(x => { i++; return randomNumberArray.Contains(i) ? true : false; }).Select(x => x).ToList();
        }

        #region Helpers

        private int[] GetRandomNumber(int size, int maxValue)
        {
            if (size > maxValue)
            {
                throw new Exception();
            }

            Random random = new Random();

            var array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(maxValue);
            }

            return array;
        }

        #endregion
    }
}