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
        public DriverServiceTests()
        {
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
        public void TakeRest_Makes_FatigueLevel_Zero_If_Driver_Is_Tired()
        {
            //Arrange
            var driver = new Driver();
            driver.FatigueLevel = driver.MaxFatigue;
            var expected = 0;

            //Act
            _sut.TakeRest(driver);
            var result = driver.FatigueLevel;

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TakeRest_Not_Successfull_If_Driver_Is_Not_Tired()
        {
            //Arrange
            var driver = new Driver();
            driver.FatigueLevel = 2;
            var expected = 2;

            //Act
            _sut.TakeRest(driver);
            var result = driver.FatigueLevel;

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
