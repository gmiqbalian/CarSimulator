using CarSimulator;
using Moq;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTestsV2._0
{
    [TestClass]
    public class ApplicationTestsV2
    {
        private readonly Application _sut;
        private readonly Mock<IDrivingService> _drivingServiceMock;
        public ApplicationTestsV2()
        {
            _drivingServiceMock = new Mock<IDrivingService>();
            
            _sut = new Application(_drivingServiceMock.Object);
        }
        [TestMethod]
        public void Application_Exits_When_HungerLevel_Is_16()
        {
            //Arrange
            var car = new Car();
            car.Driver = new Driver();
            car.Driver.HungerLevel = 16;
            _drivingServiceMock.Setup(x => x.SetupCar()).Returns(car);

            //Act
            var status = _sut.Run();

            //Assert
            Assert.IsTrue(status == Status.Error);
        }
    }
}
