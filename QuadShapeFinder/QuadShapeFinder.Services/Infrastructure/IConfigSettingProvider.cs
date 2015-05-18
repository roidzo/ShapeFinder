using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadShapeFinder.Services.Infrastructure
{
    public interface IConfigSettingProvider
    {
        bool EnforceValidationQuadilateralIsClosedShape { get; }
        string LogFilePath { get; }
    }
}
