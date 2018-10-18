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
            public const string CreateEvent = "CreateEvent";
            public const string CreateCategory = "CreateCategory";
            public const string CreateOrganizer = "CreateOrganizer";
            public const string CreateUser = "CreateUser";

            public const string GetUserByLogin = "GetUserByLogin";

            public const string GetCategoryByCategoryId = "GetCategoryByCategoryId";
            public const string GetOrganizerByOrganizerId = "GetOrganizerByOrganizerId";
            public const string GetEventByEventId = "GetEventByEventId";
            public const string GetUserById = "GetUserById";

            public const string GetCategoriesList = "GetCategoriesList";
            public const string GetEventsList = "GetEventsList";
            public const string GetOrganizersList = "GetOrganizersList";
            public const string GetUsersList = "GetUsersList";
            public const string GetRolesList = "GetRolesList";

            public const string UpdateUser = "UpdateUser";
            public const string UpdateCategory = "UpdateCategory";
            public const string UpdateOrganizer = "UpdateOrganizer";
            public const string UpdateEvent = "UpdateEvent";

            public const string DeleteUserById = "DeleteUserById";
            public const string DeleteOrganizerByOrganizerId = "DeleteOrganizerByOrganizerId";
            public const string DeleteEventByEventId = "DeleteEventByEventId";
            public const string DeleteCategoryByCategoryId = "DeleteCategoryByCategoryId";
        }

        public static class Image
        {
            public const string DefaultImagePath = "picture_default.jpg";
        }
    }
}
