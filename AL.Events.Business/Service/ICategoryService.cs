namespace AL.Events.Business.Service
{
    public interface IService<T>
    {
        void Create(T model);
        void DeleteCategoryById(int Id);
        void SaveCategory(T model);
    }
}
