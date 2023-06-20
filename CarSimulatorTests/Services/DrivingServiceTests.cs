using Moq;
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
    public class DrivingServiceTests
    {
        private readonly DrivingService _sut;
        private readonly Mock<ICarService> _carServiceMock;
        private readonly Mock<IDriverService> _driverServiceMock;
        private readonly Mock<IMessageService> _messageServiceMock;
        public DrivingServiceTests()
        {
            _carServiceMock = new Mock<ICarService>();
            _driverServiceMock = new Mock<IDriverService>();
            _messageServiceMock = new Mock<IMessageService>();
            
            _sut = new DrivingService(
                _driverServiceMock.Object,
                _messageServiceMock.Object,
                _carServiceMock.Object);
        }
        [TestMethod]
        public void SetupCar_Not_Returns_Null()
        {
            //Arrange
            _carServiceMock.Setup(c => c.CreateCar());
            _driverServiceMock.Setup(d => d.GetDriver());

            //Act
            var result = _sut.SetupCar();

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
