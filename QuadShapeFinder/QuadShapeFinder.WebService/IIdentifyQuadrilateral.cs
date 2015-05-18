using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuadShapeFinder.WebService
{
    [ServiceContract]
    public interface IIdentifyQuadrilateral
    {
        [OperationContract]
        string GetQuadrilateralType(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA);
    }

}
