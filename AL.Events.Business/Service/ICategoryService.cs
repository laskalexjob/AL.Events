using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.Business.Service
{
    public interface ICategoryService
    {
        void Create(Category model);
        void DeleteCategoryById(int Id);
        //void SaveCategory(Category model);
        //Category GetCategory(int Id);
        IEnumerable<Category> GetCategoryList();
        //IEnumerable<string> GetCategoryNameList();
    }
}
