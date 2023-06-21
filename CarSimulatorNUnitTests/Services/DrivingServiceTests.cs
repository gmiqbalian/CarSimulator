using Moq;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorNUnitTests.Services
{
    public class DrivingServiceTests
    {
        private DrivingService _sut;
        private Car _car;
        private Mock<ICarService> _carServiceMock;
        private Mock<IDriverService> _driverServiceMock;
        private Mock<IMessageService> _messageServiceMock;

        [SetUp]
        public void Setup()
        {
            _carServiceMock = new Mock<ICarService>();
            _driverServiceMock = new Mock<IDriverService>();
            _messageServiceMock = new Mock<IMessageService>();
            _car = new Car();
            _car.Driver = new Driver();

            _sut = new DrivingService(
                _driverServiceMock.Object,
                _messageServiceMock.Object,
                _carServiceMock.Object);

            _carServiceMock.Setup(c => c.CreateCar()).Returns(new Car());
            _driverServiceMock.Setup(d => d.GetDriver()).Returns(new Driver());
        }

        [Test]
        public void DriveCommand_Fails_If_CarTank_Is_Empty()
        {
            //Arrrange
            var instruction = Instruction.Right;
            for (int i = 1; i <= _car.MaxFuel; i++)
            {
                _car.ConsumeFuel();
            }

            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.That(result, Is.EqualTo(Status.Error));
        }
        [Test]
        public void DriveCommand_Fails_If_Driver_Is_Tired()
        {
            //Arrrange
            var instruction = Instruction.Right;
            _car.Driver.FatigueLevel = _car.Driver.MaxFatigue;

            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.That(result, Is.EqualTo(Status.Error));
        }
        [Test]
        public void DriveCommand_Successful_If_FuelTank_Is_Not_Empty_And_Driver_Is_Not_Tired()
        {
            //Arrrange
            var instruction = Instruction.Right;
            
            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.That(result, Is.EqualTo(Status.Success));
        }
    }
}
