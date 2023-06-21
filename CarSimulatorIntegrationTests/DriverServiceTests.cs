using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorIntegrationTests
{
    [TestClass]
    public class DriverServiceTests
    {
        private DriverService _driverSerivce;
        [TestInitialize]
        public void Setup()
        {
            _driverSerivce = new DriverService();
        }
        [TestMethod]
        public void GetDriver_Returns_Valid_Driver_With_All_Properties()
        {
            //Arrange

            //Act
            var result = _driverSerivce.GetDriver();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.Name));
            Assert.IsFalse(string.IsNullOrEmpty(result.Gender));
            Assert.IsFalse(string.IsNullOrEmpty(result.Cell));
            Assert.IsFalse(string.IsNullOrEmpty(result.Phone));
            Assert.IsFalse(string.IsNullOrEmpty(result.Age));
            Assert.IsInstanceOfType(result, typeof(Driver));
        }
    }
}
