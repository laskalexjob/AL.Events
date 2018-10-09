using System.Collections.Generic;

namespace AL.Events.DAL.Repositories
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
