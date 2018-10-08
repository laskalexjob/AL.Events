using System.Configuration;

namespace AL.Events.DAL
{
    public class DbConstant
    {
        public const string FolderName = "defaultFolderForProject";
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static class Command
        {
            public const string SaveCategory = "SaveCategory";
            public const string DeleteCategoryByCategoryId = "DeleteCategoryByCategoryId";
            public const string GetCategoriesList = "GetCategoriesList";
            public const string GetCategoryByCategoryId = "GetCategoryByCategoryId";

        }
    }
}
