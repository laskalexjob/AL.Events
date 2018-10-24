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
                 new Ad{ Id = 0, Name = "CUCUMBER.COM", Image = ParseImage("~/Content/Images/Cucumber.jpg"), Link = "http://www.buyfreshproduceinc.com/cucumbers-wholesale/", Description = "Fresh cucumbers"},
                 new Ad{ Id = 2, Name = "BELMARKET.BY", Image = ParseImage("~/Content/Images/BelMarket.jpg"), Link = "http://www.bel-market.by/", Description = "Distribution stores"},
                 new Ad{ Id = 4, Name = "GUITAR.BY", Image = ParseImage("~/Content/Images/Guitar.jpg"), Link = "https://www.guitarcenter.com/", Description = "Guitar store"},
                 new Ad{ Id = 5, Name = "BELARUSBANK.BY", Image = ParseImage("~/Content/Images/belarusBank.jpg"), Link = "https://belarusbank.by/", Description = "Biggest bank in belarus"}
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
