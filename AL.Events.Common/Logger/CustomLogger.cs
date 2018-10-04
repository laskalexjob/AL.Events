using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace AL.Events.Common.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private const string _loggerName = "CustomLogger";
        private readonly ILog _log;

        public CustomLogger()
        {
            var config = GetConfigFile("Log.config");

            if(config.Exists)
            {
                XmlConfigurator.Configure(config);
                _log = LogManager.GetLogger(_loggerName);
            }
        }

        private FileInfo GetConfigFile(string configName)
        {
            var currentDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            var fullPath = string.Format($"{currentDirectory}\\{configName}");

            return new FileInfo(fullPath);
        }

        public void WriteToLogInfo(string info)
        {
            _log.Info(info);
        }
    }
}
