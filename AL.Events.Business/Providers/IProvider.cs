using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Events.Business.Providers
{
    public interface IProvider<T>
    {
        T GetById(int id);
        IReadOnlyCollection<T> GetAll();
    }
}
