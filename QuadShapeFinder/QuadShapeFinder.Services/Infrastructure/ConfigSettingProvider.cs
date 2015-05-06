using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuadShapeFinder.Services.Infrastructure
{
    public class ConfigSettingProvider : IConfigSettingProvider
    {
        private const string DefaultCultureSetting = "DefaultCulture";
        private readonly string _defaultCulture;

        private const string LogFilePathSetting = "LogFilePath";
        private readonly string _logFilePath;

        public ConfigSettingProvider()
        {
            _defaultCulture = ConfigurationManager.AppSettings[DefaultCultureSetting];
            _logFilePath = ConfigurationManager.AppSettings[LogFilePathSetting];
        }

        public string DefaultCulture
        {
            get { return _defaultCulture; }
        }

        public string LogFilePath
        {
            get { return _logFilePath; }
        }

    }
}
