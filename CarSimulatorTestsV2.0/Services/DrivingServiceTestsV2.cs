using Moq;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTestsV2._0.Services
{
    [TestClass]
    public class DrivingServiceTestsV2
    {
        private readonly DrivingService _sut;
        private readonly Mock<ICarService> _carServiceMock;
        private readonly Mock<IDriverService> _driverServiceMock;
        private readonly Mock<IMessageService> _messageServiceMock;
        private Car _car;

        public DrivingServiceTestsV2()
        {
            _carServiceMock = new Mock<ICarService>();
            _driverServiceMock = new Mock<IDriverService>();
            _messageServiceMock = new Mock<IMessageService>();

            _sut = new DrivingService(
                _driverServiceMock.Object,
                _messageServiceMock.Object,
                _carServiceMock.Object);
        }
        [TestInitialize]
        public void Setup()
        {
            _carServiceMock.Setup(c => c.CreateCar()).Returns(new Car());
            _driverServiceMock.Setup(d => d.GetDriver()).Returns(new Driver());

            _car = new Car();
            _car.Driver = new Driver();
        }
        [TestMethod]
        public void DriveCommand_Fails_When_Driver_Is_Starving()
        {
            //Assign
            var expected = Status.Error;
            var instruction = Instruction.Right;
            _carServiceMock.Setup(c => c.Drive(
                It.IsAny<Car>(), It.IsAny<Instruction>()))
                .Equals(_car.Driver.HungerLevel = 11);

            ////Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.AreEqual(expected, result);
            _carServiceMock.Verify(x =>
                x.Drive(It.IsAny<Car>(), It.IsAny<Instruction>()), Times.Never);
        }
        [TestMethod]
        public void Drive_Increase_Hunger_By_2()
        {
            //Arrange
            _carServiceMock.Setup(c => c.Drive(It.IsAny<Car>(), It.IsAny<Instruction>()))                
                .Equals(_car.Driver.HungerLevel += 2);

            //Act
            _sut.DriveCommand(Instruction.Right, _car);
            var result = _car.Driver.HungerLevel;

            //Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void RefuelCommand_Increases_Hunger_By_2()
        {
            //Arrange
            _carServiceMock.Setup(c => c.Refuel(_car)).Returns(true);
            _carServiceMock.Setup(c => c.Refuel(It.IsAny<Car>()))
                .Callback<Car>(c => c.Driver.IncreaseHunger());

            //Act
            _sut.RefuelCommand(_car);

            //Assert
            Assert.AreEqual(_car.Driver.HungerLevel, 2);
        }
        [TestMethod]
        [DataRow(false, Status.Error)]
        [DataRow(true, Status.Success)]
        public void EatCommand_Only_Successful_When_Driver_Is_Not_Full(bool state, Status expected)
        {
            //Arrange
            _driverServiceMock.Setup(d => d.Eat(It.IsAny<Driver>()))
                .Returns(state);

            //Act
            var result = _sut.EatCommand(It.IsAny<Driver>());

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Eat_Command_Returns_Hunger_Level_To_Zero_When_Driver_Is_Not_Full()
        {
            //Arrange
            _car.Driver.HungerLevel = 9;
            _driverServiceMock.Setup(d => d.Eat(It.IsAny<Driver>()))
                .Callback<Driver>(Driver => _car.Driver.Eat());

            //Act
            _sut.EatCommand(It.IsAny<Driver>());
            var result = _car.Driver.HungerLevel;

            //Assert
            Assert.AreEqual(result, 0);
            _driverServiceMock.Verify(x => x.Eat(It.IsAny<Driver>()), Times.Once);
        }
    }
}
