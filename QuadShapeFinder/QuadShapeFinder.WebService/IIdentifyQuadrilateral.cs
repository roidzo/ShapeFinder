using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuadShapeFinder.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IIdentifyQuadrilateral
    {
        [OperationContract]
        string GetQuadrilateralType(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA);
    }

}
