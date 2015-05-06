using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using QuadShapeFinder.WebService;
using QuadShapeFinder.Services.Helpers;
using QuadShapeFinder.Services;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using QuadShapeFinder.Services.BusinessLogic;

namespace QuadShapeFinder.Tests
{
    [TestClass]
    public class UnitTestEndToEnd
    {
        private Mock<ILogger> _logger;
        private IIdentifyQuadrilateral _webService;
        private IQuadrilateralIdentifier _quadrilateralIdentifier;

        [TestInitialize]
        public void StartUp()
        {
            _logger = new Mock<ILogger>();
            _quadrilateralIdentifier = new QuadrilateralIdentifier(_logger.Object);
            _webService = new IdentifyQuadrilateral(_logger.Object, new QuadrilateralShapeService(_logger.Object, _quadrilateralIdentifier));
        }


        [TestMethod]
        public void TestEndToEndParallelogram()
        {
            //Arrange

            //Act
            var result = _webService.GetQuadrilateralType(2, 3, 2, 3, 45, 135, 45, 135);

            //Assert
            Assert.AreEqual(result, EnumHelper.GetEnumDescription(QuadTypeEnum.Parallelogram));
        }

        [TestMethod]
        public void TestEndToEndSquare()
        {
            //Arrange

            //Act
            var result = _webService.GetQuadrilateralType(20.4, 20.4, 20.4, 20.4, 90, 90, 90, 90);

            //Assert
            Assert.AreEqual(result, EnumHelper.GetEnumDescription(QuadTypeEnum.Square));
        }

        [TestMethod]
        public void TestEndToEndTrapezoid()
        {
            //Arrange

            //Act
            var result = _webService.GetQuadrilateralType(10.4, 5.6, 10, 4, 90, 90, 30, 150);

            //Assert
            Assert.AreEqual(result, EnumHelper.GetEnumDescription(QuadTypeEnum.Trapezoid));
        }
    }
}
