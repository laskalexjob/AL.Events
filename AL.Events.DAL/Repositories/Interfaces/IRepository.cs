using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Events.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyCollection<T> GetAll();
        void Create(T item);
        T GetById(int id);
        void Update(T item);
        void Delete(int id);
    }
}
