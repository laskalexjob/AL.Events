namespace AL.Events.Business.Service
{
    public interface IService<T>
    {
        void Create(T model);
        void DeleteById(int Id);
        void Update(T model);
    }
}
