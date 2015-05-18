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
        private const string LogFilePathSetting = "LogFilePath";
        private readonly string _logFilePath;

        private const string EnforceValidationQuadilateralIsClosedShapeSetting = "EnforceValidationQuadilateralIsClosedShape";
        private readonly string _enforceValidationQuadilateralIsClosedShape;
        

        public ConfigSettingProvider()
        {
            _logFilePath = ConfigurationManager.AppSettings[LogFilePathSetting];
            _enforceValidationQuadilateralIsClosedShape = ConfigurationManager.AppSettings[EnforceValidationQuadilateralIsClosedShapeSetting];
        }

        public virtual bool EnforceValidationQuadilateralIsClosedShape
        {
            get { return _enforceValidationQuadilateralIsClosedShape == "true" ? true : false; }
        }

        public virtual string LogFilePath
        {
            get { return _logFilePath; }
        }

    }
}
