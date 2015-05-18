using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Moq;
using QuadShapeFinder.Services.BusinessLogic;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using QuadShapeFinder.Tests.Core;
using QuadShapeFinder.WebService;
using QuadShapeFinder.Services.Helpers;
using QuadShapeFinder.Services;
using Autofac;
using Autofac.Integration.Wcf;
using QuadShapeFinder.Services.Infrastructure;

namespace QuadShapeFinder.Tests
{
    [TestClass]
    public class UnitTestQuadrilateralService
    {
        private Mock<IQuadrilateralShapeService> _mockService;
        private Mock<ILogger> _mockLogger;
        private IIdentifyQuadrilateral _webService;
        private Mock<IQuadrilateralIdentifier> _mockQuadrilateralIdentifier;
        private IConfigSettingProvider _configSettingProvider;

        [TestInitialize]
        public void StartUp()
        {
            _mockService = new Mock<IQuadrilateralShapeService>();
            _mockLogger = new Mock<ILogger>();

            var mockConfigSettingProvider = new Mock<IConfigSettingProvider>();
            mockConfigSettingProvider.Setup(m => m.EnforceValidationQuadilateralIsClosedShape).Returns(true);
            _configSettingProvider = mockConfigSettingProvider.Object;

            _webService = new IdentifyQuadrilateral(_mockLogger.Object, _mockService.Object);
            _mockQuadrilateralIdentifier = new Mock<IQuadrilateralIdentifier>();
        }

        [TestMethod]
        public void TestGetQuadrilateralTypeService()
        {
            //Arrange
            _mockQuadrilateralIdentifier.Setup(m => m.GetQuadrilateralType(It.IsAny<Quadrilateral>())).Returns(QuadTypeEnum.IsoscelesTrapezoid);

            //Act
            var quadFinderService = new QuadrilateralShapeService(_mockLogger.Object, _mockQuadrilateralIdentifier.Object);
            var result = quadFinderService.GetQuadrilateralType(1, 1, 1, 1, 90, 90, 90, 90);

            //Assert
            Assert.AreEqual(result, QuadTypeEnum.IsoscelesTrapezoid);
        }
    }
}
