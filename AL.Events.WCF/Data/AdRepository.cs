using AL.Events.WCF.Entities;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace AL.Events.WCF.Data
{
    internal class AdRepository
    {
        private readonly List<Ad> _adList;

        public AdRepository()
        {
            _adList = new List<Ad>
            {
                 new Ad{ Id = 0, Name = "1XBET.COM", Image = ParseImage("~/Content/Images/XBET.jpg"), Link = "https://1xbet.com/casino/", Description = "Ставки на спорт онлайн"},
                 new Ad{ Id = 1, Name = "TUT.BY", Image = ParseImage("~/Content/Images/TUTBY.jpg"), Link = "https://www.tut.by/", Description = "Белорусский новостной партал"},
                 new Ad{ Id = 2, Name = "BELMARKET.BY", Image = ParseImage("~/Content/Images/BelMarket.jpg"), Link = "http://www.bel-market.by/", Description = "Сеть универсальных магазинов"},
                 new Ad{ Id = 3, Name = "KUFAR.BY", Image = ParseImage("~/Content/Images/kufar.jpg"), Link = "https://www.kufar.by/", Description = "Крупнейшая площадка объявлений"},
                 new Ad{ Id = 4, Name = "MTS.BY", Image = ParseImage("~/Content/Images/Mts.jpg"), Link = "https://www.mts.by/", Description = "Крупнейший мобильный оператор"},
                 new Ad{ Id = 5, Name = "BELARUSBANK.BY", Image = ParseImage("~/Content/Images/belarusBank.jpg"), Link = "https://belarusbank.by/", Description = "Крупнейший банк Беларуси"}
            };
        }

        public List<Ad> GetAll()
        {
            return _adList;
        }

        #region Helpers

        private byte[] ParseImage(string path)
        {
            string physicalPath = HttpContext.Current.Server.MapPath(path);

            return File.ReadAllBytes(physicalPath);
        }

        #endregion

    }
}
