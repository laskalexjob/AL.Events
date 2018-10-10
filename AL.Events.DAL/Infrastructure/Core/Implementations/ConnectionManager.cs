using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace AL.Events.DAL.Infrastructure.Core.Implementations
{
    public sealed class ConnectionManager : IConnectionManager
    {
        public string GetConnectionString(string connectionName)
        {
            var config = GetConfigFile(DbConstant.configFileName);

            var connectionString = config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString;

            return connectionString;
        }

        private Configuration GetConfigFile(string configName)
        {
            var currentDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            var fullPath = string.Format($"{currentDirectory}\\{configName}");

            var fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = fullPath
            };

            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            return configuration;
        }
    }
}
