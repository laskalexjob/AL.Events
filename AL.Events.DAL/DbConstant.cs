using System.Configuration;

namespace AL.Events.DAL
{
    public static class DbConstant
    {
        public const string FolderName = "defaultFolderForProject";
        public const string conStrName = "DefaultConnection";
        public static string connectionString = ConfigurationManager.ConnectionStrings[conStrName].ConnectionString;
        public const string configFileName = "AL.Events.DAL.Connections.config";


        public static class Command
        {
            public const string SaveCategory = "SaveCategory";
            public const string DeleteCategoryByCategoryId = "DeleteCategoryByCategoryId";
            public const string GetCategoriesList = "GetCategoriesList";
            public const string GetCategoryByCategoryId = "GetCategoryByCategoryId";

        }
    }
}
