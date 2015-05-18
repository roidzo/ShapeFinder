using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using QuadShapeFinder.Services.BusinessLogic;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using Moq;
using QuadShapeFinder.Tests.Core;
using QuadShapeFinder.Services.Infrastructure;

namespace QuadShapeFinder.Tests
{
    [TestClass]
    public class UnitTestQuadrilateral
    {
        private Mock<IQuadrilateral> _quadrilateral;
        private Mock<ILogger> _logger;
        private QuadrilateralBuilder _quadBuilder;
        private IConfigSettingProvider _configSettingProvider;


        [TestInitialize]
        public void StartUp()
        {
            _quadrilateral = new Mock<IQuadrilateral>();
            _logger = new Mock<ILogger>();

            var mockConfigSettingProvider = new Mock<IConfigSettingProvider>();
            mockConfigSettingProvider.Setup(m => m.EnforceValidationQuadilateralIsClosedShape).Returns(true);
            _configSettingProvider = mockConfigSettingProvider.Object;

            _quadBuilder = new QuadrilateralBuilder(_configSettingProvider);
        }


        #region Test Quadrilateral implementation

        [TestMethod]
        public void TestInvalidQuadrilateral_SumOfAngles()
        {
            //Arrange
            Exception quadCreationException = null;

            //Act
            try
            {
                IQuadrilateral quad = new Quadrilateral(_configSettingProvider);
                quad.Load(2, 3, 2, 3, 40, 135, 45, 135);
            }
            catch (Exception ex)
            {
                quadCreationException = ex;
            }

            //Assert
            Assert.IsNotNull(quadCreationException);
            Assert.IsInstanceOfType(quadCreationException, typeof(ArgumentException));
            Assert.AreEqual("The sum of all angles is not 360", quadCreationException.Message);
        }


        [TestMethod]
        public void TestInvalidQuadrilateral_SidesOfSquareNotCongruent()
        {
            //Arrange
            Exception quadCreationException = null;

            //Act
            try
            {
                IQuadrilateral quad = new Quadrilateral(_configSettingProvider);
                quad.Load(1, 2, 2, 2, 90, 90, 90, 90);
            }
            catch (Exception ex)
            {
                quadCreationException = ex;
            }

            //Assert
            Assert.IsNotNull(quadCreationException);
            Assert.IsInstanceOfType(quadCreationException, typeof(ArgumentException));
            Assert.AreEqual("Angles are all 90 degrees but length of opposing sides differ", quadCreationException.Message);
        }


        [TestMethod]
        public void TestInvalidQuadrilateral_OneOrMoreSidesHaveZeroLength()
        {
            //Arrange
            Exception quadCreationException = null;

            //Act
            try
            {
                IQuadrilateral quad = new Quadrilateral(_configSettingProvider);
                quad.Load(0, 2, 2, 2, 90, 90, 90, 90);
            }
            catch (Exception ex)
            {
                quadCreationException = ex;
            }

            //Assert
            Assert.IsNotNull(quadCreationException);
            Assert.IsInstanceOfType(quadCreationException, typeof(ArgumentOutOfRangeException));
        }

        [TestMethod]
        public void TestInvalidQuadrilateral_OneOrMoreSidesHaveNegativeLength()
        {
            //Arrange
            Exception quadCreationException = null;

            //Act
            try
            {
                IQuadrilateral quad = new Quadrilateral(_configSettingProvider);
                quad.Load(-2, 2, 2, 2, 90, 90, 90, 90);
            }
            catch (Exception ex)
            {
                quadCreationException = ex;
            }

            //Assert
            Assert.IsNotNull(quadCreationException);
            Assert.IsInstanceOfType(quadCreationException, typeof(ArgumentOutOfRangeException));
        }

        #endregion

    }
}
