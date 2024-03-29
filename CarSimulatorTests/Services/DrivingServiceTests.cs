﻿using Moq;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Car _car;
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
        [TestInitialize]
        public void Setup()
        {
            _carServiceMock.Setup(c => c.CreateCar()).Returns(new Car());
            _driverServiceMock.Setup(d => d.GetDriver()).Returns(new Driver());
            _car = _sut.SetupCar();
        }
        [TestMethod]
        public void SetupCar_Does_Not_Return_Null()
        {
            //Arrange

            //Act
            var result = _sut.SetupCar();

            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SetupCar_Return_Car_Object()
        {
            //Arrange

            //Act
            var result = _sut.SetupCar();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Car));
        }
        [TestMethod]
        public void DriveCommand_Fails_When_CarTank_Is_Empty()
        {
            //Arrange
            var instruction = Instruction.Right;
            for (int i = 1; i <= _car.MaxFuel; i++)
                _car.ConsumeFuel();

            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.AreEqual(Status.Error, result);
        }
        [TestMethod]
        public void DriveCommand_Fails_When_Driver_Is_Tired()
        {
            //Arrange
            var instruction = Instruction.Right;
            _car.Driver.FatigueLevel = _car.Driver.MaxFatigue;

            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.AreEqual(Status.Error, result);
        }
        [TestMethod]
        public void DriveCommand_Successful_When_TankIsNotEmpty_And_DriverIsNotTired()
        {
            //Arrange            
            var instruction = Instruction.Right;

            //Act
            var result = _sut.DriveCommand(instruction, _car);

            //Assert
            Assert.AreEqual(Status.Success, result);
        }
        [TestMethod]
        public void RestCommand_Fails_When_Driver_Is_Already_Rested()
        {
            //Arrange
            _driverServiceMock.Setup(d => d.TakeRest(_car.Driver))
                .Returns(false);

            //Act
            var result = _sut.RestCommand(_car.Driver);

            //Assert
            Assert.AreEqual(Status.Error, result);
        }
        [TestMethod]
        public void RestCommand_Successful_When_Driver_Is_Not_Fully_Rested()
        {
            //Arrange            
            _car.Driver.FatigueLevel = _car.Driver.MaxFatigue;
            _driverServiceMock.Setup(d => d.TakeRest(_car.Driver))
                .Returns(true);

            //Act
            var result = _sut.RestCommand(_car.Driver);

            //Assert
            Assert.AreEqual(Status.Success, result);
        }
        [TestMethod]
        public void RefuelCommand_Fails_When_Tank_Is_Already_Full()
        {
            //Arrange
            _carServiceMock.Setup(c => c.Refuel(_car)).Returns(false);

            //Act
            var result = _sut.RefuelCommand(_car);

            //Assert
            Assert.AreEqual(Status.Error, result);
        }
        [TestMethod]
        public void RefuelCommand_Successful_When_Tank_Is_Not_Full()
        {
            //Arrange            
            _carServiceMock.Setup(c => c.Refuel(_car)).Returns(true);

            //Act
            var result = _sut.RefuelCommand(_car);

            //Assert
            Assert.AreEqual(Status.Success, result);
        }
    }
}
