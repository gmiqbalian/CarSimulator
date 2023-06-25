using Moq;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTests.Services
{
    [TestClass]
    public class DriverServiceTests
    {
        private readonly DriverService _sut;
        private readonly Mock<Driver> _driverMock;
        public DriverServiceTests()
        {
            _driverMock = new Mock<Driver>();
            _sut = new DriverService();
        }
        [TestMethod]
        public void GetDriver_Does_Not_Return_Null()
        {
            //Arrange

            //Act
            var result = _sut.GetDriver();

            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetDriver_Returns_Correct_Type()
        {
            //Arrange

            //Act
            var result = _sut.GetDriver();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Driver));
        }
        [TestMethod]
        public void GetDriver_Returns_Valid_Driver_With_All_Properties()
        {
            //Arrange

            //Act
            var result = _sut.GetDriver();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
        }
        [TestMethod]
        public void TakeRest_Returns_True_If_Driver_Is_Tired()
        {
            //Arrange
            var driver = new Driver();
            driver.FatigueLevel = driver.MaxFatigue;

            //Act
            var result = _sut.TakeRest(driver);

            //Assert
            Assert.IsTrue(result);            
        }
        [TestMethod]
        public void TakeRest_Returns_False_If_Driver_Is_Not_Tired()
        {
            //Arrange
            var driver = new Driver();

            //Act
            var result = _sut.TakeRest(driver);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
